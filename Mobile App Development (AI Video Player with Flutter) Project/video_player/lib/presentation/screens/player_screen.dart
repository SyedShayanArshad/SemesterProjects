import 'dart:io';
import 'dart:async';
import 'dart:ui' as ui;
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:flutter/services.dart';
import 'package:media_kit_video/media_kit_video.dart';
import 'package:path_provider/path_provider.dart';
import 'package:provider/provider.dart';
import '../providers/player_provider.dart';
import '../providers/settings_provider.dart';
import '../widgets/player/video_controls.dart';
import '../widgets/player/gesture_overlay.dart';
import '../widgets/player/lock_screen_overlay.dart';
import '../widgets/player/subtitle_overlay.dart';
import '../../data/models/video_model.dart';
import '../../data/services/history_service.dart';

class PlayerScreen extends StatefulWidget {
  final List<VideoModel> playlist;
  final int startIndex;

  const PlayerScreen({
    super.key,
    required this.playlist,
    this.startIndex = 0,
  });

  @override
  State<PlayerScreen> createState() => _PlayerScreenState();
}

class _PlayerScreenState extends State<PlayerScreen>
    with WidgetsBindingObserver {
  late PlayerProvider _playerProvider;
  late VideoController _videoController;
  bool _isFullscreen = false;
  bool _orientationLocked = false; // prevents re-triggering after user overrides
  bool _allowPop = false;
  final _videoKey = GlobalKey();

  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addObserver(this);
    _playerProvider = context.read<PlayerProvider>();
    final settings = context.read<SettingsProvider>().settings;

    _playerProvider.initPlayer(settings);
    _videoController = VideoController(_playerProvider.player);
    _playerProvider.setScreenshotCallback(_takeScreenshot);

    // Auto-rotate to match video orientation on first valid video params
    _playerProvider.player.stream.videoParams.listen((params) {
      if (!mounted || _orientationLocked) return;
      final w = params.dw ?? params.w ?? 0;
      final h = params.dh ?? params.h ?? 0;
      if (w <= 0 || h <= 0) return;
      _orientationLocked = true; // lock after first detection
      if (w >= h) {
        // Landscape video → landscape mode
        SystemChrome.setPreferredOrientations([
          DeviceOrientation.landscapeLeft,
          DeviceOrientation.landscapeRight,
        ]);
        SystemChrome.setEnabledSystemUIMode(SystemUiMode.immersiveSticky);
        setState(() => _isFullscreen = true);
      } else {
        // Portrait video → portrait mode
        SystemChrome.setPreferredOrientations([
          DeviceOrientation.portraitUp,
          DeviceOrientation.portraitDown,
        ]);
        SystemChrome.setEnabledSystemUIMode(SystemUiMode.edgeToEdge);
        setState(() => _isFullscreen = false);
      }
    });

    _openVideo();
  }

  Future<void> _resetSystemUiForApp() async {
    await SystemChrome.setEnabledSystemUIMode(SystemUiMode.edgeToEdge);
    await SystemChrome.setPreferredOrientations([
      DeviceOrientation.portraitUp,
      DeviceOrientation.portraitDown,
    ]);
  }

  Future<void> _prepareExit() async {
    await _playerProvider.stopNow();
    unawaited(_playerProvider.savePositionNow());
    await _resetSystemUiForApp();
  }

  Future<void> _exitPlayer() async {
    await _prepareExit();
    if (mounted) {
      if (!_allowPop) {
        setState(() => _allowPop = true);
      }
      Navigator.pop(context);
    }
  }

  Future<String?> _takeScreenshot() async {
    try {
      final boundary = _videoKey.currentContext?.findRenderObject()
          as RenderRepaintBoundary?;
      if (boundary == null) return null;
      final image = await boundary.toImage(pixelRatio: 2.0);
      final byteData =
          await image.toByteData(format: ui.ImageByteFormat.png);
      if (byteData == null) return null;
      final bytes = byteData.buffer.asUint8List();
      final dir = await getTemporaryDirectory();
      final ts = DateTime.now().millisecondsSinceEpoch;
      final file = File('${dir.path}/screenshot_$ts.png');
      await file.writeAsBytes(bytes);
      return file.path;
    } catch (_) {
      return null;
    }
  }

  Future<void> _openVideo() async {
    final settings = context.read<SettingsProvider>().settings;
    final history = context.read<HistoryService>();

    Duration? startPos;
    if (settings.resumePlayback) {
      startPos = await history.getLastPosition(
          widget.playlist[widget.startIndex].path);
    }

    await _playerProvider.openPlaylist(
      widget.playlist,
      startIndex: widget.startIndex,
      startPosition: startPos,
      settings: settings,
    );

    await _playerProvider.setSpeed(settings.playbackSpeed);
  }

  void _toggleFullscreen() {
    setState(() {
      _isFullscreen = !_isFullscreen;
      _orientationLocked = true; // user is taking manual control
    });
    // Re-show controls so user can see them in new orientation
    _playerProvider.showControls();
    if (_isFullscreen) {
      SystemChrome.setPreferredOrientations([
        DeviceOrientation.landscapeLeft,
        DeviceOrientation.landscapeRight,
      ]);
      SystemChrome.setEnabledSystemUIMode(SystemUiMode.immersiveSticky);
    } else {
      SystemChrome.setPreferredOrientations([
        DeviceOrientation.portraitUp,
        DeviceOrientation.portraitDown,
        DeviceOrientation.landscapeLeft,
        DeviceOrientation.landscapeRight,
      ]);
      SystemChrome.setEnabledSystemUIMode(SystemUiMode.edgeToEdge);
    }
  }

  @override
  void didChangeAppLifecycleState(AppLifecycleState state) {
    if (state == AppLifecycleState.paused) {
      _playerProvider.pause();
      _playerProvider.savePositionNow();
    }
  }

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider.value(
      value: _playerProvider,
      child: PopScope(
        canPop: _allowPop,
        onPopInvokedWithResult: (didPop, result) {
          if (didPop) return;
          unawaited(_exitPlayer());
        },
        child: Scaffold(
          backgroundColor: Colors.black,
          body: Consumer<PlayerProvider>(
            builder: (context, player, _) {
              return GestureOverlay(
                child: Stack(
                  fit: StackFit.expand,
                  children: [
                    // ─── Video surface ───────────────────────────────────
                    RepaintBoundary(
                      key: _videoKey,
                      child: Transform.scale(
                        scale: player.scale,
                        child: Video(
                          controller: _videoController,
                          fit: player.videoFit,
                          controls: NoVideoControls,
                        ),
                      ),
                    ),

                    // ─── Controls ────────────────────────────────────────
                    if (player.controlsVisible && !player.isLocked)
                      AnimatedOpacity(
                        opacity: player.controlsVisible ? 1 : 0,
                        duration: const Duration(milliseconds: 300),
                        child: VideoControls(
                          onClose: () => unawaited(_exitPlayer()),
                          onFullscreen: _toggleFullscreen,
                          isFullscreen: _isFullscreen,
                        ),
                      ),

                    // ─── Lock overlay ────────────────────────────────────
                    if (player.isLocked)
                      LockScreenOverlay(onUnlock: player.toggleLock),

                    // ─── AI Subtitle overlay ─────────────────────────────
                    if (player.subtitlesVisible && player.subtitleCues.isNotEmpty)
                      SubtitleOverlay(
                        cues: player.subtitleCues,
                        position: player.position,
                      ),

                    // ─── Buffering ───────────────────────────────────────
                    if (player.isBuffering && !player.isLocked)
                      const Center(
                        child: CircularProgressIndicator(color: Colors.white54),
                      ),
                  ],
                ),
              );
            },
          ),
        ),
      ),
    );
  }

  @override
  void dispose() {
    WidgetsBinding.instance.removeObserver(this);
    // Best-effort reset (actual pop path also resets & awaits).
    unawaited(_resetSystemUiForApp());
    super.dispose();
  }
}

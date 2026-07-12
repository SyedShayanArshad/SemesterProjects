import 'dart:io';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:share_plus/share_plus.dart';
import '../../providers/player_provider.dart';
import '../../../core/utils/duration_utils.dart';
import '../../../core/constants/app_constants.dart';
import '../../../data/services/subtitle_service.dart';
import '../../../data/services/history_service.dart';
import 'seek_bar.dart';
import 'speed_selector.dart';
import 'ab_repeat_control.dart';
import 'bookmark_panel.dart';
import 'sleep_timer_dialog.dart';
import 'generate_subtitle_dialog.dart';
import 'dub_video_dialog.dart';
class VideoControls extends StatefulWidget {
  final VoidCallback? onClose;
  final VoidCallback? onFullscreen;
  final bool isFullscreen;

  const VideoControls({
    super.key,
    this.onClose,
    this.onFullscreen,
    this.isFullscreen = false,
  });

  @override
  State<VideoControls> createState() => _VideoControlsState();
}

class _VideoControlsState extends State<VideoControls> {
  @override
  Widget build(BuildContext context) {
    final player = context.watch<PlayerProvider>();
    final video = player.currentVideo;

    return Container(
      decoration: const BoxDecoration(
        gradient: LinearGradient(
          begin: Alignment.topCenter,
          end: Alignment.bottomCenter,
          stops: [0.0, 0.25, 0.75, 1.0],
          colors: [
            Color(0xCC000000),
            Color(0x00000000),
            Color(0x00000000),
            Color(0xCC000000),
          ],
        ),
      ),
      child: SafeArea(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Padding(
              padding: const EdgeInsets.fromLTRB(4, 4, 8, 0),
              child: Row(
                children: [
                  if (widget.onClose != null)
                    _PlayerIconBtn(
                      icon: Icons.arrow_back_ios_new_rounded,
                      onTap: widget.onClose!,
                    ),
                  Expanded(
                    child: Text(
                      video?.displayName ?? '',
                      style: const TextStyle(
                        color: Colors.white,
                        fontSize: 14,
                        fontWeight: FontWeight.w600,
                        shadows: [Shadow(blurRadius: 8)],
                      ),
                      overflow: TextOverflow.ellipsis,
                    ),
                  ),
                  _PlayerIconBtn(
                    icon: player.isLocked
                        ? Icons.lock_rounded
                        : Icons.lock_open_rounded,
                    onTap: player.toggleLock,
                    active: player.isLocked,
                  ),
                  _PlayerIconBtn(
                    icon: Icons.tune_rounded,
                    onTap: () => _showVideoMoreOptions(context),
                  ),
                ],
              ),
            ),
            const Spacer(),
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 4),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  _PlayerIconBtn(
                    icon: Icons.skip_previous_rounded,
                    onTap: player.playPrevious,
                    size: 28,
                  ),
                  const SizedBox(width: 8),
                  _SeekButton(
                    icon: Icons.replay_10_rounded,
                    onTap: () => player.seekBackward(AppConstants.seekSeconds),
                  ),
                  const SizedBox(width: 12),
                  _PlayPauseBtn(
                    isPlaying: player.isPlaying,
                    isBuffering: player.isBuffering,
                    onTap: player.playPause,
                  ),
                  const SizedBox(width: 12),
                  _SeekButton(
                    icon: Icons.forward_10_rounded,
                    onTap: () => player.seekForward(AppConstants.seekSeconds),
                  ),
                  const SizedBox(width: 8),
                  _PlayerIconBtn(
                    icon: Icons.skip_next_rounded,
                    onTap: player.playNext,
                    size: 28,
                  ),
                ],
              ),
            ),
            const SizedBox(height: 4),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 12),
              child: Column(
                children: [
                  VideoSeekBar(
                    position: player.position,
                    duration: player.duration,
                    onSeek: player.seekTo,
                    abStart: player.abStart,
                    abEnd: player.abEnd,
                  ),
                  const SizedBox(height: 2),
                  Row(
                    children: [
                      Text(
                        DurationUtils.format(player.position),
                        style: const TextStyle(
                          color: Colors.white70,
                          fontSize: 11,
                          fontWeight: FontWeight.w500,
                        ),
                      ),
                      const Spacer(),
                      GestureDetector(
                        onTap: () => _showSpeedSelector(context),
                        child: Container(
                          padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 3),
                          decoration: BoxDecoration(
                            color: Colors.white.withValues(alpha: 0.15),
                            borderRadius: BorderRadius.circular(6),
                            border: Border.all(color: Colors.white24),
                          ),
                          child: Text(
                            '${player.playbackSpeed}x',
                            style: const TextStyle(
                              color: Colors.white,
                              fontSize: 11,
                              fontWeight: FontWeight.w700,
                            ),
                          ),
                        ),
                      ),
                      const Spacer(),
                      Text(
                        DurationUtils.format(player.duration),
                        style: const TextStyle(
                          color: Colors.white70,
                          fontSize: 11,
                          fontWeight: FontWeight.w500,
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ),
            Padding(
              padding: const EdgeInsets.fromLTRB(8, 0, 8, 4),
              child: Row(
                children: [
                  _CompactIcon(
                    icon: Icons.repeat_rounded,
                    color: player.loopVideo ? const Color(0xFF6C63FF) : Colors.white54,
                    onTap: () => player.setLoop(!player.loopVideo),
                    tooltip: 'Loop',
                  ),
                  _CompactIcon(
                    icon: Icons.shuffle_rounded,
                    color: player.shufflePlaylist ? const Color(0xFF6C63FF) : Colors.white54,
                    onTap: () => player.setShuffle(!player.shufflePlaylist),
                    tooltip: 'Shuffle',
                  ),
                  const Spacer(),
                  _CompactIcon(
                    icon: Icons.repeat_one_rounded,
                    color: player.abRepeatActive ? Colors.orange : Colors.white54,
                    onTap: () => _showAbRepeat(context),
                    tooltip: 'A-B Repeat',
                  ),
                  _CompactIcon(
                    icon: Icons.bookmark_border_rounded,
                    color: Colors.white54,
                    onTap: () => _showBookmarks(context),
                    tooltip: 'Bookmarks',
                  ),
                  _CompactIcon(
                    icon: Icons.bedtime_outlined,
                    color: player.sleepRemaining != null ? Colors.amber : Colors.white54,
                    onTap: () => _showSleepTimer(context),
                    tooltip: 'Sleep timer',
                  ),
                  _CompactIcon(
                    icon: Icons.closed_caption_rounded,
                    color: player.subtitlesVisible && player.subtitleCues.isNotEmpty
                        ? const Color(0xFF6C63FF)
                        : Colors.white54,
                    onTap: () => _showSubtitlePanel(context),
                    tooltip: 'Subtitles',
                  ),
                  _CompactIcon(
                    icon: Icons.fit_screen_rounded,
                    color: Colors.white54,
                    onTap: player.cycleVideoFit,
                    tooltip: player.videoFitName,
                  ),
                  if (player.scale != 1.0)
                    _CompactIcon(
                      icon: Icons.zoom_out_map_rounded,
                      color: Colors.orange,
                      onTap: player.resetScale,
                      tooltip: 'Reset Zoom',
                    ),
                  if (widget.onFullscreen != null)
                    _CompactIcon(
                      icon: widget.isFullscreen
                          ? Icons.fullscreen_exit_rounded
                          : Icons.fullscreen_rounded,
                      color: Colors.white,
                      onTap: widget.onFullscreen!,
                      tooltip: 'Fullscreen',
                    ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  void _showSpeedSelector(BuildContext context) {
    final player = context.read<PlayerProvider>();
    showModalBottomSheet(
      context: context,
      backgroundColor: Colors.grey[900],
      useRootNavigator: true,
      isScrollControlled: true,
      builder: (_) => SafeArea(
        child: FractionallySizedBox(
          heightFactor: 0.86,
          child: SpeedSelector(
            currentSpeed: player.playbackSpeed,
            onSpeedSelected: (s) {
              player.setSpeed(s);
              Navigator.pop(context);
            },
          ),
        ),
      ),
    );
  }

  void _showAbRepeat(BuildContext context) {
    final player = context.read<PlayerProvider>();
    showModalBottomSheet(
      context: context,
      backgroundColor: Colors.grey[900],
      useRootNavigator: true,
      isScrollControlled: true,
      builder: (_) => SafeArea(
        child: ChangeNotifierProvider.value(
          value: player,
          child: const AbRepeatControl(),
        ),
      ),
    );
  }

  void _showBookmarks(BuildContext context) {
    final player = context.read<PlayerProvider>();
    showModalBottomSheet(
      context: context,
      backgroundColor: Colors.grey[900],
      useRootNavigator: true,
      isScrollControlled: true,
      builder: (_) => SafeArea(
        child: ChangeNotifierProvider.value(
          value: player,
          child: const BookmarkPanel(),
        ),
      ),
    );
  }

  void _showSleepTimer(BuildContext context) {
    final player = context.read<PlayerProvider>();
    showModalBottomSheet(
      context: context,
      backgroundColor: Colors.grey[900],
      useRootNavigator: true,
      isScrollControlled: true,
      builder: (_) => SafeArea(
        child: SleepTimerDialog(
          remaining: player.sleepRemaining,
          onSet: (d) {
            player.setSleepTimer(d);
            Navigator.pop(context);
          },
          onCancel: () {
            player.cancelSleepTimer();
            Navigator.pop(context);
          },
        ),
      ),
    );
  }

  void _takeScreenshot(BuildContext context) async {
    final player = context.read<PlayerProvider>();
    final path = await player.takeScreenshot();
    if (!context.mounted) return;
    if (path != null) {
      try {
        await Share.shareXFiles(
          [XFile(path)],
          text: 'Video screenshot from ${player.currentVideo?.displayName ?? "Video"}',
        );
      } catch (_) {
        if (context.mounted) {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(content: Text('Screenshot saved: $path')),
          );
        }
      }
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Screenshot failed')),
      );
    }
  }

  void _showVideoMoreOptions(BuildContext context) {
    final player = context.read<PlayerProvider>();
    showModalBottomSheet(
      context: context,
      backgroundColor: const Color(0xFF1A1A28),
      useRootNavigator: true,
      isScrollControlled: true,
      builder: (sheetCtx) => SafeArea(
        child: Container(
          decoration: const BoxDecoration(
            color: Color(0xFF1A1A28),
            borderRadius: BorderRadius.vertical(top: Radius.circular(18)),
          ),
          child: Builder(
            builder: (_) {
              final isLandscape = MediaQuery.of(sheetCtx).orientation == Orientation.landscape;

              void closeThen(VoidCallback action) {
                Navigator.pop(sheetCtx);
                Future.delayed(const Duration(milliseconds: 150), action);
              }

              Widget handleBar() {
                return Container(
                  margin: const EdgeInsets.only(top: 10, bottom: 6),
                  width: 38,
                  height: 4,
                  decoration: BoxDecoration(
                    color: Colors.white24,
                    borderRadius: BorderRadius.circular(2),
                  ),
                );
              }

              Widget trayButton({
                required IconData icon,
                required String label,
                required VoidCallback onTap,
                double width = 92,
                Color iconColor = Colors.white,
              }) {
                return Material(
                  color: Colors.transparent,
                  child: InkWell(
                    onTap: onTap,
                    borderRadius: BorderRadius.circular(12),
                    child: Container(
                      width: width,
                      padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 10),
                      decoration: BoxDecoration(
                        color: Colors.white.withValues(alpha: 0.06),
                        borderRadius: BorderRadius.circular(12),
                        border: Border.all(color: Colors.white12),
                      ),
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Icon(icon, color: iconColor, size: 22),
                          const SizedBox(height: 6),
                          Text(
                            label,
                            style: const TextStyle(
                              color: Colors.white,
                              fontSize: 11,
                              fontWeight: FontWeight.w600,
                            ),
                            maxLines: 1,
                            overflow: TextOverflow.ellipsis,
                            textAlign: TextAlign.center,
                          ),
                        ],
                      ),
                    ),
                  ),
                );
              }

              if (isLandscape) {
                return ConstrainedBox(
                  constraints: BoxConstraints(
                    maxHeight: MediaQuery.of(sheetCtx).size.height * 0.45,
                  ),
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      handleBar(),
                      const SizedBox(height: 2),
                      Padding(
                        padding: const EdgeInsets.only(bottom: 18),
                        child: SizedBox(
                          height: 88,
                          child: LayoutBuilder(
                            builder: (ctx, constraints) {
                              const visibleCount = 6;
                              const gap = 10.0;
                              const horizontalPadding = 12.0 * 2;

                              final available = (constraints.maxWidth - horizontalPadding)
                                  .clamp(0.0, double.infinity);
                              final computedWidth = ((available - (gap * (visibleCount - 1))) /
                                      visibleCount)
                                  .clamp(78.0, 118.0);

                              return ListView(
                                scrollDirection: Axis.horizontal,
                                padding: const EdgeInsets.symmetric(
                                  horizontal: 12,
                                  vertical: 8,
                                ),
                                children: [
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.speed_rounded,
                                    label: 'Speed',
                                    onTap: () =>
                                        closeThen(() => _showSpeedSelector(context)),
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.subtitles_rounded,
                                    label: 'Subtitles',
                                    onTap: () =>
                                        closeThen(() => _showSubtitlePanel(context)),
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.bookmark_border_rounded,
                                    label: 'Bookmarks',
                                    onTap: () => closeThen(() => _showBookmarks(context)),
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.screenshot_rounded,
                                    label: 'Screenshot',
                                    onTap: () => closeThen(() => _takeScreenshot(context)),
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.bedtime_outlined,
                                    label: 'Sleep Timer',
                                    onTap: () => closeThen(() => _showSleepTimer(context)),
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.repeat_one_rounded,
                                    label: 'A-B Repeat',
                                    onTap: () => closeThen(() => _showAbRepeat(context)),
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.auto_awesome_outlined,
                                    label: 'AI Subtitle',
                                    onTap: () => closeThen(() => _generateSubtitle(context)),
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.record_voice_over_rounded,
                                    label: player.isDubbed ? 'Restore' : 'Dub',
                                    onTap: () {
                                      Navigator.pop(sheetCtx);
                                      if (player.isDubbed) {
                                        player.restoreOriginal();
                                      } else {
                                        Future.delayed(const Duration(milliseconds: 150), () => _dubVideo(context));
                                      }
                                    },
                                  ),
                                  const SizedBox(width: gap),
                                  trayButton(
                                    width: computedWidth,
                                    icon: Icons.close_rounded,
                                    iconColor: Colors.white70,
                                    label: 'Close',
                                    onTap: () => Navigator.pop(sheetCtx),
                                  ),
                                ],
                              );
                            },
                          ),
                        ),
                      ),
                      const SizedBox(height: 6),
                    ],
                  ),
                );
              }

              // Portrait (existing list-wise UI)
              return ConstrainedBox(
                constraints: BoxConstraints(
                  maxHeight: MediaQuery.of(sheetCtx).size.height * 0.84,
                ),
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      handleBar(),
                      ListTile(
                        leading: const Icon(Icons.speed_rounded, color: Colors.white),
                        title: const Text('Speed', style: TextStyle(color: Colors.white)),
                        onTap: () => closeThen(() => _showSpeedSelector(context)),
                      ),
                      ListTile(
                        leading: const Icon(Icons.subtitles_rounded, color: Colors.white),
                        title: const Text('Subtitle', style: TextStyle(color: Colors.white)),
                        onTap: () => closeThen(() => _showSubtitlePanel(context)),
                      ),
                      ListTile(
                        leading: const Icon(Icons.bookmark_border_rounded, color: Colors.white),
                        title: const Text('Bookmarks', style: TextStyle(color: Colors.white)),
                        onTap: () => closeThen(() => _showBookmarks(context)),
                      ),
                      ListTile(
                        leading: const Icon(Icons.screenshot_rounded, color: Colors.white),
                        title: const Text('Screenshot', style: TextStyle(color: Colors.white)),
                        onTap: () => closeThen(() => _takeScreenshot(context)),
                      ),
                      ListTile(
                        leading: const Icon(Icons.bedtime_outlined, color: Colors.white),
                        title: const Text('SleepTimer', style: TextStyle(color: Colors.white)),
                        onTap: () => closeThen(() => _showSleepTimer(context)),
                      ),
                      ListTile(
                        leading: const Icon(Icons.repeat_one_rounded, color: Colors.white),
                        title: const Text('A-B Repeat', style: TextStyle(color: Colors.white)),
                        onTap: () => closeThen(() => _showAbRepeat(context)),
                      ),
                      ListTile(
                        leading: const Icon(Icons.auto_awesome_outlined, color: Colors.white),
                        title:
                            const Text('Generate Subtitle', style: TextStyle(color: Colors.white)),
                        onTap: () => closeThen(() => _generateSubtitle(context)),
                      ),
                      ListTile(
                        leading:
                            const Icon(Icons.record_voice_over_rounded, color: Colors.white),
                        title: Text(
                          player.isDubbed ? 'Restore Original' : 'Dub Video',
                          style: const TextStyle(color: Colors.white),
                        ),
                        onTap: () {
                          Navigator.pop(sheetCtx);
                          if (player.isDubbed) {
                            player.restoreOriginal();
                          } else {
                            Future.delayed(const Duration(milliseconds: 150), () => _dubVideo(context));
                          }
                        },
                      ),
                      ListTile(
                        leading: const Icon(Icons.close_rounded, color: Colors.white70),
                        title: const Text('Close', style: TextStyle(color: Colors.white70)),
                        onTap: () => Navigator.pop(sheetCtx),
                      ),
                    ],
                  ),
                ),
              );
            },
          ),
        ),
      ),
    );
  }
}

// ── Top-level helpers callable from both _VideoControlsState and _MoreOptionsTray ──

void _showSubtitlePanel(BuildContext context) {
  final player = context.read<PlayerProvider>();
  final navigator = Navigator.of(context, rootNavigator: true);

  showModalBottomSheet(
    context: navigator.context,
    backgroundColor: const Color(0xFF1A1A28),
    useRootNavigator: true,
    isScrollControlled: true,
    shape: const RoundedRectangleBorder(
      borderRadius: BorderRadius.vertical(top: Radius.circular(24)),
    ),
    builder: (ctx) => ChangeNotifierProvider.value(
      value: player,
      child: _SubtitlePanel(
        onLoadFile: () async {
          Navigator.pop(ctx);
          try {
            final result = await FilePicker.platform.pickFiles(
              type: FileType.custom,
              allowedExtensions: AppConstants.supportedSubtitleExtensions,
            );
            if (result != null && result.files.isNotEmpty) {
              final path = result.files.first.path;
              if (path != null) player.loadExternalSubtitle(path);
            }
          } catch (_) {}
        },
        onGenerateAI: () {
          Navigator.pop(ctx);
          _generateSubtitle(context);
        },
      ),
    ),
  );
}

void _generateSubtitle(BuildContext context) async {
  // Capture these BEFORE the await — context may be stale after the
  // _MoreOptionsTray closes and its element is removed from the tree.
  final player = context.read<PlayerProvider>();
  final messenger = ScaffoldMessenger.of(context);
  final navigator = Navigator.of(context, rootNavigator: true);
  final videoPath = player.currentVideo?.path;
  if (videoPath == null) return;

  final historyService = HistoryService();
  final assets = await historyService.getGeneratedAssets(videoPath);
  final existingSrt = assets?['srt'];

  if (existingSrt != null && await File(existingSrt).exists()) {
    final choice = await showDialog<String>(
      context: navigator.context,
      builder: (ctx) => AlertDialog(
        backgroundColor: Colors.grey[900],
        title: const Text('Subtitle Exists', style: TextStyle(color: Colors.white)),
        content: const Text('A generated subtitle already exists for this video. What would you like to do?', style: TextStyle(color: Colors.white70)),
        actions: [
          TextButton(onPressed: () => Navigator.pop(ctx, 'cancel'), child: const Text('Cancel')),
          TextButton(onPressed: () => Navigator.pop(ctx, 'play'), child: const Text('Play Existing')),
          ElevatedButton(onPressed: () => Navigator.pop(ctx, 'regenerate'), child: const Text('Regenerate')),
        ],
      ),
    );

    if (choice == 'cancel' || choice == null) return;
    if (choice == 'play') {
      try {
        player.loadExternalSubtitle(existingSrt);
        messenger.showSnackBar(
          SnackBar(content: const Text('Loaded existing subtitles.'), backgroundColor: Colors.green[800]),
        );
      } catch(e) {
        messenger.showSnackBar(SnackBar(content: Text('Failed to load: $e'), backgroundColor: Colors.red[800]));
      }
      return;
    }
  }

  final result = await showDialog<SubtitleResult>(
    context: navigator.context,
    barrierDismissible: false,
    builder: (_) => GenerateSubtitleDialog(videoPath: videoPath),
  );

  if (result != null) {
    final cues = SubtitleService.parseSrt(result.srtContent);
    player.loadGeneratedSubtitles(cues);

    messenger.showSnackBar(
      SnackBar(
        content: Text(
          'Subtitles generated! ${result.segmentCount} lines · '
          'Language: ${result.detectedLanguage}',
        ),
        backgroundColor: Colors.green[800],
        duration: const Duration(seconds: 4),
      ),
    );
  }
}

void _dubVideo(BuildContext context) async {
  // Capture refs before any await / navigation
  final player = context.read<PlayerProvider>();
  final messenger = ScaffoldMessenger.of(context);
  final navigator = Navigator.of(context, rootNavigator: true);
  final videoPath = player.currentVideo?.path;
  if (videoPath == null) return;

  final historyService = HistoryService();
  final assets = await historyService.getGeneratedAssets(videoPath);
  final existingDub = assets?['dubbed'];

  if (existingDub != null && await File(existingDub).exists()) {
    final choice = await showDialog<String>(
      context: navigator.context,
      builder: (ctx) => AlertDialog(
        backgroundColor: Colors.grey[900],
        title: const Text('Dubbed Audio Exists', style: TextStyle(color: Colors.white)),
        content: const Text('A dubbed version already exists for this video. What would you like to do?', style: TextStyle(color: Colors.white70)),
        actions: [
          TextButton(onPressed: () => Navigator.pop(ctx, 'cancel'), child: const Text('Cancel')),
          TextButton(onPressed: () => Navigator.pop(ctx, 'play'), child: const Text('Play Existing')),
          ElevatedButton(onPressed: () => Navigator.pop(ctx, 'regenerate'), child: const Text('Regenerate')),
        ],
      ),
    );

    if (choice == 'cancel' || choice == null) return;
    if (choice == 'play') {
      player.playDubbedVersion(existingDub);
      messenger.showSnackBar(
        SnackBar(
          content: const Text('Playing existing dubbed version. Tap "Restore" to go back.'),
          backgroundColor: Colors.deepPurple[800],
          duration: const Duration(seconds: 5),
        ),
      );
      return;
    }
  }

  final dubbedPath = await showDialog<String?>(
    context: navigator.context,
    barrierDismissible: false,
    builder: (_) => DubVideoDialog(videoPath: videoPath),
  );

  if (dubbedPath != null) {
    player.playDubbedVersion(dubbedPath);
    messenger.showSnackBar(
      SnackBar(
        content: const Text('Playing dubbed version. Tap "Restore" to go back.'),
        backgroundColor: Colors.deepPurple[800],
        duration: const Duration(seconds: 5),
      ),
    );
  }
}

/// Compact icon button for the bottom action bar that avoids 48 px minimum size.
class _CompactIcon extends StatelessWidget {
  final IconData icon;
  final Color color;
  final VoidCallback onTap;
  final String tooltip;

  const _CompactIcon({
    required this.icon,
    required this.color,
    required this.onTap,
    required this.tooltip,
  });

  @override
  Widget build(BuildContext context) {
    return Tooltip(
      message: tooltip,
      child: Material(
        color: Colors.transparent,
        child: InkWell(
          onTap: onTap,
          borderRadius: BorderRadius.circular(20),
          child: Padding(
            padding: const EdgeInsets.all(7),
            child: Icon(icon, color: color, size: 21),
          ),
        ),
      ),
    );
  }
}

/// Small icon button used in the top bar.
class _PlayerIconBtn extends StatelessWidget {
  final IconData icon;
  final VoidCallback onTap;
  final double size;
  final bool active;

  const _PlayerIconBtn({
    required this.icon,
    required this.onTap,
    this.size = 22,
    this.active = false,
  });

  @override
  Widget build(BuildContext context) {
    return Material(
      color: Colors.transparent,
      child: InkWell(
        onTap: onTap,
        borderRadius: BorderRadius.circular(20),
        child: Padding(
          padding: const EdgeInsets.all(8),
          child: Icon(
            icon,
            color: active ? const Color(0xFF6C63FF) : Colors.white,
            size: size,
            shadows: const [Shadow(blurRadius: 6)],
          ),
        ),
      ),
    );
  }
}

/// Animated Play / Pause button with accent glow.
class _PlayPauseBtn extends StatelessWidget {
  final bool isPlaying;
  final bool isBuffering;
  final VoidCallback onTap;

  const _PlayPauseBtn({
    required this.isPlaying,
    required this.isBuffering,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 72,
        height: 72,
        decoration: BoxDecoration(
          shape: BoxShape.circle,
          color: Colors.white.withValues(alpha: 0.15),
          border: Border.all(color: Colors.white24, width: 1.5),
          boxShadow: const [
            BoxShadow(
              color: Color(0x336C63FF),
              blurRadius: 24,
              spreadRadius: 4,
            ),
          ],
        ),
        child: isBuffering
            ? const Center(
                child: SizedBox(
                  width: 28,
                  height: 28,
                  child: CircularProgressIndicator(
                    color: Colors.white,
                    strokeWidth: 2.5,
                  ),
                ),
              )
            : Icon(
                isPlaying ? Icons.pause_rounded : Icons.play_arrow_rounded,
                color: Colors.white,
                size: 40,
              ),
      ),
    );
  }
}

/// Subtitle selection / management panel.
class _SubtitlePanel extends StatelessWidget {
  final VoidCallback onLoadFile;
  final VoidCallback onGenerateAI;

  const _SubtitlePanel({
    required this.onLoadFile,
    required this.onGenerateAI,
  });

  @override
  Widget build(BuildContext context) {
    final player = context.watch<PlayerProvider>();
    final hasCues = player.subtitleCues.isNotEmpty;

    final bottomInset = MediaQuery.viewInsetsOf(context).bottom;
    final maxHeight = MediaQuery.sizeOf(context).height * 0.85;

    return SafeArea(
      child: Padding(
        padding: EdgeInsets.only(bottom: bottomInset),
        child: ConstrainedBox(
          constraints: BoxConstraints(maxHeight: maxHeight),
          child: SingleChildScrollView(
            child: Padding(
              padding: const EdgeInsets.fromLTRB(16, 12, 16, 16),
              child: Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  // Handle bar
                  Center(
                    child: Container(
                      width: 36,
                      height: 4,
                      decoration: BoxDecoration(
                        color: Colors.white24,
                        borderRadius: BorderRadius.circular(2),
                      ),
                    ),
                  ),
                  const SizedBox(height: 16),

                  const Text(
                    'Subtitles',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 18,
                      fontWeight: FontWeight.w700,
                      letterSpacing: 0.2,
                    ),
                  ),
                  const SizedBox(height: 14),

                  // ── AI / Generated subtitles section ────────────────────────
                  if (hasCues) ...[
                    Container(
                      decoration: BoxDecoration(
                        color: Colors.white10,
                        borderRadius: BorderRadius.circular(10),
                      ),
                      child: Column(
                        children: [
                          ListTile(
                            leading: Icon(
                              Icons.closed_caption_rounded,
                              color: player.subtitlesVisible
                                  ? const Color(0xFF6C63FF)
                                  : Colors.white54,
                            ),
                            title: const Text(
                              'AI Generated',
                              style: TextStyle(color: Colors.white),
                            ),
                            subtitle: Text(
                              '${player.subtitleCues.length} lines loaded',
                              style: const TextStyle(color: Colors.white54, fontSize: 12),
                            ),
                            trailing: Switch(
                              value: player.subtitlesVisible,
                              activeThumbColor: const Color(0xFF6C63FF),
                              onChanged: (_) => player.toggleSubtitlesVisible(),
                            ),
                          ),
                          const Divider(color: Colors.white12, height: 1),
                          ListTile(
                            leading: const Icon(Icons.delete_outline_rounded, color: Colors.red),
                            title: const Text(
                              'Clear subtitles',
                              style: TextStyle(color: Colors.red),
                            ),
                            onTap: () {
                              player.clearGeneratedSubtitles();
                              Navigator.pop(context);
                            },
                          ),
                        ],
                      ),
                    ),
                    const SizedBox(height: 12),
                  ],

                  // ── Options ──────────────────────────────────────────────────
                  Container(
                    decoration: BoxDecoration(
                      color: Colors.white10,
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: Column(
                      children: [
                        ListTile(
                          leading: const Icon(Icons.folder_open_outlined, color: Colors.white70),
                          title: const Text(
                            'Load from file (.srt)',
                            style: TextStyle(color: Colors.white),
                          ),
                          trailing: const Icon(Icons.chevron_right, color: Colors.white38),
                          onTap: onLoadFile,
                        ),
                        const Divider(color: Colors.white12, height: 1),
                        ListTile(
                          leading: const Icon(Icons.auto_awesome_outlined, color: Color(0xFF6C63FF)),
                          title: const Text(
                            'Generate AI subtitles',
                            style: TextStyle(color: Colors.white),
                          ),
                          subtitle: const Text(
                            'Uses Whisper AI on your backend server',
                            style: TextStyle(color: Colors.white38, fontSize: 11),
                          ),
                          trailing: const Icon(Icons.chevron_right, color: Colors.white38),
                          onTap: onGenerateAI,
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 8),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}

class _SeekButton extends StatelessWidget {
  final IconData icon;
  final VoidCallback onTap;

  const _SeekButton({required this.icon, required this.onTap});

  @override
  Widget build(BuildContext context) {
    return Material(
      color: Colors.transparent,
      child: InkWell(
        onTap: onTap,
        onDoubleTap: onTap,
        borderRadius: BorderRadius.circular(32),
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 8),
          child: Icon(
            icon,
            color: Colors.white,
            size: 36,
            shadows: const [Shadow(blurRadius: 8)],
          ),
        ),
      ),
    );
  }
}

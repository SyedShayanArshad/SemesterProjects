import 'dart:async';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:media_kit/media_kit.dart';
import 'package:wakelock_plus/wakelock_plus.dart';
import '../../data/models/video_model.dart';
import '../../data/models/bookmark_model.dart';
import '../../data/models/playback_history_item.dart';
import '../../data/models/player_settings.dart';
import '../../data/services/history_service.dart';
import '../../data/services/subtitle_service.dart';
import '../../data/services/bookmark_service.dart';

class PlayerProvider extends ChangeNotifier {
  final HistoryService _history;
  final BookmarkService _bookmarkService = BookmarkService();

  bool _disposed = false;
  int _openRequestId = 0;

  // ─── Core player ───────────────────────────────────────────────────────────
  Player? _player;
  Player get player => _player!;
  bool get hasPlayer => _player != null;

  // ─── Playlist ──────────────────────────────────────────────────────────────
  List<VideoModel> _playlist = [];
  int _currentIndex = 0;

  List<VideoModel> get playlist => _playlist;
  int get currentIndex => _currentIndex;
  VideoModel? get currentVideo =>
      _playlist.isEmpty ? null : _playlist[_currentIndex];

  // ─── Playback state ────────────────────────────────────────────────────────
  bool _isPlaying = false;
  Duration _position = Duration.zero;
  Duration _duration = Duration.zero;
  double _playbackSpeed = 1.0;
  double _playerVolume = 100.0;
  bool _isBuffering = false;
  bool _isCompleted = false;

  bool get isPlaying => _isPlaying;
  Duration get position => _position;
  Duration get duration => _duration;
  double get playbackSpeed => _playbackSpeed;
  bool get isBuffering => _isBuffering;
  bool get isCompleted => _isCompleted;
  double get progress =>
      _duration.inMilliseconds > 0
          ? _position.inMilliseconds / _duration.inMilliseconds
          : 0.0;

  // ─── Settings ──────────────────────────────────────────────────────────────
  bool _loopVideo = false;
  bool _shufflePlaylist = false;
  bool _autoPlayNext = true;
  bool _isLocked = false;
  bool _controlsVisible = true;

  bool get loopVideo => _loopVideo;
  bool get shufflePlaylist => _shufflePlaylist;
  bool get autoPlayNext => _autoPlayNext;
  bool get isLocked => _isLocked;
  bool get controlsVisible => _controlsVisible;

  // ─── A-B Repeat ────────────────────────────────────────────────────────────
  Duration? _abStart;
  Duration? _abEnd;
  bool _abRepeatActive = false;
  Timer? _abTimer;

  Duration? get abStart => _abStart;
  Duration? get abEnd => _abEnd;
  bool get abRepeatActive => _abRepeatActive;

  // ─── Sleep timer ───────────────────────────────────────────────────────────
  Timer? _sleepTimer;
  Duration? _sleepRemaining;
  Duration? get sleepRemaining => _sleepRemaining;

  // ─── Subtitle ──────────────────────────────────────────────────────────────
  String? _externalSubtitlePath;
  final List<SubtitleCue> _subtitleCues = [];
  bool _subtitlesVisible = true;
  final List<String> _availableSubtitleTracks = [];
  final int _selectedSubtitleTrack = -1;
  String? get externalSubtitlePath => _externalSubtitlePath;
  List<SubtitleCue> get subtitleCues => _subtitleCues;
  bool get subtitlesVisible => _subtitlesVisible;
  List<String> get availableSubtitleTracks => _availableSubtitleTracks;
  int get selectedSubtitleTrack => _selectedSubtitleTrack;

  // ─── Dubbed playback ───────────────────────────────────────────────────────
  String? _dubbedPath;
  bool get isDubbed => _dubbedPath != null;

  // ─── Bookmarks ─────────────────────────────────────────────────────────────
  final List<BookmarkModel> _bookmarks = [];
  List<BookmarkModel> get bookmarks =>
      _bookmarks.where((b) => b.videoPath == currentVideo?.path).toList();

  // ─── Video display ────────────────────────────────────────────────────────
  BoxFit _videoFit = BoxFit.contain;
  double _scale = 1.0;
  Future<String?> Function()? _screenshotCallback;

  BoxFit get videoFit => _videoFit;
  double get scale => _scale;

  String get videoFitName {
    switch (_videoFit) {
      case BoxFit.contain: return 'Fit';
      case BoxFit.cover: return 'Crop';
      case BoxFit.fill: return 'Stretch';
      case BoxFit.fitWidth: return 'Width';
      case BoxFit.fitHeight: return 'Height';
      default: return 'Fit';
    }
  }

  // ─── Controls auto-hide ────────────────────────────────────────────────────
  Timer? _hideTimer;

  // ─── Subscriptions ─────────────────────────────────────────────────────────
  final List<StreamSubscription> _subscriptions = [];

  PlayerProvider(this._history) {
    unawaited(_loadBookmarks());
  }

  Future<void> _loadBookmarks() async {
    try {
      final loaded = await _bookmarkService.getBookmarks();
      _bookmarks
        ..clear()
        ..addAll(loaded);
      notifyListeners();
    } catch (_) {
      // Ignore
    }
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Initialization
  // ══════════════════════════════════════════════════════════════════════════

  void initPlayer(PlayerSettings settings) {
    _disposed = false;
    _openRequestId++;
    _player?.dispose();
    _player = Player();
    _playerVolume = _player!.state.volume;
    _loopVideo = settings.loopVideo;
    _shufflePlaylist = settings.shufflePlaylist;
    _autoPlayNext = settings.autoPlayNext;
    _playbackSpeed = settings.playbackSpeed;
    _listenToPlayer();
  }

  void _listenToPlayer() {
    final p = _player!;

    _subscriptions.add(p.stream.playing.listen((playing) {
      _isPlaying = playing;
      if (playing) {
        WakelockPlus.enable();
      } else {
        WakelockPlus.disable();
      }
      notifyListeners();
    }));

    _subscriptions.add(p.stream.position.listen((pos) {
      _position = pos;
      _checkAbRepeat();
      notifyListeners();
    }));

    _subscriptions.add(p.stream.duration.listen((dur) {
      _duration = dur;
      notifyListeners();
    }));

    _subscriptions.add(p.stream.volume.listen((volume) {
      _playerVolume = volume;
      notifyListeners();
    }));

    _subscriptions.add(p.stream.buffering.listen((buffering) {
      _isBuffering = buffering;
      notifyListeners();
    }));

    _subscriptions.add(p.stream.completed.listen((completed) {
      if (completed) {
        _isCompleted = true;
        _onVideoCompleted();
        notifyListeners();
      }
    }));
  }

  Future<void> _onVideoCompleted() async {
    if (_loopVideo) {
      await _player?.seek(Duration.zero);
      await _player?.play();
      return;
    }
    if (_autoPlayNext && _playlist.length > 1) {
      if (_shufflePlaylist) {
        final next = (List.generate(_playlist.length, (i) => i)
          ..remove(_currentIndex)
          ..shuffle())
            .first;
        await playAt(next);
      } else {
        await playNext();
      }
    }
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Playback control
  // ══════════════════════════════════════════════════════════════════════════

  Future<void> openPlaylist(
    List<VideoModel> playlist, {
    int startIndex = 0,
    Duration? startPosition,
    PlayerSettings? settings,
  }) async {
    _playlist = playlist;
    _currentIndex = startIndex;
    await _openCurrent(startPosition: startPosition);
  }

  Future<void> _openCurrent({Duration? startPosition}) async {
    final video = currentVideo;
    if (video == null || _player == null) return;

    final requestId = ++_openRequestId;
    
    // Clear _dubbedPath initially for this new video playback
    _dubbedPath = null;
    _subtitleCues.clear();

    // Load any previously generated assets (subtitles / dubbed video) for this video
    try {
      final gen = await _history.getGeneratedAssets(video.path);
      if (gen != null) {
        if (gen['srt'] != null) {
          try {
            loadExternalSubtitle(gen['srt']!);
          } catch (_) {}
        }
        if (gen['dubbed'] != null) {
          try {
            final f = File(gen['dubbed']!);
            if (await f.exists()) {
              _dubbedPath = gen['dubbed'];
            }
          } catch (_) {}
        }
      }
    } catch (_) {}

    final sourcePath = _dubbedPath ?? video.path;

    _isCompleted = false;
    final media = Media(Uri.file(sourcePath).toString());
    await _player!.open(media, play: false);
    await _player!.setRate(_playbackSpeed);
    await _player!.setVolume(_playerVolume <= 0.0 ? 100.0 : _playerVolume);

    if (startPosition != null && startPosition.inSeconds > 5) {
      // Seek after a short delay for the player to initialize.
      // Guard against the player being disposed / a newer open request.
      await Future.delayed(const Duration(milliseconds: 500));
      if (_disposed || requestId != _openRequestId) return;
      await _player?.seek(startPosition);
      if (_disposed || requestId != _openRequestId) return;
      await _player?.play();
    } else {
      await _player!.play();
    }
    notifyListeners();
  }

  /// Stop playback immediately (useful before leaving the player screen).
  Future<void> stopNow() async {
    try {
      await _player?.pause();
    } catch (_) {}
  }

  Future<void> playPause() async {
    await _player?.playOrPause();
  }

  Future<void> play() async {
    await _player?.play();
  }

  Future<void> pause() async {
    await _player?.pause();
  }

  Future<void> seekTo(Duration position) async {
    await _player?.seek(position);
  }

  Future<void> seekForward([int seconds = 10]) async {
    final newPos = _position + Duration(seconds: seconds);
    await seekTo(newPos > _duration ? _duration : newPos);
  }

  Future<void> seekBackward([int seconds = 10]) async {
    final newPos = _position - Duration(seconds: seconds);
    await seekTo(newPos < Duration.zero ? Duration.zero : newPos);
  }

  Future<void> playNext() async {
    if (_playlist.isEmpty) return;
    final next = (_currentIndex + 1) % _playlist.length;
    await playAt(next);
  }

  Future<void> playPrevious() async {
    if (_playlist.isEmpty) return;
    // If more than 3 seconds played, restart; else go to previous
    if (_position.inSeconds > 3) {
      await seekTo(Duration.zero);
      return;
    }
    final prev = (_currentIndex - 1 + _playlist.length) % _playlist.length;
    await playAt(prev);
  }

  Future<void> playAt(int index) async {
    if (index < 0 || index >= _playlist.length) return;
    await _saveCurrentPosition();
    _currentIndex = index;
    await _openCurrent();
  }

  Future<void> setSpeed(double speed) async {
    _playbackSpeed = speed;
    await _player?.setRate(speed);
    notifyListeners();
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Display / Screen
  // ══════════════════════════════════════════════════════════════════════════

  void toggleControls() {
    _controlsVisible = !_controlsVisible;
    notifyListeners();
    if (_controlsVisible) _scheduleHide();
  }

  void showControls() {
    _controlsVisible = true;
    notifyListeners();
    _scheduleHide();
  }

  void _scheduleHide([int seconds = 3]) {
    _hideTimer?.cancel();
    _hideTimer = Timer(Duration(seconds: seconds), () {
      if (_isPlaying) {
        _controlsVisible = false;
        notifyListeners();
      }
    });
  }

  void toggleLock() {
    _isLocked = !_isLocked;
    notifyListeners();
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Video display & zoom
  // ══════════════════════════════════════════════════════════════════════════

  void cycleVideoFit() {
    const fits = [
      BoxFit.contain,
      BoxFit.cover,
      BoxFit.fill,
      BoxFit.fitWidth,
      BoxFit.fitHeight,
    ];
    final idx = fits.indexOf(_videoFit);
    _videoFit = fits[(idx + 1) % fits.length];
    notifyListeners();
  }

  void setVideoFit(BoxFit fit) {
    _videoFit = fit;
    notifyListeners();
  }

  void setScale(double s) {
    _scale = s.clamp(0.3, 5.0);
    notifyListeners();
  }

  void resetScale() {
    _scale = 1.0;
    notifyListeners();
  }

  // ── Screenshot ─────────────────────────────────────────────────────────────
  void setScreenshotCallback(Future<String?> Function() cb) {
    _screenshotCallback = cb;
  }

  Future<String?> takeScreenshot() async {
    return _screenshotCallback?.call();
  }

  // ── Frame stepping ─────────────────────────────────────────────────────────
  Future<void> stepFrame() async {
    // Advance ~1 frame at 24fps (42ms)
    final newPos = _position + const Duration(milliseconds: 42);
    await seekTo(newPos > _duration ? _duration : newPos);
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Playback options
  // ══════════════════════════════════════════════════════════════════════════

  void setLoop(bool loop) {
    _loopVideo = loop;
    notifyListeners();
  }

  void setShuffle(bool shuffle) {
    _shufflePlaylist = shuffle;
    notifyListeners();
  }

  void setAutoPlayNext(bool auto) {
    _autoPlayNext = auto;
    notifyListeners();
  }

  // ══════════════════════════════════════════════════════════════════════════
  // A-B Repeat
  // ══════════════════════════════════════════════════════════════════════════

  void setAbStart() {
    _abStart = _position;
    _abEnd = null;
    _abRepeatActive = false;
    _abTimer?.cancel();
    notifyListeners();
  }

  void setAbEnd() {
    if (_abStart == null) return;
    _abEnd = _position;
    if (_abEnd! <= _abStart!) {
      _abEnd = null;
      return;
    }
    _abRepeatActive = true;
    notifyListeners();
  }

  void clearAbRepeat() {
    _abStart = null;
    _abEnd = null;
    _abRepeatActive = false;
    _abTimer?.cancel();
    notifyListeners();
  }

  void _checkAbRepeat() {
    if (!_abRepeatActive || _abStart == null || _abEnd == null) return;
    if (_position >= _abEnd!) {
      _player?.seek(_abStart!);
    }
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Sleep timer
  // ══════════════════════════════════════════════════════════════════════════

  void setSleepTimer(Duration duration) {
    _sleepTimer?.cancel();
    _sleepRemaining = duration;
    notifyListeners();
    _sleepTimer = Timer.periodic(const Duration(seconds: 1), (t) {
      if (_sleepRemaining == null || _sleepRemaining! <= Duration.zero) {
        _player?.pause();
        _sleepTimer?.cancel();
        _sleepRemaining = null;
        return;
      }
      _sleepRemaining = _sleepRemaining! - const Duration(seconds: 1);
      notifyListeners();
    });
  }

  void cancelSleepTimer() {
    _sleepTimer?.cancel();
    _sleepRemaining = null;
    notifyListeners();
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Subtitles
  // ══════════════════════════════════════════════════════════════════════════

  void loadExternalSubtitle(String path) {
    _externalSubtitlePath = path;
    notifyListeners();
    
    // Read and parse SRT to use our custom SubtitleOverlay with standard size
    try {
      final file = File(path);
      if (file.existsSync()) {
        final content = file.readAsStringSync();
        final cues = SubtitleService.parseSrt(content);
        if (cues.isNotEmpty) {
          loadGeneratedSubtitles(cues);
          return; // Skip native media_kit if successfully parsed
        }
      }
    } catch (_) {}

    // Fallback to media_kit native track if parsing fails
    try {
      _player?.setSubtitleTrack(SubtitleTrack.uri(
        Uri.file(path).toString(),
        title: path.split(Platform.pathSeparator).last,
      ));
    } catch (_) {}
  }

  void loadGeneratedSubtitles(List<SubtitleCue> cues) {
    _subtitleCues
      ..clear()
      ..addAll(cues);
    _subtitlesVisible = true;
    notifyListeners();
  }

  void toggleSubtitlesVisible() {
    _subtitlesVisible = !_subtitlesVisible;
    notifyListeners();
  }

  void clearGeneratedSubtitles() {
    _subtitleCues.clear();
    _subtitlesVisible = true;
    notifyListeners();
  }

  void playDubbedVersion(String path) {
    _dubbedPath = path;
    notifyListeners();
    unawaited(_switchSource(path));
  }

  void restoreOriginal() {
    _dubbedPath = null;
    notifyListeners();
    final video = currentVideo;
    final originalPath = video?.path;
    if (originalPath == null) return;

    unawaited(_switchSource(originalPath));
  }

  Future<void> _switchSource(String sourcePath) async {
    final player = _player;
    if (player == null) return;

    final shouldResume = _isPlaying;
    final resumePosition = _position;
    final resumeVolume = _playerVolume <= 0.0 ? 100.0 : _playerVolume;
    final requestId = ++_openRequestId;

    try {
      await player.stop();
      await player.open(Media(Uri.file(sourcePath).toString()), play: false);
      if (_disposed || requestId != _openRequestId) return;

      await player.setAudioDevice(AudioDevice.auto());
      await player.setAudioTrack(AudioTrack.auto());
      await player.setRate(_playbackSpeed);
      await player.setVolume(resumeVolume.clamp(0.0, 100.0).toDouble());

      if (resumePosition > Duration.zero) {
        await player.seek(resumePosition);
      }

      if (shouldResume && !_disposed && requestId == _openRequestId) {
        await player.play();
      }
    } catch (_) {
      // Keep the current player state if the source switch fails.
    }
  }

  // ══════════════════════════════════════════════════════════════════════════
  // Bookmarks
  // ══════════════════════════════════════════════════════════════════════════

  void addBookmark(String label) {
    if (currentVideo == null) return;
    final bookmark = BookmarkModel(
      id: '${DateTime.now().microsecondsSinceEpoch}-${DateTime.now().hashCode}',
      videoPath: currentVideo!.path,
      videoName: currentVideo!.name,
      position: _position,
      label: label,
      createdAt: DateTime.now(),
    );
    _bookmarks.insert(0, bookmark);
    notifyListeners();
    unawaited(_bookmarkService.add(bookmark));
  }

  void removeBookmark(String id) {
    _bookmarks.removeWhere((b) => b.id == id);
    notifyListeners();
    unawaited(_bookmarkService.remove(id));
  }

  Future<void> seekToBookmark(BookmarkModel bookmark) async {
    await seekTo(bookmark.position);
  }

  // ══════════════════════════════════════════════════════════════════════════
  // History
  // ══════════════════════════════════════════════════════════════════════════

  Future<void> _saveCurrentPosition() async {
    final video = currentVideo;
    if (video == null) return;
    await _history.savePosition(video.path, _position);
    await _history.addOrUpdate(PlaybackHistoryItem(
      videoPath: video.path,
      videoName: video.name,
      lastPosition: _position,
      totalDuration: _duration,
      lastPlayed: DateTime.now(),
    ));
  }

  Future<void> savePositionNow() => _saveCurrentPosition();

  // ══════════════════════════════════════════════════════════════════════════
  // Resource management
  // ══════════════════════════════════════════════════════════════════════════

  @override
  void dispose() {
    _disposed = true;
    _openRequestId++;

    // Stop audio ASAP. Don't await inside dispose.
    unawaited(stopNow());

    // Persist position best-effort.
    unawaited(_saveCurrentPosition());
    _hideTimer?.cancel();
    _sleepTimer?.cancel();
    _abTimer?.cancel();
    for (final sub in _subscriptions) {
      unawaited(sub.cancel());
    }
    _subscriptions.clear();
    final p = _player;
    _player = null;
    if (p != null) {
      unawaited(p.dispose());
    }
    WakelockPlus.disable();
    super.dispose();
  }
}

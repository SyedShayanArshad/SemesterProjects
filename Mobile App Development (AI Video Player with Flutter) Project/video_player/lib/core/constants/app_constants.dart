class AppConstants {
  AppConstants._();

  static const String appName = 'Video Player';

  /// Supported video file extensions
  static const List<String> supportedVideoExtensions = [
    'mp4', 'mkv', 'avi', 'mov', 'flv', 'webm', 'wmv', 'm4v',
    'mpg', 'mpeg', '3gp', 'ts', 'm2ts', 'vob', 'ogv', 'rm', 'rmvb',
  ];

  /// Supported subtitle extensions
  static const List<String> supportedSubtitleExtensions = [
    'srt', 'ass', 'ssa', 'sub', 'vtt', 'lrc',
  ];

  static const List<double> speedOptions = [0.25, 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0];

  static const int seekSeconds = 10;
  static const int longSeekSeconds = 30;

  static const String historyKey = 'playback_history';
  static const String bookmarksKey = 'video_bookmarks';
  static const String settingsKey = 'player_settings';
  static const String lastPositionPrefix = 'pos_';

  static const int maxHistoryItems = 100;
}

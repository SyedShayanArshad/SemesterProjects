class PlaybackHistoryItem {
  final String videoPath;
  final String videoName;
  final Duration lastPosition;
  final Duration? totalDuration;
  final DateTime lastPlayed;

  const PlaybackHistoryItem({
    required this.videoPath,
    required this.videoName,
    required this.lastPosition,
    this.totalDuration,
    required this.lastPlayed,
  });

  double get progress {
    if (totalDuration == null || totalDuration!.inSeconds == 0) return 0;
    return lastPosition.inSeconds / totalDuration!.inSeconds;
  }

  Map<String, dynamic> toJson() => {
    'videoPath': videoPath,
    'videoName': videoName,
    'lastPositionMs': lastPosition.inMilliseconds,
    'totalDurationMs': totalDuration?.inMilliseconds,
    'lastPlayed': lastPlayed.millisecondsSinceEpoch,
  };

  factory PlaybackHistoryItem.fromJson(Map<String, dynamic> json) =>
      PlaybackHistoryItem(
        videoPath: json['videoPath'] as String,
        videoName: json['videoName'] as String,
        lastPosition: Duration(milliseconds: json['lastPositionMs'] as int),
        totalDuration: json['totalDurationMs'] != null
            ? Duration(milliseconds: json['totalDurationMs'] as int)
            : null,
        lastPlayed: DateTime.fromMillisecondsSinceEpoch(json['lastPlayed'] as int),
      );
}

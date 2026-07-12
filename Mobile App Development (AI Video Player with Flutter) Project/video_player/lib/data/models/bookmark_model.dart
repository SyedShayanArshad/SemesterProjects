class BookmarkModel {
  final String id;
  final String videoPath;
  final String videoName;
  final Duration position;
  final String label;
  final DateTime createdAt;

  const BookmarkModel({
    required this.id,
    required this.videoPath,
    required this.videoName,
    required this.position,
    required this.label,
    required this.createdAt,
  });

  Map<String, dynamic> toJson() => {
    'id': id,
    'videoPath': videoPath,
    'videoName': videoName,
    'positionMs': position.inMilliseconds,
    'label': label,
    'createdAt': createdAt.millisecondsSinceEpoch,
  };

  factory BookmarkModel.fromJson(Map<String, dynamic> json) => BookmarkModel(
    id: json['id'] as String,
    videoPath: json['videoPath'] as String,
    videoName: json['videoName'] as String,
    position: Duration(milliseconds: json['positionMs'] as int),
    label: json['label'] as String,
    createdAt: DateTime.fromMillisecondsSinceEpoch(json['createdAt'] as int),
  );
}

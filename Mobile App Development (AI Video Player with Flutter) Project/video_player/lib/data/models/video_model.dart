import 'dart:io';

class VideoModel {
  final String id;
  final String path;
  final String name;
  final String extension;
  final int size; // bytes
  final DateTime dateAdded;
  final Duration? duration;
  final String? thumbnailPath;
  final String folder;

  const VideoModel({
    required this.id,
    required this.path,
    required this.name,
    required this.extension,
    required this.size,
    required this.dateAdded,
    this.duration,
    this.thumbnailPath,
    required this.folder,
  });

  factory VideoModel.fromFile(File file) {
    final path = file.path;
    final name = path.split(Platform.pathSeparator).last;
    final ext = name.contains('.') ? name.split('.').last.toLowerCase() : '';
    final folder = path.substring(0, path.lastIndexOf(Platform.pathSeparator));
    final stat = file.statSync();
    return VideoModel(
      id: path,
      path: path,
      name: name.contains('.') ? name.substring(0, name.lastIndexOf('.')) : name,
      extension: ext,
      size: stat.size,
      dateAdded: stat.modified,
      folder: folder,
    );
  }

  VideoModel copyWith({Duration? duration, String? thumbnailPath}) {
    return VideoModel(
      id: id,
      path: path,
      name: name,
      extension: extension,
      size: size,
      dateAdded: dateAdded,
      duration: duration ?? this.duration,
      thumbnailPath: thumbnailPath ?? this.thumbnailPath,
      folder: folder,
    );
  }

  String get displayName => name;
  String get fullName => '$name.$extension';

  String get sizeFormatted {
    if (size < 1024) return '${size}B';
    if (size < 1024 * 1024) return '${(size / 1024).toStringAsFixed(1)} KB';
    if (size < 1024 * 1024 * 1024) return '${(size / (1024 * 1024)).toStringAsFixed(1)} MB';
    return '${(size / (1024 * 1024 * 1024)).toStringAsFixed(2)} GB';
  }

  Map<String, dynamic> toJson() => {
    'id': id,
    'path': path,
    'name': name,
    'extension': extension,
    'size': size,
    'dateAdded': dateAdded.millisecondsSinceEpoch,
    'durationMs': duration?.inMilliseconds,
    'thumbnailPath': thumbnailPath,
    'folder': folder,
  };

  factory VideoModel.fromJson(Map<String, dynamic> json) => VideoModel(
    id: json['id'] as String,
    path: json['path'] as String,
    name: json['name'] as String,
    extension: json['extension'] as String,
    size: json['size'] as int,
    dateAdded: DateTime.fromMillisecondsSinceEpoch(json['dateAdded'] as int),
    duration: json['durationMs'] != null
        ? Duration(milliseconds: json['durationMs'] as int)
        : null,
    thumbnailPath: json['thumbnailPath'] as String?,
    folder: json['folder'] as String,
  );
}

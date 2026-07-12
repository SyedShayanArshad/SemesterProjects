import 'dart:io';
import 'package:path/path.dart' as p;
import 'package:photo_manager/photo_manager.dart';
import '../models/video_model.dart';
import '../../core/constants/app_constants.dart';

class MediaScannerService {
  /// Scan device using MediaStore (Android) / Photos framework (iOS).
  /// This properly works with scoped storage on Android 10+.
  Future<MediaScanResult> scanDevice() async {
    // Request permission via photo_manager
    final permitted = await _requestPermission();
    if (!permitted) {
      return MediaScanResult(videos: [], hasPermission: false);
    }

    final videos = <VideoModel>[];

    // Fetch all video albums from MediaStore
    final albums = await PhotoManager.getAssetPathList(
      type: RequestType.video,
      hasAll: true,
      onlyAll: false,
    );

    for (final album in albums) {
      final count = await album.assetCountAsync;
      int loaded = 0;
      const pageSize = 100;
      while (loaded < count) {
        final assets = await album.getAssetListPaged(page: loaded ~/ pageSize, size: pageSize);
        for (final asset in assets) {
          final file = await asset.file;
          if (file == null) continue;
          final ext = p.extension(file.path).toLowerCase().replaceAll('.', '');
          if (!AppConstants.supportedVideoExtensions.contains(ext)) continue;
          final video = VideoModel.fromFile(file).copyWith(
            duration: asset.videoDuration,
          );
          // Deduplicate by path
          if (!videos.any((v) => v.path == video.path)) {
            videos.add(video);
          }
        }
        loaded += assets.length;
        if (assets.isEmpty) break;
      }
    }

    return MediaScanResult(videos: videos, hasPermission: true);
  }

  /// Fallback: scan a specific directory path manually (for file manager picks).
  Future<List<VideoModel>> scanDirectory(String directoryPath) async {
    final dir = Directory(directoryPath);
    if (!await dir.exists()) return [];

    final videos = <VideoModel>[];
    try {
      await for (final entity in dir.list(recursive: true, followLinks: false)) {
        if (entity is File) {
          final ext = p.extension(entity.path).toLowerCase().replaceAll('.', '');
          if (AppConstants.supportedVideoExtensions.contains(ext)) {
            try {
              videos.add(VideoModel.fromFile(entity));
            } catch (_) {}
          }
        }
      }
    } catch (_) {}
    return videos;
  }

  Future<bool> _requestPermission() async {
    final result = await PhotoManager.requestPermissionExtend();
    return result.isAuth;
  }

  /// Group videos by folder
  Map<String, List<VideoModel>> groupByFolder(List<VideoModel> videos) {
    final map = <String, List<VideoModel>>{};
    for (final v in videos) {
      map.putIfAbsent(v.folder, () => []).add(v);
    }
    return map;
  }
}

class MediaScanResult {
  final List<VideoModel> videos;
  final bool hasPermission;
  const MediaScanResult({required this.videos, required this.hasPermission});
}


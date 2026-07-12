import 'dart:io';
import 'package:path_provider/path_provider.dart';
import 'package:video_thumbnail/video_thumbnail.dart';

/// Generates and caches video thumbnail files on disk.
class ThumbnailService {
  ThumbnailService._();
  static final ThumbnailService instance = ThumbnailService._();

  // In-memory cache: videoPath → thumbnailPath (or null if generation failed)
  final Map<String, String?> _cache = {};

  /// Returns the cached thumbnail file path for [videoPath], generating it if
  /// necessary. Returns `null` if generation fails.
  Future<String?> getThumbnail(String videoPath) async {
    if (_cache.containsKey(videoPath)) {
      return _cache[videoPath];
    }

    try {
      final dir = await getTemporaryDirectory();
      final thumbDir = Directory('${dir.path}/thumbnails');
      if (!await thumbDir.exists()) await thumbDir.create(recursive: true);

      // Use a hashed filename so each video gets its own stable thumbnail
      final safeName = videoPath.hashCode.abs().toString();
      final thumbPath = '${thumbDir.path}/$safeName.jpg';

      // Return existing file if already generated in a previous session
      if (File(thumbPath).existsSync()) {
        _cache[videoPath] = thumbPath;
        return thumbPath;
      }

      final result = await VideoThumbnail.thumbnailFile(
        video: videoPath,
        thumbnailPath: thumbDir.path,
        imageFormat: ImageFormat.JPEG,
        maxWidth: 320,
        quality: 60,
      );

      _cache[videoPath] = result;
      return result;
    } catch (_) {
      _cache[videoPath] = null;
      return null;
    }
  }
}

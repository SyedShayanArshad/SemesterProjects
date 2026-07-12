import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;
import 'package:path_provider/path_provider.dart';
import 'package:ffmpeg_kit_flutter_new/ffmpeg_kit.dart';
import 'package:ffmpeg_kit_flutter_new/return_code.dart';

import '../../core/constants/backend_constants.dart';
import 'broadcast_service.dart';
import 'processing_tracker.dart';
import 'history_service.dart';

/// Language entry returned from /dub-languages.
class DubLanguage {
  final String code;
  final String name;
  const DubLanguage({required this.code, required this.name});
}

/// Result returned after dubbing completes.
class DubResult {
  /// Path to the dubbed video file (original video + cloned audio track).
  final String dubbedVideoPath;
  const DubResult({required this.dubbedVideoPath});
}

class DubService {
  static const String _baseUrl = BackendConstants.baseUrl;

  /// Fetch the XTTS-v2 supported languages from the backend.
  static Future<List<DubLanguage>> fetchDubLanguages() async {
    // New backend doesn't expose a languages endpoint; keep a small static list.
    return const [
      DubLanguage(code: 'en', name: 'English'),
      DubLanguage(code: 'ur', name: 'Urdu'),
      DubLanguage(code: 'hi', name: 'Hindi'),
      DubLanguage(code: 'ar', name: 'Arabic'),
      DubLanguage(code: 'fr', name: 'French'),
      DubLanguage(code: 'de', name: 'German'),
      DubLanguage(code: 'es', name: 'Spanish'),
      DubLanguage(code: 'it', name: 'Italian'),
      DubLanguage(code: 'pt', name: 'Portuguese'),
      DubLanguage(code: 'ru', name: 'Russian'),
      DubLanguage(code: 'zh', name: 'Chinese'),
      DubLanguage(code: 'ja', name: 'Japanese'),
      DubLanguage(code: 'ko', name: 'Korean'),
    ];
  }

  /// Full pipeline:
  ///  1. Extract audio from [videoPath] → temp WAV
  ///  2. POST to /api/v1/audio/process → get dubbed_audio_url
  ///  3. Download dubbed audio (mp3)
  ///  4. FFmpeg: replace audio track in original video → temp MP4
  ///  5. Return path to the dubbed video.
  /// 
  /// If [task] is provided, progress will be broadcasted via BroadcastService.
  static Future<DubResult> generateDub({
    required String videoPath,
    required String targetLanguage,
    String sourceLanguage = 'auto',
    void Function(String status)? onStatusUpdate,
    void Function(int percent)? onProgressUpdate,
    ProcessingTask? task,
  }) async {
    final tmpDir = await getTemporaryDirectory();
    final ts = DateTime.now().millisecondsSinceEpoch;
    final audioPath = '${tmpDir.path}/dub_audio_$ts.wav';
    final dubbedAudioPath = '${tmpDir.path}/dubbed_$ts.mp3';
    final dubbedVideoPath = '${tmpDir.path}/dubbed_video_$ts.mp4';

    try {
      // ── Step 1: Extract audio ──────────────────────────────────────────
      final extractMsg = 'Extracting audio…';
      onStatusUpdate?.call(extractMsg);
      onProgressUpdate?.call(2);
      task?.updateProgress(
        progress: 0.05,
        status: ProcessingStatus.extracting,
        message: extractMsg,
      );
      await _extractAudio(videoPath, audioPath);

      // ── Step 2: Upload to backend ─────────────────────────────────────
      final processMsg = 'Generating dubbed audio…';
      onStatusUpdate?.call(processMsg);
      onProgressUpdate?.call(10);
      task?.updateProgress(
        progress: 0.15,
        status: ProcessingStatus.processing,
        message: processMsg,
      );
      final dubbedUrl = await _requestDubbedAudioUrl(
        audioPath: audioPath,
        targetLanguage: targetLanguage,
        sourceLanguage: sourceLanguage,
      );

      // ── Step 3: Download dubbed audio ─────────────────────────────────
      final downloadMsg = 'Downloading dubbed audio…';
      onStatusUpdate?.call(downloadMsg);
      onProgressUpdate?.call(85);
      task?.updateProgress(
        progress: 0.70,
        status: ProcessingStatus.downloading,
        message: downloadMsg,
      );
      await _downloadFile(_resolveUrl(dubbedUrl), dubbedAudioPath);

      // ── Step 4: Mux dubbed audio into original video ──────────────────
      final mixMsg = 'Mixing audio into video…';
      onStatusUpdate?.call(mixMsg);
      onProgressUpdate?.call(97);
      task?.updateProgress(
        progress: 0.90,
        status: ProcessingStatus.mixing,
        message: mixMsg,
      );
      await _muxAudioIntoVideo(videoPath, dubbedAudioPath, dubbedVideoPath);

      onProgressUpdate?.call(100);
      task?.updateProgress(
        progress: 1.0,
        status: ProcessingStatus.completed,
        message: 'Dubbing completed successfully!',
      );

      // Persist the dubbed video into app documents so it survives app restarts
      String persistentDubbedPath = dubbedVideoPath;
      try {
        final docs = await getApplicationDocumentsDirectory();
        final genDir = Directory('${docs.path}/generated_assets');
        if (!await genDir.exists()) await genDir.create(recursive: true);
        final key = videoPath.hashCode;
        final dest = File('${genDir.path}/dubbed_$key.mp4');
        try {
          final src = File(dubbedVideoPath);
          if (await src.exists()) {
            await src.copy(dest.path);
            persistentDubbedPath = dest.path;
          }
        } catch (_) {}

        try {
          await HistoryService().saveGeneratedAssets(videoPath, dubbedPath: persistentDubbedPath);
        } catch (_) {}
      } catch (_) {}

      task?.complete(
        result: {
          'dubbedVideoPath': persistentDubbedPath,
          'targetLanguage': targetLanguage,
        },
      );
      return DubResult(dubbedVideoPath: persistentDubbedPath);
    } catch (e) {
      final exception = e is Exception ? e : Exception(e.toString());
      task?.error(
        errorMessage: e.toString().replaceFirst('Exception: ', ''),
        exception: exception,
      );
      rethrow;
    } finally {
      // Cleanup temp audio files (keep the dubbed video, caller deletes it)
      for (final p in [audioPath, dubbedAudioPath]) {
        try {
          final f = File(p);
          if (await f.exists()) await f.delete();
        } catch (_) {}
      }
    }
  }

  // ── Private helpers ─────────────────────────────────────────────────────

  static Future<void> _extractAudio(String videoPath, String outputPath) async {
    // Mono 16 kHz WAV – optimal for Whisper transcription
    final session = await FFmpegKit.execute(
      '-y -i "$videoPath" -vn -ac 1 -ar 16000 -acodec pcm_s16le "$outputPath"',
    );
    final rc = await session.getReturnCode();
    if (!ReturnCode.isSuccess(rc)) {
      final logs = await session.getAllLogsAsString();
      throw Exception('Audio extraction failed: $logs');
    }
  }

  static Future<String> _requestDubbedAudioUrl({
    required String audioPath,
    required String targetLanguage,
    required String sourceLanguage,
  }) async {
    final uri = Uri.parse('$_baseUrl/api/v1/audio/process');
    final request = http.MultipartRequest('POST', uri)
      ..fields['target_language'] = targetLanguage
      ..fields['source_language'] = sourceLanguage
      ..fields['model_size'] = 'base'
      ..files.add(await http.MultipartFile.fromPath('audio', audioPath));

    final streamed = await request.send().timeout(const Duration(minutes: 30));
    final body = await streamed.stream.bytesToString();
    if (streamed.statusCode < 200 || streamed.statusCode >= 300) {
      throw Exception('Server error ${streamed.statusCode}: $body');
    }
    final data = jsonDecode(body) as Map<String, dynamic>;
    final dubbedUrl = data['dubbed_audio_url'] as String?;
    if (dubbedUrl == null || dubbedUrl.isEmpty) {
      throw Exception('Backend did not return dubbed_audio_url');
    }
    return dubbedUrl;
  }

  static Uri _resolveUrl(String urlOrPath) {
    if (urlOrPath.startsWith('http://') || urlOrPath.startsWith('https://')) {
      return Uri.parse(urlOrPath);
    }
    return Uri.parse('$_baseUrl${urlOrPath.startsWith('/') ? '' : '/'}$urlOrPath');
  }

  static Future<void> _downloadFile(Uri uri, String savePath) async {
    final response = await http.get(uri).timeout(const Duration(minutes: 5));
    if (response.statusCode != 200) {
      throw Exception('Failed to download file: ${response.statusCode}');
    }
    await File(savePath).writeAsBytes(response.bodyBytes);
  }

  static Future<void> _muxAudioIntoVideo(
      String videoPath, String audioPath, String outputPath) async {
    // Replace the original audio track with the dubbed audio.
    // Boost volume by 3x and re-encode to AAC because MP3-in-MP4 can play on 
    // desktop but fail or mute on some mobile decoders.
    final session = await FFmpegKit.execute(
      '-y -i "$videoPath" -i "$audioPath" '
      '-c:v copy -map 0:v:0 -map 1:a:0 '
      '-af "loudnorm,volume=5.0" '
      '-c:a aac -b:a 192k -ac 2 -ar 44100 '
      '-movflags +faststart -shortest "$outputPath"',
    );
    final rc = await session.getReturnCode();
    if (!ReturnCode.isSuccess(rc)) {
      final logs = await session.getAllLogsAsString();
      throw Exception('FFmpeg mux failed: $logs');
    }
  }
}

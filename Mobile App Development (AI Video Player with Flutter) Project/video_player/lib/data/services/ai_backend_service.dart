import 'dart:convert';
import 'dart:io';

import 'package:ffmpeg_kit_flutter_new/ffmpeg_kit.dart';
import 'package:ffmpeg_kit_flutter_new/return_code.dart';
import 'package:http/http.dart' as http;
import 'package:path_provider/path_provider.dart';

import '../../core/constants/backend_constants.dart';
import 'firebase_user_data_service.dart';

class AiBackendProcessResult {
  final String requestId;
  final String? detectedLanguage;
  final String targetLanguage;

  final String originalText;
  final String translatedText;

  /// Local temp path where subtitles were downloaded.
  final String srtPath;

  /// Local temp path where dubbed audio was downloaded.
  final String dubbedAudioPath;

  const AiBackendProcessResult({
    required this.requestId,
    required this.detectedLanguage,
    required this.targetLanguage,
    required this.originalText,
    required this.translatedText,
    required this.srtPath,
    required this.dubbedAudioPath,
  });
}

class AiBackendService {
  /// Base URL of the Python FastAPI backend.
  /// - Android emulator  → use 'http://10.0.2.2:8000'
  /// - Physical device   → use your PC's LAN IP, e.g. 'http://192.168.1.5:8000'
  static const String baseUrl = BackendConstants.baseUrl;

  /// End-to-end helper for demo:
  ///  1) Extract mono 16k WAV from video (Whisper-friendly)
  ///  2) Upload to backend /api/v1/audio/process
  ///  3) Download generated subtitles + dubbed audio
  static Future<AiBackendProcessResult> processVideo({
    required String videoPath,
    required String targetLanguage,
    String sourceLanguage = 'auto',
    String modelSize = 'base',
    void Function(String status)? onStatusUpdate,
  }) async {
    final tmpDir = await getTemporaryDirectory();
    final ts = DateTime.now().millisecondsSinceEpoch;

    final extractedAudioPath = '${tmpDir.path}/ai_audio_$ts.wav';

    try {
      onStatusUpdate?.call('Extracting audio…');
      await _extractAudio(videoPath, extractedAudioPath);

      onStatusUpdate?.call('Uploading to AI backend…');
      final payload = await _processAudio(
        audioPath: extractedAudioPath,
        targetLanguage: targetLanguage,
        sourceLanguage: sourceLanguage,
        modelSize: modelSize,
      );

      final requestId = payload['request_id'] as String;
      final detectedLanguage = payload['detected_language'] as String?;
      final responseTarget = payload['target_language'] as String;
      final originalText = payload['original_text'] as String;
      final translatedText = payload['translated_text'] as String;

      final subtitleUrl = payload['subtitle_url'] as String;
      final dubbedAudioUrl = payload['dubbed_audio_url'] as String;

      onStatusUpdate?.call('Downloading subtitles…');
      final srtPath = '${tmpDir.path}/subtitles_$requestId.srt';
      await _downloadFile(_resolveUrl(subtitleUrl), srtPath);

      onStatusUpdate?.call('Downloading dubbed audio…');
      final dubbedPath = '${tmpDir.path}/dubbed_$requestId.mp3';
      await _downloadFile(_resolveUrl(dubbedAudioUrl), dubbedPath);

      // SAVE THIS BACKEND JOB IN FIREBASE AS PER REQUIREMENT
      try {
        final videoName = videoPath.split(Platform.pathSeparator).last;
        await FirebaseUserDataService().saveBackendJob(
          jobId: requestId,
          videoName: videoName,
          jobType: 'whisper_translation_tts',
          status: 'completed',
        );
      } catch (e) {
        // Ignore DB save errors to not interrupt the user's flow
      }

      return AiBackendProcessResult(
        requestId: requestId,
        detectedLanguage: detectedLanguage,
        targetLanguage: responseTarget,
        originalText: originalText,
        translatedText: translatedText,
        srtPath: srtPath,
        dubbedAudioPath: dubbedPath,
      );
    } finally {
      try {
        final f = File(extractedAudioPath);
        if (await f.exists()) await f.delete();
      } catch (_) {}
    }
  }

  static Uri _resolveUrl(String urlOrPath) {
    // Backend can return absolute URL or relative `/files/...`
    if (urlOrPath.startsWith('http://') || urlOrPath.startsWith('https://')) {
      return Uri.parse(urlOrPath);
    }
    return Uri.parse('$baseUrl${urlOrPath.startsWith('/') ? '' : '/'}$urlOrPath');
  }

  static Future<Map<String, dynamic>> _processAudio({
    required String audioPath,
    required String targetLanguage,
    required String sourceLanguage,
    required String modelSize,
  }) async {
    final uri = Uri.parse('$baseUrl/api/v1/audio/process');

    final request = http.MultipartRequest('POST', uri)
      ..fields['target_language'] = targetLanguage
      ..fields['source_language'] = sourceLanguage
      ..fields['model_size'] = modelSize
      ..files.add(await http.MultipartFile.fromPath('audio', audioPath));

    final streamed = await request.send().timeout(const Duration(minutes: 30));
    final body = await streamed.stream.bytesToString();

    if (streamed.statusCode < 200 || streamed.statusCode >= 300) {
      throw Exception('Backend error ${streamed.statusCode}: $body');
    }

    final decoded = jsonDecode(body);
    if (decoded is! Map<String, dynamic>) {
      throw Exception('Invalid backend response');
    }
    return decoded;
  }

  static Future<void> _downloadFile(Uri uri, String savePath) async {
    final response = await http.get(uri).timeout(const Duration(minutes: 5));
    if (response.statusCode != 200) {
      throw Exception('Download failed ${response.statusCode}: $uri');
    }
    await File(savePath).writeAsBytes(response.bodyBytes);
  }

  static Future<void> _extractAudio(String videoPath, String outputPath) async {
    // Mono 16 kHz WAV – optimal for Whisper transcription.
    final session = await FFmpegKit.execute(
      '-y -i "$videoPath" -vn -ac 1 -ar 16000 -acodec pcm_s16le "$outputPath"',
    );
    final rc = await session.getReturnCode();
    if (!ReturnCode.isSuccess(rc)) {
      final logs = await session.getAllLogsAsString();
      throw Exception('Audio extraction failed: $logs');
    }
  }
}

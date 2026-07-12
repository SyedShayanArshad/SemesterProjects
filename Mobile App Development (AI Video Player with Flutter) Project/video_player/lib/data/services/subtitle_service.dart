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

/// Result returned after subtitle generation completes.
class SubtitleResult {
  final String srtContent;
  final String detectedLanguage;
  final int segmentCount;

  const SubtitleResult({
    required this.srtContent,
    required this.detectedLanguage,
    required this.segmentCount,
  });
}

class SubtitleService {
  /// Base URL of the Python FastAPI backend.
  /// - Android emulator  → use 'http://10.0.2.2:8000'
  /// - Physical device   → use your PC's LAN IP, e.g. 'http://192.168.1.5:8000'
  ///   Find your IP with: ipconfig (Windows) or ifconfig (Mac/Linux)
  static const String _baseUrl = BackendConstants.baseUrl;

  /// Extract audio from [videoPath] into a temporary WAV file,
  /// send it to the backend, receive SRT content, save it as a
  /// temporary .srt file, then delete the audio file.
  ///
  /// Returns the path to the generated .srt file.
  /// 
  /// If [task] is provided, progress will be broadcasted via BroadcastService.
  //  Yahan `Future` aur `async` use ho raha hai. Iska faida ye hai 
  // ke jab tak subtitles backend se generate ho kar aate hain (jis me 1-2 minute lagte hain), 
  // tab tak hamari app (UI) freeze/hang nahi hoti aur user app me dusre kaam kar sakta hai.
  static Future<SubtitleResult> generateSubtitles({
    required String videoPath,
    required String language,
    String modelSize = 'base',
    void Function(String status)? onStatusUpdate,
    void Function(int percent)? onProgressUpdate,
    ProcessingTask? task,
  }) async {
    final tmpDir = await getTemporaryDirectory();
    final ts = DateTime.now().millisecondsSinceEpoch;
    final audioPath = '${tmpDir.path}/audio_$ts.wav';

    try {
      // ── Step 1: Extract audio ──────────────────────────────────────────
      final extractMsg = 'Extracting audio…';
      onStatusUpdate?.call(extractMsg);
      task?.updateProgress(
        progress: 0.1,
        status: ProcessingStatus.extracting,
        message: extractMsg,
      );
      await _extractAudio(videoPath, audioPath);

      // ── Step 2: Stream transcription from backend ─────────────────────
      final transcribeMsg = 'Transcribing with AI…';
      onStatusUpdate?.call(transcribeMsg);
      task?.updateProgress(
        progress: 0.2,
        status: ProcessingStatus.processing,
        message: transcribeMsg,
      );
      final result = await _transcribe(
        audioPath: audioPath,
        language: language,
        modelSize: modelSize,
        onProgressUpdate: onProgressUpdate,
        task: task,
        videoPath: videoPath,
      );

      task?.complete(
        result: {
          'detectedLanguage': result.detectedLanguage,
          'segmentCount': result.segmentCount,
        },
      );

      return result;
    } catch (e) {
      final exception = e is Exception ? e : Exception(e.toString());
      task?.error(
        errorMessage: e.toString().replaceFirst('Exception: ', ''),
        exception: exception,
      );
      rethrow;
    } finally {
      // ── Cleanup: always delete the temporary audio file ────────────────
      try {
        final audioFile = File(audioPath);
        if (await audioFile.exists()) {
          await audioFile.delete();
        }
      } catch (_) {}
    }
  }

  /// Use FFmpeg to extract the audio track from the video to a WAV file.
  //  Ye process bhi `async/await` par hai kyunke video se audio nikalna heavy kaam hai.
  // Hum event loop me `await FFmpegKit.execute()` karke wait karte hain taake main UI block na ho.
  static Future<void> _extractAudio(String videoPath, String outputPath) async {
    // -vn: no video, -ac 1: mono, -ar 16000: 16 kHz (optimal for Whisper)
    final session = await FFmpegKit.execute(
      '-y -i "$videoPath" -vn -ac 1 -ar 16000 -acodec pcm_s16le "$outputPath"',
    );
    final returnCode = await session.getReturnCode();
    if (!ReturnCode.isSuccess(returnCode)) {
      final logs = await session.getAllLogsAsString();
      throw Exception('FFmpeg audio extraction failed: $logs');
    }
  }

  /// Upload the audio file to the backend and stream progress updates.
  /// The backend returns NDJSON — one JSON object per line.
  static Future<SubtitleResult> _transcribe({
    required String audioPath,
    required String language,
    required String modelSize,
    void Function(int percent)? onProgressUpdate,
    ProcessingTask? task,
    String? videoPath,
  }) async {
    // New backend: single JSON response.
    onProgressUpdate?.call(10);
    task?.updateProgress(
      progress: 0.3,
      status: ProcessingStatus.uploading,
      message: 'Uploading to AI backend…',
    );
    final uri = Uri.parse('$_baseUrl/api/v1/audio/process');

    final request = http.MultipartRequest('POST', uri)
      ..fields['target_language'] = language
      ..fields['source_language'] = 'auto'
      ..fields['model_size'] = modelSize
      ..files.add(await http.MultipartFile.fromPath('audio', audioPath));

    // Yahan `await request.send()` ka matlab hai ke frontend tab tak 
    // event loop me intezar karega jab tak backend processed file wapis na bhej de.
    // Is lambe intezar ke doran app bilkul free rehti hai aur loader smoothly ghoomta rehta hai.
    final streamed = await request.send().timeout(
      const Duration(minutes: 30),
      onTimeout: () => throw Exception('Request timed out after 30 minutes'),
    );

    final body = await streamed.stream.bytesToString();
    if (streamed.statusCode < 200 || streamed.statusCode >= 300) {
      throw Exception('Backend error ${streamed.statusCode}: $body');
    }

    final data = jsonDecode(body) as Map<String, dynamic>;
    final subtitleUrl = data['subtitle_url'] as String?;
    if (subtitleUrl == null || subtitleUrl.isEmpty) {
      throw Exception('Backend did not return subtitle_url');
    }

    onProgressUpdate?.call(70);
    task?.updateProgress(
      progress: 0.7,
      status: ProcessingStatus.downloading,
      message: 'Downloading subtitles…',
    );
    final srtUri = _resolveUrl(subtitleUrl);
    final srtResponse = await http.get(srtUri).timeout(const Duration(minutes: 5));
    if (srtResponse.statusCode != 200) {
      throw Exception('Failed to download SRT: ${srtResponse.statusCode}');
    }
    onProgressUpdate?.call(90);

    task?.updateProgress(
      progress: 0.95,
      status: ProcessingStatus.processing,
      message: 'Processing subtitles…',
    );

    final detectedLanguage = data['detected_language'] as String?;
    final srt = utf8.decode(srtResponse.bodyBytes);
    final segmentCount = RegExp(r'^\d+\s*$', multiLine: true)
        .allMatches(srt)
        .length;

    // Persist SRT locally if videoPath provided
    try {
      if (videoPath != null && videoPath.isNotEmpty) {
        final docs = await getApplicationDocumentsDirectory();
        final genDir = Directory('${docs.path}/generated_assets');
        if (!await genDir.exists()) await genDir.create(recursive: true);
        final key = videoPath.hashCode;
        final file = File('${genDir.path}/subtitle_$key.srt');
        await file.writeAsBytes(srtResponse.bodyBytes, flush: true);

        try {
          await HistoryService().saveGeneratedAssets(videoPath, srtPath: file.path);
        } catch (_) {}
      }
    } catch (_) {}

    onProgressUpdate?.call(100);

    return SubtitleResult(
      srtContent: srt,
      detectedLanguage: detectedLanguage ?? language,
      segmentCount: segmentCount,
    );
  }

  static Uri _resolveUrl(String urlOrPath) {
    if (urlOrPath.startsWith('http://') || urlOrPath.startsWith('https://')) {
      return Uri.parse(urlOrPath);
    }
    return Uri.parse('$_baseUrl${urlOrPath.startsWith('/') ? '' : '/'}$urlOrPath');
  }

  /// Fetch the list of supported languages from the backend.
  static Future<List<Map<String, String>>> fetchLanguages() async {
    try {
      final response = await http
          .get(Uri.parse('$_baseUrl/api/v1/health'))
          .timeout(const Duration(seconds: 10));
      // Backend is reachable; we return a small static list for UI.
      if (response.statusCode == 200) {}
    } catch (_) {}
    // Fallback list if backend is unreachable
    return [
      {'code': 'auto', 'name': 'Auto-detect'},
      {'code': 'en', 'name': 'English'},
      {'code': 'ur', 'name': 'Urdu'},
      {'code': 'ar', 'name': 'Arabic'},
      {'code': 'fr', 'name': 'French'},
      {'code': 'de', 'name': 'German'},
      {'code': 'es', 'name': 'Spanish'},
      {'code': 'hi', 'name': 'Hindi'},
      {'code': 'zh', 'name': 'Chinese'},
      {'code': 'ja', 'name': 'Japanese'},
      {'code': 'ko', 'name': 'Korean'},
      {'code': 'ru', 'name': 'Russian'},
    ];
  }

  /// Parse an SRT string into a list of subtitle cue maps.
  /// Each map has: start (Duration), end (Duration), text (String).
  static List<SubtitleCue> parseSrt(String srt) {
    final cues = <SubtitleCue>[];
    final blocks = srt.trim().split(RegExp(r'\n\s*\n'));

    for (final block in blocks) {
      final lines = block.trim().split('\n');
      if (lines.length < 3) continue;

      // lines[0] = index, lines[1] = timestamps, lines[2+] = text
      final timeLine = lines[1];
      final parts = timeLine.split(' --> ');
      if (parts.length != 2) continue;

      final start = _parseSrtTime(parts[0].trim());
      final end = _parseSrtTime(parts[1].trim());
      final text = lines.sublist(2).join('\n').trim();

      if (start != null && end != null && text.isNotEmpty) {
        cues.add(SubtitleCue(start: start, end: end, text: text));
      }
    }
    return cues;
  }

  static Duration? _parseSrtTime(String s) {
    // Format: HH:MM:SS,mmm
    try {
      final commaIdx = s.indexOf(',');
      if (commaIdx == -1) return null;
      final timePart = s.substring(0, commaIdx);
      final millisPart = s.substring(commaIdx + 1);
      final timeParts = timePart.split(':');
      if (timeParts.length != 3) return null;

      return Duration(
        hours: int.parse(timeParts[0]),
        minutes: int.parse(timeParts[1]),
        seconds: int.parse(timeParts[2]),
        milliseconds: int.parse(millisPart),
      );
    } catch (_) {
      return null;
    }
  }
}

/// Represents a single subtitle cue.
class SubtitleCue {
  final Duration start;
  final Duration end;
  final String text;

  const SubtitleCue({
    required this.start,
    required this.end,
    required this.text,
  });
}

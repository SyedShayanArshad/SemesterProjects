# AI Video Backend (FastAPI)

Semester-project backend for your Flutter AI video app.

Features:
- Receive audio upload from Flutter
- Whisper speech-to-text
- Translation (Whisper `translate` to English; for other targets it translates EN -> target)
- Generate subtitles (`.srt`)
- Generate dubbed audio via `edge-tts`
- Returns original text, translated text, and URLs for generated files
- CORS enabled for Flutter/web
- Saves uploaded + generated files under `Backend/storage/`

## Setup

### 1. Create a virtual environment (recommended)
```bash
python -m venv venv
# Windows
venv\Scripts\activate
# Linux / macOS
source venv/bin/activate
```

### 2. Install dependencies
```bash
pip install -r requirements.txt
```

> **Note:** Whisper requires `ffmpeg` to be installed and on your PATH.
> - Windows: https://ffmpeg.org/download.html
> - Linux: `sudo apt install ffmpeg`

> **Torch note (Windows):** `openai-whisper` uses PyTorch. If pip struggles to install Torch, install it first from https://pytorch.org/get-started/locally/ and then install `requirements.txt`.

### 3. Run the server
```bash
python main.py
```

The server will start at `http://0.0.0.0:8000`.

## API

Base URL: `http://127.0.0.1:8000`

| Method | Path | Description |
|--------|------|-------------|
| GET | `/api/v1/health` | Health check |
| POST | `/api/v1/audio/process` | Upload audio → STT + translation + SRT + TTS |
| GET | `/files/<request_id>/<file>` | Download generated files |

### POST `/api/v1/audio/process`

**Form fields:**
- `audio` (file) — audio file (wav/mp3/m4a/aac/etc)
- `target_language` (string) — target language code (e.g. `en`, `ur`, `hi`)
- `source_language` (string) — `auto` (default) or a language code
- `model_size` (string) — Whisper model: `tiny`, `base`, `small`, `medium`, `large`
- `voice` (string, optional) — edge-tts voice name (otherwise auto-picked)

**Response:**
```json
{
  "request_id": "8a9f...",
  "detected_language": "ur",
  "target_language": "en",
  "original_text": "...",
  "translated_text": "...",
  "subtitle_url": "/files/8a9f.../subtitles.srt",
  "dubbed_audio_url": "/files/8a9f.../dubbed.mp3"
}
```

## Flutter integration (example)

Add `http` in `pubspec.yaml`:
```yaml
dependencies:
  http: ^1.2.2
```

Dart example (multipart upload):
```dart
import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;

Future<Map<String, dynamic>> processAudio({
  required File audioFile,
  required String targetLanguage,
  String baseUrl = 'http://10.0.2.2:8000', // Android emulator
}) async {
  final uri = Uri.parse('$baseUrl/api/v1/audio/process');
  final request = http.MultipartRequest('POST', uri);

  request.fields['target_language'] = targetLanguage;
  request.fields['source_language'] = 'auto';
  request.fields['model_size'] = 'base';

  request.files.add(await http.MultipartFile.fromPath('audio', audioFile.path));

  final streamed = await request.send();
  final body = await streamed.stream.bytesToString();
  if (streamed.statusCode < 200 || streamed.statusCode >= 300) {
    throw Exception('Backend error ${streamed.statusCode}: $body');
  }
  return body.isEmpty ? {} : (jsonDecode(body) as Map<String, dynamic>);
}
```

## Connecting from Android emulator

If the Flutter app is running in an Android emulator, use `http://10.0.2.2:8000` as the server URL (the emulator's alias for the host machine's `localhost`).

For a physical device on the same Wi-Fi network, use your machine's LAN IP address, e.g. `http://192.168.1.x:8000`.

In the Flutter project, update the base URL in [video_player/lib/core/constants/backend_constants.dart](../video_player/lib/core/constants/backend_constants.dart).

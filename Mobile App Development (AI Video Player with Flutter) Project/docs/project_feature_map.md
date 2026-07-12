# Project Feature Mapping

This document maps where the project implements or integrates the requested features.

---

## Encryption / Description
- Purpose: Encrypts sensitive user data (bookmarks) on the client before storing in Firestore.
- Where implemented:
  - File: [video_player/lib/data/services/encryption_service.dart](video_player/lib/data/services/encryption_service.dart)
    - AES-256 via the `encrypt` package; provides `encryptText` / `decryptText`.
  - Usage: [video_player/lib/data/services/firebase_user_data_service.dart](video_player/lib/data/services/firebase_user_data_service.dart)
    - `saveBookmark` encrypts `label` and `videoName` before saving.
    - `loadBookmarks` decrypts on read.
- Notes: Key is hard-coded in the Flutter app (`EncryptionService._key`). Consider secure storage or remote secret management for production.

---

## Database
- Purpose: Persistent user data and app metadata.
- Client (primary DB): Cloud Firestore (Firebase)
  - Files:
    - [video_player/lib/data/services/firebase_user_data_service.dart](video_player/lib/data/services/firebase_user_data_service.dart)
    - Flutter plugins in: [video_player/pubspec.yaml](video_player/pubspec.yaml) (`cloud_firestore`, `firebase_core`)
  - Data stored: user profile, settings, history, bookmarks, backend job records.
- Backend: No RDBMS/NoSQL DB used server-side; backend uses filesystem storage for uploaded/processed files.
  - Files:
    - [Backend/config.py](Backend/config.py) (storage dirs)
    - [Backend/services/storage_service.py](Backend/services/storage_service.py) (save uploads, outputs)
    - Output files are served from `Backend/storage/outputs/` via static mount in `Backend/app.py`.

---

## Push notifications
- Purpose: Send processing updates to devices and show local notifications.
- Backend (sender): Firebase Admin (FCM)
  - Files:
    - [Backend/services/notification_service.py](Backend/services/notification_service.py)
    - Expects `serviceAccountKey.json` in `Backend/` for server credentials.
  - Behavior: Topic-based notifications (default topic `processing_updates`) and helper methods (started/progress/complete/error).
- Client (receiver + local): Firebase Messaging + flutter_local_notifications
  - Files:
    - [video_player/lib/data/services/notification_service.dart](video_player/lib/data/services/notification_service.dart)
    - `main.dart` initializes `NotificationService.initialize()` (see [video_player/lib/main.dart](video_player/lib/main.dart)).
  - Plugins: `firebase_messaging`, `flutter_local_notifications` declared in [video_player/pubspec.yaml](video_player/pubspec.yaml).
  - Notes: Background handler registered via `FirebaseMessaging.onBackgroundMessage`.

---

## Background services
- Purpose: Periodic tasks and off-main-thread processing.
- Client (Flutter): Workmanager for scheduled periodic tasks
  - Files:
    - [video_player/lib/data/services/background_task_service.dart](video_player/lib/data/services/background_task_service.dart)
    - `main.dart` calls `BackgroundTaskService.initialize()` and schedules tasks.
  - Tasks: `scheduleAudioProcessingCleanup`, `scheduleDataSync`; callbackDispatcher handles tasks and triggers local notifications.
- Backend: Uses thread-pool offloading for CPU-bound work
  - Files:
    - [Backend/routes/audio.py](Backend/routes/audio.py)
      - Uses `run_in_threadpool` to call CPU-bound functions (`transcribe`, `translate_to_english`, etc.) so FastAPI event loop stays responsive.
    - [Backend/services/whisper_service.py](Backend/services/whisper_service.py)
      - Loads Whisper models with `lru_cache` to reuse model instances between calls.

---

## Permissions
- Purpose: Request runtime permissions required by the app (storage, notifications, microphone, etc.).
- Client (Flutter): Permission handling
  - Files:
    - [video_player/lib/data/services/permissions_service.dart](video_player/lib/data/services/permissions_service.dart)
      - Requests storage and notification permissions (Android) and notification (iOS); helpers for microphone/storage/notification.
    - Android manifest declarations: [video_player/android/app/src/main/AndroidManifest.xml](video_player/android/app/src/main/AndroidManifest.xml)
      - Declares `READ_EXTERNAL_STORAGE`, `WRITE_EXTERNAL_STORAGE` (legacy), `READ_MEDIA_VIDEO`, `WAKE_LOCK`, `INTERNET`, etc.
    - iOS: README mentions adding `GoogleService-Info.plist` if targeting iOS; Info.plist entries not explicitly included in repo.

---

## APIs (Backend endpoints and client usage)
- Backend (FastAPI): Provides audio processing endpoints and health check
  - Files / Endpoints:
    - [Backend/routes/audio.py](Backend/routes/audio.py)
      - POST `/api/v1/audio/process` — uploads audio, runs Whisper transcription/translation, generates SRT and TTS output, returns `subtitle_url` and `dubbed_audio_url`.
    - [Backend/routes/health.py](Backend/routes/health.py)
      - GET `/api/v1/health` — simple health check.
    - [Backend/app.py](Backend/app.py)
      - Registers routers under prefix (`/api/v1`) and serves generated files at `/files` (StaticFiles mount).
    - Config: [Backend/config.py](Backend/config.py) (`API_PREFIX`, storage dirs, `PUBLIC_BASE_URL`).
- Client (Flutter): Calls backend endpoints
  - Files:
    - [video_player/lib/data/services/subtitle_service.dart](video_player/lib/data/services/subtitle_service.dart)
      - Uploads WAV via multipart POST to `$_baseUrl/api/v1/audio/process`, downloads returned SRT.
    - Other client services that call backend audio API: [video_player/lib/data/services/dub_service.dart](video_player/lib/data/services/dub_service.dart) and [video_player/lib/data/services/ai_backend_service.dart](video_player/lib/data/services/ai_backend_service.dart).
    - Backend base URL constant: [video_player/lib/core/constants/backend_constants.dart](video_player/lib/core/constants/backend_constants.dart).

---

## Quick References / Helpful Files
- Backend main app: [Backend/app.py](Backend/app.py)
- Backend storage & uploads: [Backend/services/storage_service.py](Backend/services/storage_service.py), [Backend/storage/outputs/](Backend/storage/outputs/)
- Backend notification sender: [Backend/services/notification_service.py](Backend/services/notification_service.py)
- Flutter encryption: [video_player/lib/data/services/encryption_service.dart](video_player/lib/data/services/encryption_service.dart)
- Flutter Firestore integration: [video_player/lib/data/services/firebase_user_data_service.dart](video_player/lib/data/services/firebase_user_data_service.dart)
- Flutter background tasks: [video_player/lib/data/services/background_task_service.dart](video_player/lib/data/services/background_task_service.dart)
- Flutter permissions: [video_player/lib/data/services/permissions_service.dart](video_player/lib/data/services/permissions_service.dart)
- Flutter notification receiver: [video_player/lib/data/services/notification_service.dart](video_player/lib/data/services/notification_service.dart)

---

## Recommendations (short)
- Move the AES key out of source code into secure storage or environment-specific config.
- Consider a backend database if you need server-side persistent metadata or job tracking (currently frontend stores job history in Firestore).
- Ensure `serviceAccountKey.json` is kept out of source control and provided via secure CI/CD secrets.

---

Generated by repo scan on 2026-05-13.

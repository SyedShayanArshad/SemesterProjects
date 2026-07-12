"""
Firebase Cloud Messaging Service for Backend
============================================

This module handles sending push notifications from the Python backend
to the Flutter app using Firebase Cloud Messaging (FCM).

Installation:
    pip install firebase-admin

Setup:
    1. Go to Firebase Console → Project Settings → Service Accounts
    2. Click "Generate New Private Key"
    3. Save as `serviceAccountKey.json` in Backend folder
    4. Update path in __init_firebase()
"""

from __future__ import annotations

import firebase_admin
from firebase_admin import credentials, messaging
import os
import json
from datetime import datetime
from typing import Optional


class FCMNotificationService:
    """Service to send Firebase Cloud Messaging notifications"""
    
    _initialized = False
    
    @classmethod
    def initialize(cls):
        """Initialize Firebase Admin SDK"""
        if cls._initialized:
            return
        
        try:
            # Path to service account key
            key_path = os.path.join(
                os.path.dirname(__file__),
                '..', 
                'serviceAccountKey.json'
            )
            
            if os.path.exists(key_path):
                cred = credentials.Certificate(key_path)
                firebase_admin.initialize_app(cred)
                cls._initialized = True
                print('[FCMNotificationService] Initialized successfully')
            else:
                print(f'[FCMNotificationService] Key file not found: {key_path}')
                print('Notifications will not be sent.')
        except Exception as e:
            print(f'[FCMNotificationService] Initialization error: {e}')
    
    @staticmethod
    def send_notification(
        title: str,
        body: str,
        topic: str = 'processing_updates',
        data: Optional[dict] = None,
    ) -> bool:
        """
        Send a notification to all devices subscribed to a topic
        
        Args:
            title: Notification title
            body: Notification body
            topic: FCM topic name (default: 'processing_updates')
            data: Additional data dictionary
            
        Returns:
            True if sent successfully, False otherwise
        """
        if not FCMNotificationService._initialized:
            return False
        
        try:
            message = messaging.Message(
                notification=messaging.Notification(
                    title=title,
                    body=body,
                ),
                data=data or {},
                topic=topic,
            )
            
            response = messaging.send(message)
            print(f'[FCM] Sent notification: {response}')
            return True
        except Exception as e:
            print(f'[FCM] Error sending notification: {e}')
            return False
    
    @staticmethod
    def send_processing_started(
        request_id: str,
        video_name: str,
        target_language: str,
    ) -> bool:
        """Send notification when processing starts"""
        return FCMNotificationService.send_notification(
            title='🎬 Processing Started',
            body=f'Transcribing "{video_name}" to {target_language}...',
            data={
                'type': 'processing_started',
                'request_id': request_id,
                'timestamp': datetime.now().isoformat(),
            },
        )
    
    @staticmethod
    def send_processing_progress(
        request_id: str,
        stage: str,  # 'transcribing', 'translating', 'dubbing'
        progress: int,  # 0-100
        message: str,
    ) -> bool:
        """Send progress update notification"""
        return FCMNotificationService.send_notification(
            title='⏳ Processing in Progress',
            body=f'{message} ({progress}%)',
            data={
                'type': 'processing_progress',
                'request_id': request_id,
                'stage': stage,
                'progress': str(progress),
                'timestamp': datetime.now().isoformat(),
            },
        )
    
    @staticmethod
    def send_processing_complete(
        request_id: str,
        video_name: str,
        target_language: str,
        segments: int = 0,
    ) -> bool:
        """Send notification when processing completes"""
        body = f'✅ "{video_name}" ready in {target_language}!'
        if segments > 0:
            body += f' ({segments} subtitles)'
        
        return FCMNotificationService.send_notification(
            title='✅ Processing Complete',
            body=body,
            data={
                'type': 'processing_complete',
                'request_id': request_id,
                'segments': str(segments),
                'timestamp': datetime.now().isoformat(),
            },
        )
    
    @staticmethod
    def send_processing_error(
        request_id: str,
        video_name: str,
        error_message: str,
    ) -> bool:
        """Send notification when processing fails"""
        return FCMNotificationService.send_notification(
            title='❌ Processing Failed',
            body=f'Error processing "{video_name}": {error_message}',
            data={
                'type': 'processing_error',
                'request_id': request_id,
                'error': error_message,
                'timestamp': datetime.now().isoformat(),
            },
        )
    
    @staticmethod
    def send_subtitles_ready(
        request_id: str,
        language: str,
        segment_count: int,
    ) -> bool:
        """Send notification when subtitles are ready"""
        return FCMNotificationService.send_notification(
            title='📝 Subtitles Ready',
            body=f'Generated {segment_count} subtitle segments in {language}',
            data={
                'type': 'subtitles_ready',
                'request_id': request_id,
                'language': language,
                'segments': str(segment_count),
                'timestamp': datetime.now().isoformat(),
            },
        )
    
    @staticmethod
    def send_dubbing_ready(
        request_id: str,
        language: str,
    ) -> bool:
        """Send notification when dubbed audio is ready"""
        return FCMNotificationService.send_notification(
            title='🔊 Dubbed Audio Ready',
            body=f'Dubbed audio available in {language}',
            data={
                'type': 'dubbing_ready',
                'request_id': request_id,
                'language': language,
                'timestamp': datetime.now().isoformat(),
            },
        )
    
    @staticmethod
    def send_translation_complete(
        request_id: str,
        source_language: str,
        target_language: str,
    ) -> bool:
        """Send notification when translation is complete"""
        return FCMNotificationService.send_notification(
            title='🌐 Translation Complete',
            body=f'Translated from {source_language} to {target_language}',
            data={
                'type': 'translation_complete',
                'request_id': request_id,
                'source': source_language,
                'target': target_language,
                'timestamp': datetime.now().isoformat(),
            },
        )


# ──────────────────────────────────────────────────────────────────────────
# USAGE IN ROUTES
# ──────────────────────────────────────────────────────────────────────────

"""
Example usage in Backend/routes/audio.py:

from services.notification_service import FCMNotificationService

@router.post("/audio/process")
async def process_audio(
    request: Request,
    audio: UploadFile = File(...),
    target_language: str = Form(...),
    ...
) -> AudioProcessResponse:
    
    request_id = str(uuid.uuid4())
    
    try:
        # Notify user that processing started
        FCMNotificationService.send_processing_started(
            request_id=request_id,
            video_name=audio.filename or 'Video',
            target_language=target_language,
        )
        
        # Step 1: Transcribe
        FCMNotificationService.send_processing_progress(
            request_id=request_id,
            stage='transcribing',
            progress=33,
            message='Transcribing audio...',
        )
        stt_result = transcribe(...)
        
        # Step 2: Translate
        FCMNotificationService.send_processing_progress(
            request_id=request_id,
            stage='translating',
            progress=66,
            message='Translating text...',
        )
        translated_text = translate_text(...)
        
        # Step 3: Generate TTS/Dubbing
        FCMNotificationService.send_processing_progress(
            request_id=request_id,
            stage='dubbing',
            progress=90,
            message='Generating dubbed audio...',
        )
        dubbed_url = synthesize_to_mp3(...)
        
        # Notify completion
        FCMNotificationService.send_processing_complete(
            request_id=request_id,
            video_name=audio.filename or 'Video',
            target_language=target_language,
            segments=len(srt_result['segments']),
        )
        
        return AudioProcessResponse(
            request_id=request_id,
            ...
        )
        
    except Exception as e:
        FCMNotificationService.send_processing_error(
            request_id=request_id,
            video_name=audio.filename or 'Video',
            error_message=str(e),
        )
        raise HTTPException(status_code=500, detail=str(e))
"""


# ──────────────────────────────────────────────────────────────────────────
# INITIALIZATION
# ──────────────────────────────────────────────────────────────────────────

# Initialize when module is imported
FCMNotificationService.initialize()

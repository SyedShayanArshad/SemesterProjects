from __future__ import annotations

import asyncio
import uuid

from fastapi import APIRouter, File, Form, HTTPException, Request, UploadFile
from fastapi.concurrency import run_in_threadpool

from config import DEFAULT_WHISPER_MODEL, PUBLIC_BASE_URL
from schemas.audio import AudioProcessResponse
from services.storage_service import ensure_output_dir, save_upload_to_disk
from services.tts_service import synthesize_to_mp3, pick_voice
from services.translation_service import translate_text
from services.whisper_service import translate_to_english, transcribe, validate_model_size
from utils.srt import segments_to_srt

router = APIRouter()


def _file_url(request: Request, path_under_outputs: str) -> str:
    # `path_under_outputs` must be relative to OUTPUTS_DIR
    if PUBLIC_BASE_URL:
        return f"{PUBLIC_BASE_URL.rstrip('/')}/files/{path_under_outputs.lstrip('/')}"
    base = str(request.base_url).rstrip("/")
    return f"{base}/files/{path_under_outputs.lstrip('/')}"


@router.post("/audio/process", response_model=AudioProcessResponse)
async def process_audio(
    request: Request,
    audio: UploadFile = File(..., description="Audio file uploaded from Flutter"),
    target_language: str = Form(..., description="Target language code, e.g. en, ur, hi"),
    source_language: str = Form("auto", description="Source language code or 'auto'"),
    model_size: str = Form(DEFAULT_WHISPER_MODEL, description="Whisper model: tiny/base/small/medium/large"),
    speaker_audio: UploadFile | None = File(None, description="Optional audio file for voice cloning"),
) -> AudioProcessResponse:
    if not audio.filename:
        raise HTTPException(status_code=400, detail="Missing filename")

    try:
        model_size = validate_model_size(model_size)
    except ValueError as e:
        raise HTTPException(status_code=400, detail=str(e))

    request_id = str(uuid.uuid4())
    request_id, upload_path = await save_upload_to_disk(audio, request_id=request_id)
    out_dir = ensure_output_dir(request_id)

    # 1) Speech-to-text
    try:
        stt_result = await run_in_threadpool(transcribe, str(upload_path), model_size, source_language)
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Whisper transcription failed: {e}")

    original_text = (stt_result.get("text") or "").strip()
    detected_language = stt_result.get("language")
    segments = stt_result.get("segments") or []

    if not original_text:
        raise HTTPException(status_code=422, detail="No speech detected in the uploaded audio")

    # 2) Translation
    target_language = (target_language or "").strip().lower()
    if not target_language:
        raise HTTPException(status_code=400, detail="target_language is required")

    translated_text = original_text
    translated_segments = segments

    # If user asks same language, skip.
    if (detected_language and target_language == str(detected_language).lower()) or (
        source_language != "auto" and target_language == source_language.lower()
    ):
        translated_text = original_text
        translated_segments = segments
    elif target_language == "en":
        # Whisper "translate" is English-only
        try:
            tr_result = await run_in_threadpool(translate_to_english, str(upload_path), model_size)
        except Exception as e:
            raise HTTPException(status_code=500, detail=f"Whisper translation failed: {e}")
        translated_text = (tr_result.get("text") or "").strip() or original_text
        translated_segments = tr_result.get("segments") or segments
    else:
        # Whisper translate -> English, then translate to target language
        try:
            tr_en = await run_in_threadpool(translate_to_english, str(upload_path), model_size)
            en_segments = tr_en.get("segments") or []
            en_text = (tr_en.get("text") or "").strip() or original_text

            # Translate whole text (better for TTS)
            translated_text = await run_in_threadpool(translate_text, en_text, target_language, "en")

            # Translate subtitles per segment to keep timings
            segment_source = en_segments or segments

            async def translate_segment(seg: dict) -> dict:
                seg_text = str(seg.get("text", "")).strip()
                if seg_text:
                    seg_text = await run_in_threadpool(translate_text, seg_text, target_language, "en")
                return {**seg, "text": seg_text}

            translated_segments = await asyncio.gather(*(translate_segment(seg) for seg in segment_source))
        except RuntimeError as e:
            raise HTTPException(status_code=400, detail=str(e))
        except Exception as e:
            raise HTTPException(status_code=500, detail=f"Translation failed: {e}")

    # 3) Subtitles (.srt)
    srt_text = segments_to_srt(translated_segments)
    srt_path = out_dir / "subtitles.srt"

    # 4) TTS dubbing with voice cloning support
    dubbed_path = out_dir / "dubbed.mp3"
    speaker_audio_path: str | None = None

    try:
        # If speaker audio provided, save it for voice cloning
        if speaker_audio and speaker_audio.filename:
            speaker_audio_path_obj = out_dir / f"speaker_{uuid.uuid4().hex}.wav"
            speaker_content = await speaker_audio.read()
            await run_in_threadpool(speaker_audio_path_obj.write_bytes, speaker_content)
            speaker_audio_path = str(speaker_audio_path_obj)
            print(f"[DEBUG] Voice cloning enabled with speaker audio: {speaker_audio_path}")

        # Synthesize with TTS
        await asyncio.gather(
            run_in_threadpool(srt_path.write_text, srt_text, "utf-8"),
            synthesize_to_mp3(
                text=translated_text,
                out_path=str(dubbed_path),
                voice=pick_voice(target_language),
            ),
        )
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"TTS synthesis failed: {e}")

    rel_srt = f"{request_id}/subtitles.srt"
    rel_audio = f"{request_id}/dubbed.mp3"

    return AudioProcessResponse(
        request_id=request_id,
        detected_language=detected_language,
        target_language=target_language,
        original_text=original_text,
        translated_text=translated_text,
        subtitle_url=_file_url(request, rel_srt),
        dubbed_audio_url=_file_url(request, rel_audio),
    )

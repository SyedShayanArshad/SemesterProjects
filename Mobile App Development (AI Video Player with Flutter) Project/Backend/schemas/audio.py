from __future__ import annotations

from pydantic import BaseModel, Field


class AudioProcessResponse(BaseModel):
    request_id: str = Field(..., description="Server-generated request id")
    detected_language: str | None = Field(None, description="Detected language (if available)")
    target_language: str = Field(..., description="Requested target language")

    original_text: str = Field(..., description="Speech-to-text result")
    translated_text: str = Field(..., description="Translated text in target language")

    subtitle_url: str = Field(..., description="Public URL to .srt file")
    dubbed_audio_url: str = Field(..., description="Public URL to dubbed audio file")

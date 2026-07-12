from __future__ import annotations

from functools import lru_cache

import whisper


_VALID_MODEL_SIZES = {"tiny", "base", "small", "medium", "large"}


def validate_model_size(model_size: str) -> str:
    model_size = (model_size or "").strip().lower()
    if model_size not in _VALID_MODEL_SIZES:
        raise ValueError(f"Invalid Whisper model_size '{model_size}'. Valid: {sorted(_VALID_MODEL_SIZES)}")
    return model_size


@lru_cache(maxsize=4)
def get_model(model_size: str) -> whisper.Whisper:
    model_size = validate_model_size(model_size)
    return whisper.load_model(model_size)


def transcribe(audio_path: str, model_size: str, source_language: str | None) -> dict:
    model = get_model(model_size)

    kwargs: dict = {
        "task": "transcribe",
        "verbose": False,
    }
    if source_language and source_language != "auto":
        kwargs["language"] = source_language

    return model.transcribe(audio_path, **kwargs)


def translate_to_english(audio_path: str, model_size: str) -> dict:
    model = get_model(model_size)
    return model.transcribe(audio_path, task="translate", verbose=False)

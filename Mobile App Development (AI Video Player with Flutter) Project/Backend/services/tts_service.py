from __future__ import annotations

import edge_tts


_DEFAULT_VOICES: dict[str, str] = {
    "en": "en-US-GuyNeural",
    "ur": "ur-PK-AsadNeural",
    "hi": "hi-IN-MadhurNeural",
    "ar": "ar-SA-HamedNeural",
    "fr": "fr-FR-HenriNeural",
    "de": "de-DE-ConradNeural",
    "es": "es-ES-AlvaroNeural",
    "it": "it-IT-DiegoNeural",
    "pt": "pt-BR-AntonioNeural",
    "ru": "ru-RU-DmitryNeural",
    "zh": "zh-CN-YunxiNeural",
    "ja": "ja-JP-KeitaNeural",
    "ko": "ko-KR-InJoonNeural",
}


def pick_voice(target_language: str) -> str:
    lang = (target_language or "en").strip().lower()
    return _DEFAULT_VOICES.get(lang, _DEFAULT_VOICES["en"])


async def synthesize_to_mp3(text: str, out_path: str, voice: str) -> None:
    communicate = edge_tts.Communicate(text, voice)
    await communicate.save(out_path)

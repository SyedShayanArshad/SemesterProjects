from __future__ import annotations

try:
    from deep_translator import GoogleTranslator
except Exception:  # pragma: no cover
    GoogleTranslator = None  # type: ignore


def translate_text(text: str, target_language: str, source_language: str = "auto") -> str:
    text = (text or "").strip()
    if not text:
        return ""

    if GoogleTranslator is None:
        raise RuntimeError(
            "deep-translator is not installed. Install it or set target_language='en'."
        )

    translator = GoogleTranslator(source=source_language, target=target_language)
    translated = translator.translate(text)
    return translated or text

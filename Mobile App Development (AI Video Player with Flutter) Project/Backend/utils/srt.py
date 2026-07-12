from __future__ import annotations

from typing import Iterable


def _format_timestamp(seconds: float) -> str:
    # SRT: HH:MM:SS,mmm
    if seconds < 0:
        seconds = 0
    hours = int(seconds // 3600)
    minutes = int((seconds % 3600) // 60)
    secs = int(seconds % 60)
    millis = int(round((seconds - int(seconds)) * 1000))
    if millis >= 1000:
        millis = 999
    return f"{hours:02d}:{minutes:02d}:{secs:02d},{millis:03d}"


def segments_to_srt(segments: Iterable[dict]) -> str:
    lines: list[str] = []
    for idx, seg in enumerate(segments, start=1):
        start = _format_timestamp(float(seg.get("start", 0.0)))
        end = _format_timestamp(float(seg.get("end", 0.0)))
        text = str(seg.get("text", "")).strip()
        if not text:
            continue
        lines.append(f"{idx}\n{start} --> {end}\n{text}\n")
    return "\n".join(lines).strip() + "\n"

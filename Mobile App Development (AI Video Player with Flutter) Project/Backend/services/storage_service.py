from __future__ import annotations

import uuid
from pathlib import Path

from fastapi import UploadFile

from config import OUTPUTS_DIR, UPLOADS_DIR


async def save_upload_to_disk(upload: UploadFile, request_id: str | None = None) -> tuple[str, Path]:
    request_id = request_id or str(uuid.uuid4())

    original_name = upload.filename or "audio"
    suffix = Path(original_name).suffix or ".bin"

    dst = UPLOADS_DIR / f"{request_id}{suffix}"

    # Chunked write; UploadFile.read() is async, disk write is sync.
    with dst.open("wb") as f:
        while True:
            chunk = await upload.read(1024 * 1024)
            if not chunk:
                break
            f.write(chunk)

    try:
        await upload.close()
    except Exception:
        pass

    return request_id, dst


def ensure_output_dir(request_id: str) -> Path:
    out_dir = OUTPUTS_DIR / request_id
    out_dir.mkdir(parents=True, exist_ok=True)
    return out_dir

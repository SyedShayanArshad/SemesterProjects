from __future__ import annotations

import os
from pathlib import Path


BASE_DIR = Path(__file__).resolve().parent
STORAGE_DIR = BASE_DIR / "storage"
UPLOADS_DIR = STORAGE_DIR / "uploads"
OUTPUTS_DIR = STORAGE_DIR / "outputs"
TMP_DIR = STORAGE_DIR / "tmp"

# API
API_PREFIX = "/api/v1"

# CORS (comma-separated list). Use "*" for all.
CORS_ORIGINS = [o.strip() for o in os.getenv("CORS_ORIGINS", "*").split(",") if o.strip()]

# Whisper
DEFAULT_WHISPER_MODEL = os.getenv("WHISPER_MODEL", "base")

# URL building (helps when returning file URLs)
PUBLIC_BASE_URL = os.getenv("PUBLIC_BASE_URL", "")  # e.g. http://192.168.1.10:8000


def ensure_storage_dirs() -> None:
    for directory in (STORAGE_DIR, UPLOADS_DIR, OUTPUTS_DIR, TMP_DIR):
        directory.mkdir(parents=True, exist_ok=True)

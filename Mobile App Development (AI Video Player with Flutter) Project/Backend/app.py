from __future__ import annotations

import time
from fastapi import FastAPI, Request
from fastapi.middleware.cors import CORSMiddleware
from fastapi.staticfiles import StaticFiles

from config import API_PREFIX, CORS_ORIGINS, OUTPUTS_DIR, ensure_storage_dirs
from routes.audio import router as audio_router
from routes.health import router as health_router
from utils.logger import get_logger

app_logger = get_logger(__name__)

def create_app() -> FastAPI:
    ensure_storage_dirs()

    app = FastAPI(
        title="AI Video Backend",
        version="1.0.0",
        description="FastAPI backend for Flutter AI video app (Whisper + SRT + edge-tts).",
    )

    allow_all = len(CORS_ORIGINS) == 1 and CORS_ORIGINS[0] == "*"
    app.add_middleware(
        CORSMiddleware,
        allow_origins=["*"] if allow_all else CORS_ORIGINS,
        allow_credentials=not allow_all,
        allow_methods=["*"],
        allow_headers=["*"],
    )

    @app.middleware("http")
    async def add_process_time_header(request: Request, call_next):
        start_time = time.time()
        response = await call_next(request)
        process_time = time.time() - start_time
        
        # Profile specific API endpoints (logging executions)
        app_logger.info(f"Path: {request.url.path} | Method: {request.method} | Time: {process_time:.4f} secs")
        
        response.headers["X-Process-Time"] = str(process_time)
        return response

    app.include_router(health_router, prefix=API_PREFIX, tags=["health"])
    app.include_router(audio_router, prefix=API_PREFIX, tags=["audio"])

    # Serve generated files
    app.mount("/files", StaticFiles(directory=str(OUTPUTS_DIR)), name="files")

    return app


app = create_app()

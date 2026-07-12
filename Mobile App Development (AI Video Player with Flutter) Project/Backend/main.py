from __future__ import annotations

import os

import uvicorn


if __name__ == "__main__":
    host = os.getenv("HOST", "192.168.100.5")
    port = int(os.getenv("PORT", "8000"))
    # NOTE: Uvicorn requires an import string to enable reload/workers.
    # Running from this folder makes `app:app` resolvable.
    uvicorn.run("app:app", host=host, port=port, reload=True)

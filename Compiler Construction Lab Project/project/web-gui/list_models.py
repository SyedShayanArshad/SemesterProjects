import google.generativeai as genai
from dotenv import load_dotenv
import os

load_dotenv()
api_key = os.getenv('GEMINI_API_KEY')

if not api_key:
    print("GEMINI_API_KEY not found in .env file")
    exit()

genai.configure(api_key=api_key)

print("Listing available models:\n")
for model in genai.list_models():
    if 'generateContent' in model.supported_generation_methods:
        print(f"- {model.name}")
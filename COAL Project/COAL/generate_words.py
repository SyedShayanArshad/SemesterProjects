import google.generativeai as genai
import os
import traceback
import random
import re
import sys

# Set your API key
genai.configure(api_key="YOUR GEMINI API")  # Your key

# Initialize Gemini model
model = genai.GenerativeModel("gemini-1.5-flash")

# Get test type from command line argument
test_type = "1min"  # Default
if len(sys.argv) > 1:
    test_type = sys.argv[1]

# Configure word count and time based on test type
if test_type == "30sec":
    word_count = 60
    time_seconds = 30
elif test_type == "2min":
    word_count = 180
    time_seconds = 120
elif test_type == "complete":
    word_count = 200
    time_seconds = 0  # No time limit
else:  # 1min (default)
    word_count = 120
    time_seconds = 60

# Topic list
topics = [
    "Family bonding", "nature walk", "funny moments",
    "favorite hobby", "Morning routine", "Summer vacation",
    "childhood memories", "a simple walk in the park", "Travel dreams", "best friend"
]

chosen_topic = random.choice(topics)

# Prompt
prompt = f"""
Write a simple, easy-to-read paragraph of around {word_count} words about {chosen_topic}. 
The content should be straightforward, without any complex or unusual punctuation or symbols. 
Focus on making it feel natural, as if it's from a regular book or article you'd read in everyday life. 
The language should be clear, easy to understand, and free from any advanced characters like accents or symbols. 
It should sound human and relatable, avoiding any overly complicated terms. Do not use fancy quotes or line breaks.
"""

try:
    # Ensure output directory exists
    output_dir = "C:\\Users\\Shayan\\OneDrive\\Desktop\\COAL\\COAL"
    os.makedirs(output_dir, exist_ok=True)

    # Call Gemini API
    response = model.generate_content(prompt)
    paragraph = response.text.strip()

    # ✅ Clean paragraph for MASM use
    paragraph = " ".join(paragraph.splitlines())                  # remove line breaks
    paragraph = re.sub(r'\s+', ' ', paragraph).strip()            # remove extra spaces
    paragraph = paragraph.replace("'", "'").replace(""", '"').replace(""", '"')  # clean quotes
    paragraph = re.sub(r'[^\x00-\x7F]+', '', paragraph)           # remove non-ASCII characters

    # Save to file
    output_path = os.path.join(output_dir, "word.txt")
    with open(output_path, "w", encoding="utf-8") as f:
        f.write(paragraph)
    
    # Save test time separately (for assembly to read)
    time_path = os.path.join(output_dir, "time_setting.txt")
    with open(time_path, "w", encoding="utf-8") as f:
        f.write(str(time_seconds * 1000))  # Convert to milliseconds for assembly

    if os.path.exists(output_path):
        print(f"Generated {word_count}-word paragraph for {test_type} test")
    else:
        raise Exception("Failed to create word.txt")

except Exception as e:
    # Error log
    error_log = os.path.join(output_dir, "error_log.txt")
    with open(error_log, "w") as f:
        f.write(f"Error in generate_words.py: {str(e)}\n")
        f.write(traceback.format_exc())
    print(f"Error occurred. Check {error_log}")
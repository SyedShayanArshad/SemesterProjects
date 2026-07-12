from PIL import Image
import os

# Input and output folders
input_folder = r"C:\Users\syeds\Desktop\new data"
output_folder = r"C:\Users\syeds\Desktop\resized_data"

# Create output folder if it doesn't exist
os.makedirs(output_folder, exist_ok=True)

# Resize all JPG images to 64x64
for filename in os.listdir(input_folder):
    if filename.lower().endswith((".jpg", ".jpeg")):
        input_path = os.path.join(input_folder, filename)
        output_path = os.path.join(output_folder, filename)

        with Image.open(input_path) as img:
            resized_img = img.resize((64, 64))
            resized_img.save(output_path)

        print(f"Resized: {filename}")

print("All images resized to 64x64.")
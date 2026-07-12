
# =========================================================
# URDU ALPHABET CLASSIFICATION
# Consolidated Notebook
# =========================================================

# =========================================================
# STEP 1 — Imports
# =========================================================

import os
import cv2
import numpy as np
import matplotlib.pyplot as plt

from sklearn.model_selection import train_test_split
from sklearn.metrics import confusion_matrix, classification_report
from tensorflow.keras.models import Sequential, Model
from tensorflow.keras.layers import (
    Dense,
    Flatten,
    Dropout,
    Conv2D,
    MaxPooling2D,
    BatchNormalization
)

from tensorflow.keras.preprocessing.image import ImageDataGenerator
from tensorflow.keras.utils import to_categorical
from tensorflow.keras.callbacks import EarlyStopping
from tensorflow.keras.optimizers import Adam
from tensorflow.keras.regularizers import l2
import tensorflow as tf
import random
import seaborn as sns

np.random.seed(42)
tf.random.set_seed(42)
random.seed(42)

# =========================================================
# STEP 2 — Dataset Path
# =========================================================

dataset_path = "path/to/your/dataset"  # Update this path to your dataset location

# =========================================================
# STEP 3 — Load Images
# =========================================================

images = []
labels = []

files = [f for f in os.listdir(dataset_path) if f.endswith(".jpeg")]

# Class names
class_names = sorted([f.split(".")[0] for f in files])

# Label map
label_map = {name: i for i, name in enumerate(class_names)}

print("Classes:")
print(label_map)

# Load images
for file in files:

    path = os.path.join(dataset_path, file)

    # Read image in COLOR
    img = cv2.imread(path)

    # Resize
    img = cv2.resize(img, (64, 64))

    # Convert to grayscale
    img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # Normalize
    img = img / 255.0

    images.append(img)
    labels.append(label_map[file.split(".")[0]])

# Convert to arrays
X = np.array(images)
y = np.array(labels)

# =========================================================
# STEP 4 — Reshape for CNN
# =========================================================

X = X.reshape(-1, 64, 64, 1)

print("\nOriginal Dataset Shape:", X.shape)

# =========================================================
# STEP 5 — Data Augmentation & Visualization of Augmented Images
# =========================================================

datagen = ImageDataGenerator(
    rotation_range=6,
    width_shift_range=0.02,
    shear_range=0.1,

)

augmented_images = []
augmented_labels = []

# Generate 100 images from each original image
for i in range(len(X)):

    img = X[i].reshape((1, 64, 64, 1))

    count = 0

    for batch in datagen.flow(img, batch_size=1):

        augmented_images.append(batch[0])
        augmented_labels.append(y[i])

        count += 1

        if count >= 15:
            break

# Convert arrays
X_aug = np.array(augmented_images)
y_aug = np.array(augmented_labels)

print("Augmented Dataset Shape:", X_aug.shape)

# Visualize Augmented Images
bay_label_index = label_map['Meem']
bay_images_original = X[y == bay_label_index]

# Create a new datagen for displaying to avoid modifying the existing one if needed elsewhere
display_datagen = ImageDataGenerator(
    rotation_range=6,
    width_shift_range=0.02,
    shear_range=0.1
)

plt.figure(figsize=(16, 5)) # Adjusted figsize for 2 rows, 8 columns

# Display the original image
plt.subplot(2, 8, 1) # 2 rows, 8 columns, first plot
plt.imshow(bay_images_original[0].reshape(64, 64), cmap='gray')
plt.title('Original', fontsize=10)
plt.axis('off')

# Display augmented images
augmented_count = 0
for i, batch in enumerate(display_datagen.flow(bay_images_original, batch_size=1)):
    if augmented_count >= 15:
        break
    plt.subplot(2, 8, augmented_count + 2) # Start from the second plot
    plt.imshow(batch[0].reshape(64, 64), cmap='gray')
    plt.title(f'Augmented {augmented_count + 1}', fontsize=8)
    plt.axis('off')
    augmented_count += 1

plt.suptitle('Original and Augmented Images of Meem', fontsize=16)
plt.tight_layout(rect=[0, 0.03, 1, 0.95])
plt.show()


# =========================================================
# STEP 6 — Train/Test Split
# =========================================================

X_train, X_test, y_train, y_test = train_test_split(
    X_aug,
    y_aug,
    test_size=0.2,
    random_state=42,
    stratify=y_aug
)

# =========================================================
# STEP 7 — One Hot Encoding
# =========================================================

num_classes = len(class_names)

y_train = to_categorical(y_train, num_classes)
y_test  = to_categorical(y_test,  num_classes)

# =========================================================
# =========================================================
# DNN MODEL
# =========================================================
# =========================================================

print("\n===================================")
print("TRAINING DNN MODEL")
print("===================================\n")

# Flatten for DNN
X_train_dnn = X_train.reshape(-1, 64 * 64)
X_test_dnn  = X_test.reshape(-1,  64 * 64)

# =========================================================
# DNN Architecture
# =========================================================

dnn_model = Sequential([

    Dense(256, activation='relu', input_shape=(64 * 64,)),
    BatchNormalization(),
    Dropout(0.3),

    Dense(128, activation='relu'),
    BatchNormalization(),

    Dense(num_classes, activation='softmax')
])

# =========================================================
# Compile DNN
# =========================================================

dnn_model.compile(
    optimizer=Adam(learning_rate=0.0005),
    loss='categorical_crossentropy',
    metrics=['accuracy']
)

dnn_model.summary()

# =========================================================
# Early Stopping
# =========================================================

early_stop_dnn = EarlyStopping(
    monitor='val_loss',
    patience=5,
    restore_best_weights=True
)

# =========================================================
# Train DNN
# =========================================================

history_dnn = dnn_model.fit(
    X_train_dnn,
    y_train,
    validation_data=(X_test_dnn, y_test),
    epochs=50,
    batch_size=32,
    callbacks=[early_stop_dnn]
)

# =========================================================
# Evaluate DNN
# =========================================================

dnn_loss, dnn_accuracy = dnn_model.evaluate(X_test_dnn, y_test)

print(f"\nDNN Accuracy: {dnn_accuracy * 100:.2f}%")

# =========================================================
# Plot DNN Training Curves (Accuracy & Loss)
# =========================================================

fig_dnn_acc, ax_dnn_acc = plt.subplots(1, 1, figsize=(7, 5))
ax_dnn_acc.plot(history_dnn.history['accuracy'],     label='Train Accuracy')
ax_dnn_acc.plot(history_dnn.history['val_accuracy'], label='Val Accuracy')
ax_dnn_acc.set_title('DNN — Accuracy')
ax_dnn_acc.set_xlabel('Epoch')
ax_dnn_acc.set_ylabel('Accuracy')
ax_dnn_acc.legend()
plt.tight_layout()
plt.show()

fig_dnn_loss, ax_dnn_loss = plt.subplots(1, 1, figsize=(7, 5))
ax_dnn_loss.plot(history_dnn.history['loss'],     label='Train Loss')
ax_dnn_loss.plot(history_dnn.history['val_loss'], label='Val Loss')
ax_dnn_loss.set_title('DNN — Loss')
ax_dnn_loss.set_xlabel('Epoch')
ax_dnn_loss.set_ylabel('Loss')
ax_dnn_loss.legend()
plt.tight_layout()
plt.show()

# =========================================================
# =========================================================
# CNN MODEL
# =========================================================
# =========================================================

print("\n===================================")
print("TRAINING CNN MODEL")
print("===================================\n")

# =========================================================
# CNN Architecture
# =========================================================

cnn_model = Sequential([

    Conv2D(32, (3, 3), activation='relu', input_shape=(64, 64, 1)),
    MaxPooling2D(2, 2),

    Conv2D(64, (3, 3), activation='relu'),
    MaxPooling2D(2, 2),

    Flatten(),

    Dense(128, activation='relu'),
    Dropout(0.5),

    Dense(num_classes, activation='softmax')
])

# =========================================================
# Compile CNN
# =========================================================

cnn_model.compile(
    optimizer='adam',
    loss='categorical_crossentropy',
    metrics=['accuracy']
)

cnn_model.summary()

# =========================================================
# Early Stopping
# =========================================================

early_stop_cnn = EarlyStopping(
    monitor='val_loss',
    patience=5,
    restore_best_weights=True
)

# =========================================================
# Train CNN
# =========================================================

history_cnn = cnn_model.fit(
    X_train,
    y_train,
    validation_data=(X_test, y_test),
    epochs=50,
    batch_size=32,
    callbacks=[early_stop_cnn]
)

# =========================================================
# Evaluate CNN
# =========================================================

cnn_loss, cnn_accuracy = cnn_model.evaluate(X_test, y_test)

print(f"\nCNN Accuracy: {cnn_accuracy * 100:.2f}%")

# =========================================================
# Plot CNN Training Curves (Accuracy & Loss)
# =========================================================

fig_cnn_acc, ax_cnn_acc = plt.subplots(1, 1, figsize=(7, 5))
ax_cnn_acc.plot(history_cnn.history['accuracy'],     label='Train Accuracy')
ax_cnn_acc.plot(history_cnn.history['val_accuracy'], label='Val Accuracy')
ax_cnn_acc.set_title('CNN — Accuracy')
ax_cnn_acc.set_xlabel('Epoch')
ax_cnn_acc.set_ylabel('Accuracy')
ax_cnn_acc.legend()
plt.tight_layout()
plt.show()

fig_cnn_loss, ax_cnn_loss = plt.subplots(1, 1, figsize=(7, 5))
ax_cnn_loss.plot(history_cnn.history['loss'],     label='Train Loss')
ax_cnn_loss.plot(history_cnn.history['val_loss'], label='Val Loss')
ax_cnn_loss.set_title('CNN — Loss')
ax_cnn_loss.set_xlabel('Epoch')
ax_cnn_loss.set_ylabel('Loss')
ax_cnn_loss.legend()
plt.tight_layout()
plt.show()

# =========================================================
# STEP 8 — Compare Model Results
# =========================================================

print("\n===================================")
print("FINAL COMPARISON")
print("===================================\n")

print(f"DNN Accuracy : {dnn_accuracy * 100:.2f}%")
print(f"CNN Accuracy : {cnn_accuracy * 100:.2f}%")

# =========================================================
# STEP 9 — Predict Single Image
# =========================================================

test_image = "/content/drive/MyDrive/new-urdu/Ain.jpeg"

img = cv2.imread(test_image)
img = cv2.resize(img, (64, 64))
img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
img = img / 255.0

# Reverse label map
reverse_map = {v: k for k, v in label_map.items()}

# =========================================================
# DNN Prediction
# =========================================================

img_dnn        = img.reshape(1, 64 * 64)
prediction_dnn = dnn_model.predict(img_dnn)
predicted_class_dnn = np.argmax(prediction_dnn)

# =========================================================
# CNN Prediction
# =========================================================

img_cnn        = img.reshape(1, 64, 64, 1)
prediction_cnn = cnn_model.predict(img_cnn)
predicted_class_cnn = np.argmax(prediction_cnn)

# =========================================================
# Print Predictions
# =========================================================

print("\n===================================")
print("PREDICTIONS")
print("===================================\n")

print("DNN Prediction :", reverse_map[predicted_class_dnn])
print("CNN Prediction :", reverse_map[predicted_class_cnn])

# =========================================================
# STEP 10 — Visualize Feature Maps
# =========================================================

def visualize_feature_maps(cnn_model, sample_image, class_name):
    """
    Shows the activation maps produced by each Conv layer for ONE image.
    This reveals what spatial features the CNN is detecting.
    """
    conv_layer_names = [l.name for l in cnn_model.layers
                        if isinstance(l, Conv2D)]

    # Plot original image
    plt.figure(figsize=(3, 3))
    plt.imshow(sample_image.reshape(64, 64), cmap='gray') # Reshape for grayscale image
    plt.title(f"Input Image: {class_name}", fontweight='bold')
    plt.axis('off')
    plt.show()

    img_batch = np.expand_dims(sample_image, 0)  # (1, H, W, C)

    for layer_name in conv_layer_names:
        layer = cnn_model.get_layer(layer_name)
        activation_model = Model(inputs=cnn_model.layers[0].input,
                                       outputs=layer.output)
        activations = activation_model.predict(img_batch, verbose=0)  # (1, H, W, filters)

        n_show = min(16, activations.shape[-1])
        n_cols = 8
        n_rows = int(np.ceil(n_show / n_cols))
        map_h, map_w = activations.shape[1], activations.shape[2]

        fig, axes = plt.subplots(n_rows, n_cols,
                                 figsize=(n_cols * 1.6, n_rows * 1.6))
        fig.suptitle(f"Feature Maps: {layer_name}  "
                     f"(Output size: {map_h}×{map_w}, "
                     f"{activations.shape[-1]} channels)",
                     fontsize=11, fontweight='bold')
        axes = axes.flatten()

        for i in range(n_show):
            fmap = activations[0, :, :, i]
            axes[i].imshow(fmap, cmap='inferno')
            axes[i].set_title(f"ch {i}", fontsize=6)
            axes[i].axis('off')

        for j in range(n_show, len(axes)): # Turn off unused subplots
            axes[j].axis('off')

        plt.tight_layout()
        plt.show()

        # Non-zero activation statistics
        active_ratio = np.mean(activations > 0)
        print(f"  {layer_name}: {active_ratio*100:.1f}% neurons active | "
              f"mean activation = {activations.mean():.4f}")

    print("\nInterpretation:")
    print("  conv1: Bright spots highlight where edges/strokes were detected")
    print("  conv2: More abstract — shows where stroke combinations appear")
    print("  Deeper Conv layers: tend to detect increasingly abstract, high-level features relevant to the object classes.")


# Pick one test sample and visualize
sample_idx = 0
sample_img   = X_test[sample_idx]
sample_label_idx = np.argmax(y_test[sample_idx])
sample_class_name = reverse_map[sample_label_idx] # Using reverse_map which is available

visualize_feature_maps(cnn_model, sample_img, sample_class_name)

# =========================================================
# STEP 11 — Show Confusion Matrices
# =========================================================

# Get true labels from one-hot encoded y_test
true_labels = np.argmax(y_test, axis=1);

# --- DNN Confusion Matrix ---
print("\n===================================")
print("DNN Model Confusion Matrix")
print("===================================\n")

# Predict probabilities for DNN model
dnn_predictions_probs = dnn_model.predict(X_test_dnn, verbose=0);
# Get predicted class labels for DNN model
dnn_predicted_labels = np.argmax(dnn_predictions_probs, axis=1);

# Generate Confusion Matrix for DNN
cm_dnn = confusion_matrix(true_labels, dnn_predicted_labels);

plt.figure(figsize=(15, 10))
sns.heatmap(cm_dnn, annot=True, fmt='d', cmap='Blues', xticklabels=class_names, yticklabels=class_names)
plt.xlabel('Predicted Label')
plt.ylabel('True Label')
plt.title('DNN Confusion Matrix')
plt.show()

# --- CNN Confusion Matrix ---
print("\n===================================")
print("CNN Model Confusion Matrix")
print("===================================\n")

# Predict probabilities for CNN model
cnn_predictions_probs = cnn_model.predict(X_test, verbose=0);
# Get predicted class labels for CNN model
cnn_predicted_labels = np.argmax(cnn_predictions_probs, axis=1);

# Generate Confusion Matrix for CNN
cm_cnn = confusion_matrix(true_labels, cnn_predicted_labels);

plt.figure(figsize=(15, 10))
sns.heatmap(cm_cnn, annot=True, fmt='d', cmap='Blues', xticklabels=class_names, yticklabels=class_names)
plt.xlabel('Predicted Label')
plt.ylabel('True Label')
plt.title('CNN Confusion Matrix')
plt.show()
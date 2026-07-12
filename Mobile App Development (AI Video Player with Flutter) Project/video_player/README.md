# CineKit

Flutter video player with Firebase Authentication and Firestore sync.

## Firebase setup

1. Create a Firebase project in the Firebase Console.
2. Enable **Authentication > Sign-in method > Email/Password**.
3. Enable **Authentication > Sign-in method > Google**.
4. Add the Android SHA-1 fingerprint for your debug and release keys in **Project settings > Your apps**.
5. Add a **Web client ID** at run time with `--dart-define=GOOGLE_WEB_CLIENT_ID=...`.
6. Create a **Cloud Firestore** database.
7. Add the Android config file at `android/app/google-services.json`.
8. If you target iOS, add `ios/Runner/GoogleService-Info.plist`.
9. Run `flutter pub get` after the Firebase packages are added.

### Getting the SHA-1 on Windows

If `keytool` is not on your PATH, use Gradle instead:

```powershell
cd android
.\gradlew signingReport
```

Copy the `SHA1` value for the `debug` variant into Firebase Console.

## What is stored in Firebase

- User account authentication via Firebase Auth.
- User profile metadata in Firestore.
- Playback history sync in Firestore when signed in.
- Player settings sync in Firestore when signed in.

## Password handling

Passwords are not stored or decrypted in the app. Firebase Auth handles password hashing and verification securely on the backend.

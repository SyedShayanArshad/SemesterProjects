import 'dart:async';

import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/foundation.dart';
import 'package:google_sign_in/google_sign_in.dart';

import '../../data/services/firebase_user_data_service.dart';

class AuthProvider extends ChangeNotifier {
  final FirebaseAuth _auth;
  final GoogleSignIn _googleSignIn = GoogleSignIn.instance;
  final FirebaseUserDataService _userDataService;
  StreamSubscription<User?>? _subscription;
  Future<void>? _googleSignInInitFuture;

  static const String _googleWebClientId =
      String.fromEnvironment('GOOGLE_WEB_CLIENT_ID');

  User? _user;
  bool _ready = false;

  AuthProvider(this._userDataService, {FirebaseAuth? auth})
      : _auth = auth ?? FirebaseAuth.instance {
    _subscription = _auth.authStateChanges().listen(_handleAuthStateChanged);
  }

  User? get user => _user;
  bool get ready => _ready;
  bool get signedIn => _user != null;

  Future<void> _handleAuthStateChanged(User? user) async {
    _user = user;
    _ready = true;
    notifyListeners();
    if (user != null) {
      try {
        await _userDataService.ensureUserProfile(user);
      } catch (_) {}
    }
  }

  Future<void> signIn({required String email, required String password}) {
    return _auth.signInWithEmailAndPassword(email: email, password: password);
  }

  Future<UserCredential?> signInWithGoogle() async {
    try {
      if (kIsWeb) {
        final provider = GoogleAuthProvider();
        return await _auth.signInWithPopup(provider);
      }

      await _ensureGoogleSignInInitialized();

      late final GoogleSignInAccount googleUser;
      try {
        googleUser = await _googleSignIn.authenticate(scopeHint: const ['email']);
      } on GoogleSignInException catch (e) {
        if (e.code == GoogleSignInExceptionCode.canceled) return null;
        rethrow;
      }

      final googleAuth = googleUser.authentication;

      if (googleAuth.idToken == null || googleAuth.idToken!.isEmpty) {
        throw StateError(
          'Google Sign-In did not return an ID token. '
          'On Android, ensure your app is configured in Firebase (SHA-1/SHA-256 uploaded, '
          'correct package name) and that Google Sign-In is enabled. '
          'If your setup requires it, pass the OAuth Web client ID via '
          '--dart-define=GOOGLE_WEB_CLIENT_ID=YOUR_WEB_CLIENT_ID.',
        );
      }

      // google_sign_in v7 moved access tokens out of `GoogleSignInAuthentication`.
      // For Firebase Auth, the `idToken` is usually sufficient; include an
      // access token when available.
      GoogleSignInClientAuthorization? clientAuth;
      try {
        clientAuth = await googleUser.authorizationClient
            .authorizationForScopes(const ['email']);
      } catch (_) {
        clientAuth = null;
      }
      final credential = GoogleAuthProvider.credential(
        accessToken: clientAuth?.accessToken,
        idToken: googleAuth.idToken,
      );

      return await _auth.signInWithCredential(credential);
    } catch (e) {
      rethrow;
    }
  }

  Future<void> _ensureGoogleSignInInitialized() {
    return _googleSignInInitFuture ??= _initializeGoogleSignIn();
  }

  Future<void> _initializeGoogleSignIn() async {
    // `serverClientId` (OAuth Web client ID) is optional on Android/iOS when
    // Google Sign-In is configured via `google-services.json`/`GoogleService-Info.plist`.
    // It is commonly required for web, and sometimes for backend server auth.
    if (_googleWebClientId.isNotEmpty) {
      await _googleSignIn.initialize(serverClientId: _googleWebClientId);
    } else {
      await _googleSignIn.initialize();
    }
  }

  Future<void> signUp({
    required String email,
    required String password,
    String? displayName,
  }) async {
    final credential = await _auth.createUserWithEmailAndPassword(
      email: email,
      password: password,
    );
    final user = credential.user;
    if (user != null && displayName != null && displayName.trim().isNotEmpty) {
      await user.updateDisplayName(displayName.trim());
      await user.reload();
      _user = _auth.currentUser;
      notifyListeners();
    }
  }

  Future<void> sendPasswordReset(String email) {
    return _auth.sendPasswordResetEmail(email: email);
  }

  Future<void> signOut() {
    return Future.wait([
      _auth.signOut(),
      // attempt to sign out from Google as well; ignore errors
      _googleSignIn.signOut().catchError((_) {}),
    ]).then((_) {});
  }

  @override
  void dispose() {
    _subscription?.cancel();
    super.dispose();
  }
}
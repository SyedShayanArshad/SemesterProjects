import 'dart:convert';

import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';

import '../models/playback_history_item.dart';
import '../models/player_settings.dart';
import '../models/bookmark_model.dart';
import 'encryption_service.dart';

class FirebaseUserDataService {
  final FirebaseAuth _auth;
  final FirebaseFirestore _firestore;

  FirebaseUserDataService({FirebaseAuth? auth, FirebaseFirestore? firestore})
      : _auth = auth ?? FirebaseAuth.instance,
        _firestore = firestore ?? FirebaseFirestore.instance;

  User? get _user => _auth.currentUser;

  DocumentReference<Map<String, dynamic>>? get _userDoc {
    final user = _user;
    if (user == null) return null;
    return _firestore.collection('users').doc(user.uid);
  }

  CollectionReference<Map<String, dynamic>>? get _historyCollection {
    final userDoc = _userDoc;
    if (userDoc == null) return null;
    return userDoc.collection('history');
  }

  CollectionReference<Map<String, dynamic>>? get _bookmarksCollection {
    final userDoc = _userDoc;
    if (userDoc == null) return null;
    return userDoc.collection('bookmarks');
  }

  CollectionReference<Map<String, dynamic>>? get _jobsCollection {
    final userDoc = _userDoc;
    if (userDoc == null) return null;
    return userDoc.collection('backend_jobs');
  }

  Future<void> ensureUserProfile(User user) async {
    final userDoc = _firestore.collection('users').doc(user.uid);
    final snapshot = await userDoc.get();
    final payload = <String, dynamic>{
      'email': user.email,
      'displayName': user.displayName,
      'photoUrl': user.photoURL,
      'emailVerified': user.emailVerified,
      'lastLoginAt': FieldValue.serverTimestamp(),
      'providerIds': user.providerData.map((e) => e.providerId).toList(),
    };
    if (!snapshot.exists) {
      payload['createdAt'] = FieldValue.serverTimestamp();
    }
    await userDoc.set(payload, SetOptions(merge: true));
  }

  Future<PlayerSettings?> loadSettings() async {
    final userDoc = _userDoc;
    if (userDoc == null) return null;
    final snapshot = await userDoc.get();
    final data = snapshot.data();
    final rawSettings = data?['settings'];
    if (rawSettings is Map<String, dynamic>) {
      return PlayerSettings.fromJson(rawSettings);
    }
    if (rawSettings is Map) {
      return PlayerSettings.fromJson(
        rawSettings.map((key, value) => MapEntry(key.toString(), value)),
      );
    }
    return null;
  }

  Future<void> saveSettings(PlayerSettings settings) async {
    final userDoc = _userDoc;
    if (userDoc == null) return;
    await userDoc.set({'settings': settings.toJson()}, SetOptions(merge: true));
  }

  Future<List<PlaybackHistoryItem>?> loadHistory() async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return null;
    final snapshot = await historyCollection
        .orderBy('lastPlayed', descending: true)
        .get();
    return snapshot.docs
        .map((doc) {
          try {
            return PlaybackHistoryItem.fromJson(doc.data());
          } catch (_) {
            return null;
          }
        })
        .whereType<PlaybackHistoryItem>()
        .toList();
  }

  Future<void> saveHistory(List<PlaybackHistoryItem> items) async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return;

    final existing = await historyCollection.get();
    final batch = _firestore.batch();
    for (final doc in existing.docs) {
      batch.delete(doc.reference);
    }
    for (final item in items) {
      batch.set(historyCollection.doc(_docIdForPath(item.videoPath)), item.toJson());
    }
    await batch.commit();
  }

  Future<void> upsertHistoryItem(PlaybackHistoryItem item) async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return;
    await historyCollection.doc(_docIdForPath(item.videoPath)).set(
          item.toJson(),
          SetOptions(merge: true),
        );
  }

  Future<void> removeHistoryItem(String videoPath) async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return;
    await historyCollection.doc(_docIdForPath(videoPath)).delete();
  }

  Future<void> clearHistory() async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return;
    final snapshot = await historyCollection.get();
    final batch = _firestore.batch();
    for (final doc in snapshot.docs) {
      batch.delete(doc.reference);
    }
    await batch.commit();
  }

  Future<Duration?> getLastPosition(String videoPath) async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return null;
    final snapshot = await historyCollection.doc(_docIdForPath(videoPath)).get();
    final data = snapshot.data();
    final ms = data?['lastPositionMs'];
    if (ms is int) {
      return Duration(milliseconds: ms);
    }
    if (ms is num) {
      return Duration(milliseconds: ms.toInt());
    }
    return null;
  }

  Future<void> savePosition(String videoPath, Duration position) async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return;
    await historyCollection.doc(_docIdForPath(videoPath)).set(
      {
        'videoPath': videoPath,
        'lastPositionMs': position.inMilliseconds,
        'updatedAt': FieldValue.serverTimestamp(),
      },
      SetOptions(merge: true),
    );
  }

  Future<void> clearPosition(String videoPath) async {
    final historyCollection = _historyCollection;
    if (historyCollection == null) return;
    await historyCollection.doc(_docIdForPath(videoPath)).set(
      {'lastPositionMs': FieldValue.delete()},
      SetOptions(merge: true),
    );
  }

  String _docIdForPath(String videoPath) {
    return base64Url.encode(utf8.encode(videoPath));
  }

  String _bookmarkFieldKey(String bookmarkId) => 'bookmarks.$bookmarkId';

  Map<String, dynamic> _decryptBookmarkData(Map<String, dynamic> data) {
    final decryptedLabel = EncryptionService.decryptText(data['label'] as String? ?? '');
    final decryptedVideoName = EncryptionService.decryptText(data['videoName'] as String? ?? '');
    return {
      ...data,
      'label': decryptedLabel,
      'videoName': decryptedVideoName,
    };
  }

  // ---------------------------------------------------------------------------
  // Bookmarks with Encryption / Decryption
  // ---------------------------------------------------------------------------

  Future<void> saveBookmark(BookmarkModel bookmark) async {
    final userDoc = _userDoc;
    if (userDoc == null) {
      throw StateError('saveBookmark failed: user is not logged in.');
    }

    final col = _bookmarksCollection;

    // Encrypt sensitive info
    final encryptedLabel = EncryptionService.encryptText(bookmark.label);
    final encryptedVideoName = EncryptionService.encryptText(bookmark.videoName);

    final data = bookmark.toJson();
    data['label'] = encryptedLabel;
    data['videoName'] = encryptedVideoName;

    // Always ensure the id field exists (some reads rely on it).
    data['id'] ??= bookmark.id;

    // Attempt to store in a dedicated subcollection.
    // If Firestore rules block subcollections, we still store in the user doc as a fallback.
    if (col != null) {
      try {
        await col.doc(bookmark.id).set(data, SetOptions(merge: true));
      } catch (_) {
        // Ignore and rely on fallback storage below.
      }
    }

    // Fallback / compatibility storage: a map under users/<uid>.bookmarks.<id>
    await userDoc.set({_bookmarkFieldKey(bookmark.id): data}, SetOptions(merge: true));
  }

  Future<List<BookmarkModel>?> loadBookmarks() async {
    final userDoc = _userDoc;
    if (userDoc == null) return null;

    // 1) Preferred: subcollection users/<uid>/bookmarks
    try {
      final col = _bookmarksCollection;
      if (col != null) {
        final snapshot = await col.orderBy('createdAt', descending: true).get();
        if (snapshot.docs.isNotEmpty) {
          return snapshot.docs.map((doc) {
            final data = doc.data();
            data['id'] ??= doc.id;
            final decrypted = _decryptBookmarkData(data);
            return BookmarkModel.fromJson(decrypted);
          }).toList();
        }
      }
    } catch (_) {
      // Permission denied / missing index / offline; fall back below.
    }

    // 2) Fallback: map field on the user document: users/<uid>.bookmarks.<id>
    try {
      final snapshot = await userDoc.get();
      final data = snapshot.data();
      final raw = data?['bookmarks'];
      if (raw is Map) {
        final list = raw.entries
            .map((e) {
              final value = e.value;
              if (value is Map) {
                final json = value.map((k, v) => MapEntry(k.toString(), v));
                json['id'] ??= e.key.toString();
                final decrypted = _decryptBookmarkData(json);
                return BookmarkModel.fromJson(decrypted);
              }
              return null;
            })
            .whereType<BookmarkModel>()
            .toList();
        list.sort((a, b) => b.createdAt.compareTo(a.createdAt));
        return list;
      }
    } catch (_) {
      // ignore
    }

    return [];
  }

  Future<void> deleteBookmark(String bookmarkId) async {
    final userDoc = _userDoc;
    if (userDoc == null) {
      throw StateError('deleteBookmark failed: user is not logged in.');
    }

    // Best-effort delete from subcollection.
    final col = _bookmarksCollection;
    if (col != null) {
      try {
        await col.doc(bookmarkId).delete();
      } catch (_) {
        // Ignore and still delete from fallback map.
      }
    }

    // Also delete from fallback map.
    await userDoc.set(
      {_bookmarkFieldKey(bookmarkId): FieldValue.delete()},
      SetOptions(merge: true),
    );
  }

  // ---------------------------------------------------------------------------
  // Backend Jobs (AI Process History)
  // ---------------------------------------------------------------------------

  Future<void> saveBackendJob({
    required String jobId,
    required String videoName,
    required String jobType, // e.g., 'translation', 'tts', 'whisper'
    required String status,  // e.g., 'completed', 'failed'
  }) async {
    final col = _jobsCollection;
    if (col == null) return;

    await col.doc(jobId).set({
      'jobId': jobId,
      'videoName': videoName,
      'jobType': jobType,
      'status': status,
      'createdAt': FieldValue.serverTimestamp(),
    });
  }

  Future<List<Map<String, dynamic>>?> loadBackendJobs() async {
    final col = _jobsCollection;
    if (col == null) return null;

    final snapshot = await col.orderBy('createdAt', descending: true).get();
    return snapshot.docs.map((doc) {
      final data = doc.data();
      // Convert Timestamp to readable format or keep it
      return data;
    }).toList();
  }
}

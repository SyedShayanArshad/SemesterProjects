import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';

import '../../core/constants/app_constants.dart';
import '../models/bookmark_model.dart';
import 'firebase_user_data_service.dart';

class BookmarkService {
  final FirebaseUserDataService _firebaseStore;

  BookmarkService({FirebaseUserDataService? firebaseStore})
      : _firebaseStore = firebaseStore ?? FirebaseUserDataService();

  Future<List<BookmarkModel>> getBookmarks() async {
    try {
      final remote = await _firebaseStore.loadBookmarks();
      if (remote != null) {
        final local = await _loadLocalBookmarks();
        final merged = _mergeBookmarks(local, remote);
        await _saveLocalBookmarks(merged);
        // Best-effort: keep remote in sync.
        for (final b in merged) {
          // Avoid overwriting remote too aggressively; only ensure items exist.
          // (If rules block writes, FirebaseUserDataService will throw and we ignore.)
          // ignore: unawaited_futures
          _firebaseStore.saveBookmark(b).catchError((_) {});
        }
        return merged;
      }
    } catch (_) {}

    return _loadLocalBookmarks();
  }

  Future<void> add(BookmarkModel bookmark) async {
    final list = await getBookmarks();
    list.removeWhere((b) => b.id == bookmark.id);
    list.insert(0, bookmark);
    await _saveLocalBookmarks(list);
    try {
      await _firebaseStore.saveBookmark(bookmark);
    } catch (_) {}
  }

  Future<void> remove(String bookmarkId) async {
    final list = await getBookmarks();
    list.removeWhere((b) => b.id == bookmarkId);
    await _saveLocalBookmarks(list);
    try {
      await _firebaseStore.deleteBookmark(bookmarkId);
    } catch (_) {}
  }

  Future<void> clearLocal() => _saveLocalBookmarks(const []);

  Future<List<BookmarkModel>> _loadLocalBookmarks() async {
    final prefs = await SharedPreferences.getInstance();
    final raw = prefs.getStringList(AppConstants.bookmarksKey) ?? [];
    return raw
        .map((e) {
          try {
            return BookmarkModel.fromJson(
              jsonDecode(e) as Map<String, dynamic>,
            );
          } catch (_) {
            return null;
          }
        })
        .whereType<BookmarkModel>()
        .toList()
      ..sort((a, b) => b.createdAt.compareTo(a.createdAt));
  }

  Future<void> _saveLocalBookmarks(List<BookmarkModel> bookmarks) async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.setStringList(
      AppConstants.bookmarksKey,
      bookmarks.map((e) => jsonEncode(e.toJson())).toList(),
    );
  }

  List<BookmarkModel> _mergeBookmarks(
    List<BookmarkModel> local,
    List<BookmarkModel> remote,
  ) {
    final merged = <String, BookmarkModel>{};
    for (final item in [...local, ...remote]) {
      final current = merged[item.id];
      if (current == null || item.createdAt.isAfter(current.createdAt)) {
        merged[item.id] = item;
      }
    }
    final items = merged.values.toList()
      ..sort((a, b) => b.createdAt.compareTo(a.createdAt));
    return items;
  }
}

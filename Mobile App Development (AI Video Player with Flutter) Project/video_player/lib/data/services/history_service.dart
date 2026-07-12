import 'dart:convert';
import 'dart:io';
import 'package:shared_preferences/shared_preferences.dart';
import '../models/playback_history_item.dart';
import '../../core/constants/app_constants.dart';
import 'firebase_user_data_service.dart';

class HistoryService {
  final _firebaseStore = FirebaseUserDataService();

  Future<List<PlaybackHistoryItem>> getHistory() async {
    try {
      final remote = await _firebaseStore.loadHistory();
      if (remote != null) {
        final local = await _loadLocalHistory();
        final merged = _mergeHistory(local, remote);
        await _saveLocalHistory(merged);
        if (merged.isNotEmpty) {
          await _firebaseStore.saveHistory(merged);
        }
        return merged;
      }
    } catch (_) {}

    return _loadLocalHistory();
  }

  Future<void> addOrUpdate(PlaybackHistoryItem item) async {
    var history = await getHistory();
    history.removeWhere((e) => e.videoPath == item.videoPath);
    history.insert(0, item);
    if (history.length > AppConstants.maxHistoryItems) {
      history = history.sublist(0, AppConstants.maxHistoryItems);
    }
    await _saveLocalHistory(history);
    try {
      await _firebaseStore.upsertHistoryItem(item);
    } catch (_) {}
  }

  Future<void> remove(String videoPath) async {
    final history = await getHistory();
    history.removeWhere((e) => e.videoPath == videoPath);
    await _saveLocalHistory(history);
    try {
      await _firebaseStore.removeHistoryItem(videoPath);
    } catch (_) {}

    // Remove any generated assets mapped to this video
    try {
      await removeGeneratedAssets(videoPath);
    } catch (_) {}
  }

  Future<void> clearHistory() async {
    await _saveLocalHistory([]);
    try {
      await _firebaseStore.clearHistory();
    } catch (_) {}
    // Clear generated assets mapping and delete files
    try {
      final prefs = await SharedPreferences.getInstance();
      final key = 'generatedAssets';
      final raw = prefs.getString(key);
      if (raw != null && raw.isNotEmpty) {
        final Map<String, dynamic> map = jsonDecode(raw) as Map<String, dynamic>;
        for (final entry in map.entries) {
          try {
            final data = entry.value as Map<String, dynamic>;
            if (data['srt'] != null) {
              final f = File(data['srt'] as String);
              if (await f.exists()) await f.delete();
            }
            if (data['dubbed'] != null) {
              final f = File(data['dubbed'] as String);
              if (await f.exists()) await f.delete();
            }
          } catch (_) {}
        }
        await prefs.remove(key);
      }
    } catch (_) {}
  }

  // ─── Last Position ─────────────────────────────────────────────────────────

  Future<Duration?> getLastPosition(String videoPath) async {
    try {
      final remote = await _firebaseStore.getLastPosition(videoPath);
      if (remote != null) return remote;
    } catch (_) {}

    final prefs = await SharedPreferences.getInstance();
    final key = '${AppConstants.lastPositionPrefix}${videoPath.hashCode}';
    final ms = prefs.getInt(key);
    return ms != null ? Duration(milliseconds: ms) : null;
  }

  Future<void> savePosition(String videoPath, Duration position) async {
    final prefs = await SharedPreferences.getInstance();
    final key = '${AppConstants.lastPositionPrefix}${videoPath.hashCode}';
    await prefs.setInt(key, position.inMilliseconds);
    try {
      await _firebaseStore.savePosition(videoPath, position);
    } catch (_) {}
  }

  Future<void> clearPosition(String videoPath) async {
    final prefs = await SharedPreferences.getInstance();
    final key = '${AppConstants.lastPositionPrefix}${videoPath.hashCode}';
    await prefs.remove(key);
    try {
      await _firebaseStore.clearPosition(videoPath);
    } catch (_) {}
  }

  // ─── Generated assets mapping ─────────────────────────────────────────────

  Future<void> saveGeneratedAssets(String videoPath, {String? srtPath, String? dubbedPath}) async {
    final prefs = await SharedPreferences.getInstance();
    final key = 'generatedAssets';
    final raw = prefs.getString(key);
    final Map<String, dynamic> map = raw != null && raw.isNotEmpty
        ? jsonDecode(raw) as Map<String, dynamic>
        : <String, dynamic>{};

    final existing = map[videoPath] as Map<String, dynamic>? ?? <String, dynamic>{};
    if (srtPath != null) existing['srt'] = srtPath;
    if (dubbedPath != null) existing['dubbed'] = dubbedPath;
    map[videoPath] = existing;
    await prefs.setString(key, jsonEncode(map));
  }

  Future<Map<String, String>?> getGeneratedAssets(String videoPath) async {
    final prefs = await SharedPreferences.getInstance();
    final key = 'generatedAssets';
    final raw = prefs.getString(key);
    if (raw == null || raw.isEmpty) return null;
    try {
      final Map<String, dynamic> map = jsonDecode(raw) as Map<String, dynamic>;
      final data = map[videoPath] as Map<String, dynamic>?;
      if (data == null) return null;
      final result = <String, String>{};
      if (data['srt'] != null) result['srt'] = data['srt'] as String;
      if (data['dubbed'] != null) result['dubbed'] = data['dubbed'] as String;
      return result;
    } catch (_) {
      return null;
    }
  }

  Future<void> removeGeneratedAssets(String videoPath) async {
    final prefs = await SharedPreferences.getInstance();
    final key = 'generatedAssets';
    final raw = prefs.getString(key);
    if (raw == null || raw.isEmpty) return;
    try {
      final Map<String, dynamic> map = jsonDecode(raw) as Map<String, dynamic>;
      final data = map.remove(videoPath) as Map<String, dynamic>?;
      if (data != null) {
        if (data['srt'] != null) {
          try {
            final f = File(data['srt'] as String);
            if (await f.exists()) await f.delete();
          } catch (_) {}
        }
        if (data['dubbed'] != null) {
          try {
            final f = File(data['dubbed'] as String);
            if (await f.exists()) await f.delete();
          } catch (_) {}
        }
      }
      await prefs.setString(key, jsonEncode(map));
    } catch (_) {}
  }

  Future<List<PlaybackHistoryItem>> _loadLocalHistory() async {
    final prefs = await SharedPreferences.getInstance();
    final raw = prefs.getStringList(AppConstants.historyKey) ?? [];
    return raw
        .map((e) {
          try {
            return PlaybackHistoryItem.fromJson(jsonDecode(e) as Map<String, dynamic>);
          } catch (_) {
            return null;
          }
        })
        .whereType<PlaybackHistoryItem>()
        .toList()
      ..sort((a, b) => b.lastPlayed.compareTo(a.lastPlayed));
  }

  Future<void> _saveLocalHistory(List<PlaybackHistoryItem> history) async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.setStringList(
      AppConstants.historyKey,
      history.map((e) => jsonEncode(e.toJson())).toList(),
    );
  }

  List<PlaybackHistoryItem> _mergeHistory(
    List<PlaybackHistoryItem> local,
    List<PlaybackHistoryItem> remote,
  ) {
    final merged = <String, PlaybackHistoryItem>{};
    for (final item in [...local, ...remote]) {
      final current = merged[item.videoPath];
      if (current == null || item.lastPlayed.isAfter(current.lastPlayed)) {
        merged[item.videoPath] = item;
      }
    }

    final items = merged.values.toList()
      ..sort((a, b) => b.lastPlayed.compareTo(a.lastPlayed));
    if (items.length > AppConstants.maxHistoryItems) {
      return items.sublist(0, AppConstants.maxHistoryItems);
    }
    return items;
  }
}

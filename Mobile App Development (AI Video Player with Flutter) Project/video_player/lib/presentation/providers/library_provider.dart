import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../../data/models/video_model.dart';
import '../../data/models/player_settings.dart';
import '../../data/services/media_scanner_service.dart';

class LibraryProvider extends ChangeNotifier {
  final MediaScannerService _scanner;

  List<VideoModel> _allVideos = [];
  List<VideoModel> _filteredVideos = [];
  Map<String, List<VideoModel>> _folderMap = {};
  bool _isScanning = false;
  bool _hasPermission = false;
  String _searchQuery = '';
  SortBy _sortBy = SortBy.date;
  SortOrder _sortOrder = SortOrder.descending;
  String? _error;

  LibraryProvider(this._scanner);

  List<VideoModel> get videos => _filteredVideos;
  Map<String, List<VideoModel>> get folders => _folderMap;
  bool get isScanning => _isScanning;
  bool get hasPermission => _hasPermission;
  String? get error => _error;
  int get totalVideos => _allVideos.length;

  static const _cacheKey = 'library_video_cache';

  // ── Called on every app start ──────────────────────────────────────────────
  // 1) Instantly shows cached videos (no spinner if cache exists).
  // 2) Then silently scans in background and updates the list.
  Future<void> initLibrary() async {
    await _loadCache();
    // If there's cached data, show it immediately without a loading spinner
    // then refresh silently.
    if (_allVideos.isEmpty) {
      // First launch – need a full scan with a progress indicator.
      await requestPermissionAndScan();
    } else {
      // Cache hit – show instantly, refresh in background.
      _scanInBackground();
    }
  }

  // Full scan with loading indicator (first launch / permission grant).
  Future<void> requestPermissionAndScan() async {
    _isScanning = true;
    _error = null;
    notifyListeners();
    await _scan();
  }

  // Silent background scan – no spinner shown to user.
  void _scanInBackground() {
    _scan(silent: true);
  }

  Future<void> refresh() async {
    await _scan();
  }

  Future<void> _scan({bool silent = false}) async {
    if (!silent) {
      _isScanning = true;
      _error = null;
      notifyListeners();
    }
    try {
      final result = await _scanner.scanDevice();
      _hasPermission = result.hasPermission;

      if (!_hasPermission) {
        _error = 'Permission denied. Please grant media access in Settings → App Permissions.';
        _isScanning = false;
        notifyListeners();
        return;
      }

      _allVideos = result.videos;
      _folderMap = _scanner.groupByFolder(_allVideos);
      _applyFilters();
      await _saveCache();
    } catch (e) {
      _error = 'Error scanning: $e';
    }
    _isScanning = false;
    notifyListeners();
  }

  // ── Cache helpers ────────────────────────────────────────────────────────

  Future<void> _saveCache() async {
    try {
      final prefs = await SharedPreferences.getInstance();
      final json = jsonEncode(_allVideos.map((v) => v.toJson()).toList());
      await prefs.setString(_cacheKey, json);
    } catch (_) {}
  }

  Future<void> _loadCache() async {
    try {
      final prefs = await SharedPreferences.getInstance();
      final raw = prefs.getString(_cacheKey);
      if (raw == null) return;
      final list = (jsonDecode(raw) as List)
          .map((e) => VideoModel.fromJson(e as Map<String, dynamic>))
          .toList();
      // Filter out files that no longer exist on disk.
      _allVideos = list.where((v) {
        try { return File(v.path).existsSync(); } catch (_) { return false; }
      }).toList();
      _folderMap = _scanner.groupByFolder(_allVideos);
      _hasPermission = true;
      _applyFilters();
      notifyListeners();
    } catch (_) {}
  }

  void search(String query) {
    _searchQuery = query;
    _applyFilters();
    notifyListeners();
  }

  void setSortBy(SortBy by, SortOrder order) {
    _sortBy = by;
    _sortOrder = order;
    _applyFilters();
    notifyListeners();
  }

  void addVideo(VideoModel video) {
    if (!_allVideos.any((v) => v.path == video.path)) {
      _allVideos.add(video);
      _folderMap = _scanner.groupByFolder(_allVideos);
      _applyFilters();
      notifyListeners();
      _saveCache();
    }
  }

  void removeVideo(String path) {
    _allVideos.removeWhere((v) => v.path == path);
    _folderMap = _scanner.groupByFolder(_allVideos);
    _applyFilters();
    notifyListeners();
    _saveCache();
  }

  List<VideoModel> videosInFolder(String folder) {
    return _folderMap[folder] ?? [];
  }

  void _applyFilters() {
    var list = _allVideos.where((v) {
      if (_searchQuery.isEmpty) return true;
      return v.name.toLowerCase().contains(_searchQuery.toLowerCase());
    }).toList();

    list.sort((a, b) {
      int cmp;
      switch (_sortBy) {
        case SortBy.name:
          cmp = a.name.toLowerCase().compareTo(b.name.toLowerCase());
        case SortBy.date:
          cmp = a.dateAdded.compareTo(b.dateAdded);
        case SortBy.size:
          cmp = a.size.compareTo(b.size);
        case SortBy.duration:
          cmp = (a.duration?.inMilliseconds ?? 0)
              .compareTo(b.duration?.inMilliseconds ?? 0);
      }
      return _sortOrder == SortOrder.ascending ? cmp : -cmp;
    });

    _filteredVideos = list;
  }
}

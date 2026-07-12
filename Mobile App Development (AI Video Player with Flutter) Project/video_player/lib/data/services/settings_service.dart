import 'dart:convert';
import 'package:shared_preferences/shared_preferences.dart';
import '../models/player_settings.dart';
import '../../core/constants/app_constants.dart';
import 'firebase_user_data_service.dart';

class SettingsService {
  final _firebaseStore = FirebaseUserDataService();

  Future<PlayerSettings> load() async {
    try {
      final remote = await _firebaseStore.loadSettings();
      if (remote != null) {
        await _saveLocal(remote);
        return remote;
      }
    } catch (_) {}

    final local = await _loadLocal();
    try {
      await _firebaseStore.saveSettings(local);
    } catch (_) {}
    return local;
  }

  Future<void> save(PlayerSettings settings) async {
    await _saveLocal(settings);
    try {
      await _firebaseStore.saveSettings(settings);
    } catch (_) {}
  }

  Future<PlayerSettings> _loadLocal() async {
    final prefs = await SharedPreferences.getInstance();
    final raw = prefs.getString(AppConstants.settingsKey);
    if (raw == null) return const PlayerSettings();
    try {
      return PlayerSettings.fromJson(jsonDecode(raw) as Map<String, dynamic>);
    } catch (_) {
      return const PlayerSettings();
    }
  }

  Future<void> _saveLocal(PlayerSettings settings) async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.setString(AppConstants.settingsKey, jsonEncode(settings.toJson()));
  }
}

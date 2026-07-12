import 'package:flutter/material.dart';
import '../../data/models/player_settings.dart';
import '../../data/services/settings_service.dart';

class SettingsProvider extends ChangeNotifier {
  final SettingsService _service;

  PlayerSettings _settings = const PlayerSettings();
  bool _loaded = false;

  SettingsProvider(this._service);

  PlayerSettings get settings => _settings;
  bool get loaded => _loaded;

  Future<void> load() async {
    _settings = await _service.load();
    _loaded = true;
    notifyListeners();
  }

  Future<void> update(PlayerSettings updated) async {
    _settings = updated;
    notifyListeners();
    await _service.save(updated);
  }

  Future<void> toggle({
    bool? hardwareDecoding,
    bool? autoPlayNext,
    bool? resumePlayback,
    bool? loopVideo,
    bool? shufflePlaylist,
    bool? gesturesEnabled,
    bool? brightnessGesture,
    bool? volumeGesture,
    bool? seekGesture,
    bool? autoHideControls,
    bool? darkMode,
    bool? keepScreenOn,
    bool? showHiddenFolders,
  }) async {
    await update(_settings.copyWith(
      hardwareDecoding: hardwareDecoding,
      autoPlayNext: autoPlayNext,
      resumePlayback: resumePlayback,
      loopVideo: loopVideo,
      shufflePlaylist: shufflePlaylist,
      gesturesEnabled: gesturesEnabled,
      brightnessGesture: brightnessGesture,
      volumeGesture: volumeGesture,
      seekGesture: seekGesture,
      autoHideControls: autoHideControls,
      darkMode: darkMode,
      keepScreenOn: keepScreenOn,
      showHiddenFolders: showHiddenFolders,
    ));
  }

  Future<void> setSpeed(double speed) async {
    await update(_settings.copyWith(playbackSpeed: speed));
  }

  Future<void> setSortBy(SortBy by) async {
    await update(_settings.copyWith(sortBy: by));
  }

  Future<void> setSortOrder(SortOrder order) async {
    await update(_settings.copyWith(sortOrder: order));
  }

  Future<void> updateSubtitle(SubtitleSettings sub) async {
    await update(_settings.copyWith(subtitle: sub));
  }
}

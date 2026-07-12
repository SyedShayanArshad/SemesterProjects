import 'package:flutter/material.dart';

class PlayerSettings {
  final bool hardwareDecoding;
  final bool autoPlayNext;
  final bool resumePlayback;
  final bool loopVideo;
  final bool shufflePlaylist;
  final double playbackSpeed;
  final bool gesturesEnabled;
  final bool brightnessGesture;
  final bool volumeGesture;
  final bool seekGesture;
  final bool autoHideControls;
  final int autoHideDelay; // seconds
  final SubtitleSettings subtitle;
  final bool darkMode;
  final bool keepScreenOn;
  final SortOrder sortOrder;
  final SortBy sortBy;
  final bool showHiddenFolders;

  const PlayerSettings({
    this.hardwareDecoding = true,
    this.autoPlayNext = true,
    this.resumePlayback = true,
    this.loopVideo = false,
    this.shufflePlaylist = false,
    this.playbackSpeed = 1.0,
    this.gesturesEnabled = true,
    this.brightnessGesture = true,
    this.volumeGesture = true,
    this.seekGesture = true,
    this.autoHideControls = true,
    this.autoHideDelay = 3,
    this.subtitle = const SubtitleSettings(),
    this.darkMode = false,
    this.keepScreenOn = true,
    this.sortOrder = SortOrder.descending,
    this.sortBy = SortBy.date,
    this.showHiddenFolders = false,
  });

  PlayerSettings copyWith({
    bool? hardwareDecoding,
    bool? autoPlayNext,
    bool? resumePlayback,
    bool? loopVideo,
    bool? shufflePlaylist,
    double? playbackSpeed,
    bool? gesturesEnabled,
    bool? brightnessGesture,
    bool? volumeGesture,
    bool? seekGesture,
    bool? autoHideControls,
    int? autoHideDelay,
    SubtitleSettings? subtitle,
    bool? darkMode,
    bool? keepScreenOn,
    SortOrder? sortOrder,
    SortBy? sortBy,
    bool? showHiddenFolders,
  }) {
    return PlayerSettings(
      hardwareDecoding: hardwareDecoding ?? this.hardwareDecoding,
      autoPlayNext: autoPlayNext ?? this.autoPlayNext,
      resumePlayback: resumePlayback ?? this.resumePlayback,
      loopVideo: loopVideo ?? this.loopVideo,
      shufflePlaylist: shufflePlaylist ?? this.shufflePlaylist,
      playbackSpeed: playbackSpeed ?? this.playbackSpeed,
      gesturesEnabled: gesturesEnabled ?? this.gesturesEnabled,
      brightnessGesture: brightnessGesture ?? this.brightnessGesture,
      volumeGesture: volumeGesture ?? this.volumeGesture,
      seekGesture: seekGesture ?? this.seekGesture,
      autoHideControls: autoHideControls ?? this.autoHideControls,
      autoHideDelay: autoHideDelay ?? this.autoHideDelay,
      subtitle: subtitle ?? this.subtitle,
      darkMode: darkMode ?? this.darkMode,
      keepScreenOn: keepScreenOn ?? this.keepScreenOn,
      sortOrder: sortOrder ?? this.sortOrder,
      sortBy: sortBy ?? this.sortBy,
      showHiddenFolders: showHiddenFolders ?? this.showHiddenFolders,
    );
  }

  Map<String, dynamic> toJson() => {
    'hardwareDecoding': hardwareDecoding,
    'autoPlayNext': autoPlayNext,
    'resumePlayback': resumePlayback,
    'loopVideo': loopVideo,
    'shufflePlaylist': shufflePlaylist,
    'playbackSpeed': playbackSpeed,
    'gesturesEnabled': gesturesEnabled,
    'brightnessGesture': brightnessGesture,
    'volumeGesture': volumeGesture,
    'seekGesture': seekGesture,
    'autoHideControls': autoHideControls,
    'autoHideDelay': autoHideDelay,
    'subtitle': subtitle.toJson(),
    'darkMode': darkMode,
    'keepScreenOn': keepScreenOn,
    'sortOrder': sortOrder.index,
    'sortBy': sortBy.index,
    'showHiddenFolders': showHiddenFolders,
  };

  factory PlayerSettings.fromJson(Map<String, dynamic> json) => PlayerSettings(
    hardwareDecoding: json['hardwareDecoding'] as bool? ?? true,
    autoPlayNext: json['autoPlayNext'] as bool? ?? true,
    resumePlayback: json['resumePlayback'] as bool? ?? true,
    loopVideo: json['loopVideo'] as bool? ?? false,
    shufflePlaylist: json['shufflePlaylist'] as bool? ?? false,
    playbackSpeed: (json['playbackSpeed'] as num?)?.toDouble() ?? 1.0,
    gesturesEnabled: json['gesturesEnabled'] as bool? ?? true,
    brightnessGesture: json['brightnessGesture'] as bool? ?? true,
    volumeGesture: json['volumeGesture'] as bool? ?? true,
    seekGesture: json['seekGesture'] as bool? ?? true,
    autoHideControls: json['autoHideControls'] as bool? ?? true,
    autoHideDelay: json['autoHideDelay'] as int? ?? 3,
    subtitle: json['subtitle'] != null
        ? SubtitleSettings.fromJson(json['subtitle'] as Map<String, dynamic>)
        : const SubtitleSettings(),
    darkMode: json['darkMode'] as bool? ?? false,
    keepScreenOn: json['keepScreenOn'] as bool? ?? true,
    sortOrder: SortOrder.values[json['sortOrder'] as int? ?? 0],
    sortBy: SortBy.values[json['sortBy'] as int? ?? 0],
    showHiddenFolders: json['showHiddenFolders'] as bool? ?? false,
  );
}

class SubtitleSettings {
  final bool enabled;
  final double fontSize;
  final Color textColor;
  final Color backgroundColor;
  final double backgroundOpacity;
  final SubtitlePosition position;
  final int delayMs; // milliseconds
  final String encoding;

  const SubtitleSettings({
    this.enabled = true,
    this.fontSize = 16.0,
    this.textColor = Colors.white,
    this.backgroundColor = Colors.black,
    this.backgroundOpacity = 0.5,
    this.position = SubtitlePosition.bottom,
    this.delayMs = 0,
    this.encoding = 'UTF-8',
  });

  SubtitleSettings copyWith({
    bool? enabled,
    double? fontSize,
    Color? textColor,
    Color? backgroundColor,
    double? backgroundOpacity,
    SubtitlePosition? position,
    int? delayMs,
    String? encoding,
  }) {
    return SubtitleSettings(
      enabled: enabled ?? this.enabled,
      fontSize: fontSize ?? this.fontSize,
      textColor: textColor ?? this.textColor,
      backgroundColor: backgroundColor ?? this.backgroundColor,
      backgroundOpacity: backgroundOpacity ?? this.backgroundOpacity,
      position: position ?? this.position,
      delayMs: delayMs ?? this.delayMs,
      encoding: encoding ?? this.encoding,
    );
  }

  Map<String, dynamic> toJson() => {
    'enabled': enabled,
    'fontSize': fontSize,
    'textColor': textColor.toARGB32(),
    'backgroundColor': backgroundColor.toARGB32(),
    'backgroundOpacity': backgroundOpacity,
    'position': position.index,
    'delayMs': delayMs,
    'encoding': encoding,
  };

  factory SubtitleSettings.fromJson(Map<String, dynamic> json) => SubtitleSettings(
    enabled: json['enabled'] as bool? ?? true,
    fontSize: (json['fontSize'] as num?)?.toDouble() ?? 16.0,
    textColor: Color(json['textColor'] as int? ?? 0xFFFFFFFF),
    backgroundColor: Color(json['backgroundColor'] as int? ?? 0xFF000000),
    backgroundOpacity: (json['backgroundOpacity'] as num?)?.toDouble() ?? 0.5,
    position: SubtitlePosition.values[json['position'] as int? ?? 0],
    delayMs: json['delayMs'] as int? ?? 0,
    encoding: json['encoding'] as String? ?? 'UTF-8',
  );
}

enum SubtitlePosition { top, center, bottom }
enum SortOrder { ascending, descending }
enum SortBy { name, date, size, duration }

import 'dart:async';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:screen_brightness/screen_brightness.dart';
import 'package:volume_controller/volume_controller.dart';
import '../../providers/player_provider.dart';
import '../../providers/settings_provider.dart';
import '../../../core/constants/app_constants.dart';

enum _GestureZone { left, right, center }

class GestureOverlay extends StatefulWidget {
  final Widget child;
  const GestureOverlay({super.key, required this.child});

  @override
  State<GestureOverlay> createState() => _GestureOverlayState();
}

class _GestureOverlayState extends State<GestureOverlay> {
  double? _brightness;
  double? _volume;

  _GestureZone? _activeZone;
  Offset? _dragAnchor;
  double _baseScale = 1.0;
  bool _isPinching = false;

  // Seek gesture accumulator
  Duration _seekDelta = Duration.zero;

  // Feedback overlay
  String? _feedbackText;
  IconData? _feedbackIcon;
  Timer? _feedbackTimer;

  void _showFeedback(String text, IconData icon) {
    _feedbackText = text;
    _feedbackIcon = icon;
    _feedbackTimer?.cancel();
    _feedbackTimer = Timer(const Duration(seconds: 1), () {
      if (mounted) setState(() { _feedbackText = null; });
    });
    if (mounted) setState(() {});
  }

  _GestureZone _zoneOf(Offset pos, Size size) {
    if (pos.dx < size.width / 3) return _GestureZone.left;
    if (pos.dx > size.width * 2 / 3) return _GestureZone.right;
    return _GestureZone.center;
  }

  Future<void> _initBrightness() async {
    try {
      _brightness = await ScreenBrightness().current;
    } catch (_) {
      _brightness = 0.5;
    }
  }

  Future<void> _initVolume() async {
    try {
      _volume = await VolumeController().getVolume();
    } catch (_) {
      _volume = 0.5;
    }
  }

  @override
  Widget build(BuildContext context) {
    final settings = context.watch<SettingsProvider>().settings;
    final player = context.watch<PlayerProvider>();

    return GestureDetector(
      behavior: HitTestBehavior.translucent,
      onTap: player.toggleControls,
      onDoubleTapDown: (d) {
        final box = context.findRenderObject() as RenderBox?;
        if (box == null) return;
        final pos = box.globalToLocal(d.globalPosition);
        final zone = _zoneOf(pos, box.size);
        if (zone == _GestureZone.left) {
          player.seekBackward(AppConstants.seekSeconds);
          _showFeedback('-${AppConstants.seekSeconds}s', Icons.replay_10_rounded);
        } else if (zone == _GestureZone.right) {
          player.seekForward(AppConstants.seekSeconds);
          _showFeedback('+${AppConstants.seekSeconds}s', Icons.forward_10_rounded);
        }
      },

      // Scale handles single-finger pan (brightness/volume/seek) AND pinch-zoom
      onScaleStart: settings.gesturesEnabled
          ? (d) async {
              _isPinching = d.pointerCount >= 2;
              _baseScale = player.scale;
              _dragAnchor = d.focalPoint;
              _seekDelta = Duration.zero;

              if (!_isPinching) {
                final box = context.findRenderObject() as RenderBox?;
                if (box != null) {
                  final pos = box.globalToLocal(d.focalPoint);
                  _activeZone = _zoneOf(pos, box.size);
                  if (_activeZone == _GestureZone.left &&
                      settings.brightnessGesture) {
                    await _initBrightness();
                  } else if (_activeZone == _GestureZone.right &&
                      settings.volumeGesture) {
                    await _initVolume();
                  }
                }
              }
            }
          : null,

      onScaleUpdate: settings.gesturesEnabled
          ? (d) async {
              if (d.pointerCount >= 2) {
                // ══ Pinch-to-zoom ════════════════════════════════════════════
                _isPinching = true;
                final newScale = (_baseScale * d.scale).clamp(0.3, 5.0);
                player.setScale(newScale);
                _showFeedback(
                    '${newScale.toStringAsFixed(1)}x', Icons.zoom_in_rounded);
              } else if (!_isPinching && _dragAnchor != null) {
                // ══ Single-finger pan ══════════════════════════════════════
                final dy = _dragAnchor!.dy - d.focalPoint.dy;
                final dx = d.focalPoint.dx - _dragAnchor!.dx;
                _dragAnchor = d.focalPoint;

                if (_activeZone == _GestureZone.left &&
                    settings.brightnessGesture) {
                  // Brightness: swipe up/down on left side
                  _brightness =
                      ((_brightness ?? 0.5) + dy / 200).clamp(0.0, 1.0);
                  try {
                    await ScreenBrightness()
                        .setScreenBrightness(_brightness!);
                  } catch (_) {}
                  _showFeedback(
                    '${(_brightness! * 100).toInt()}%',
                    Icons.brightness_6_rounded,
                  );
                } else if (_activeZone == _GestureZone.right &&
                    settings.volumeGesture) {
                  // Volume: swipe up/down on right side
                  _volume =
                      ((_volume ?? 0.5) + dy / 200).clamp(0.0, 1.0);
                  try {
                    VolumeController().setVolume(_volume!);
                  } catch (_) {}
                  _showFeedback(
                    '${(_volume! * 100).toInt()}%',
                    _volume! == 0
                        ? Icons.volume_off
                        : Icons.volume_up_rounded,
                  );
                } else if (_activeZone == _GestureZone.center &&
                    settings.seekGesture) {
                  // Seek: swipe left/right in center (1 px ≈ 125 ms)
                  _seekDelta +=
                      Duration(milliseconds: (dx * 125).round());
                  _showFeedback(
                    _seekDelta.inSeconds >= 0
                        ? '+${_seekDelta.inSeconds}s'
                        : '${_seekDelta.inSeconds}s',
                    _seekDelta.inSeconds >= 0
                        ? Icons.forward_10_rounded
                        : Icons.replay_10_rounded,
                  );
                }
              }
            }
          : null,

      onScaleEnd: settings.gesturesEnabled
          ? (_) {
              if (!_isPinching &&
                  _seekDelta != Duration.zero &&
                  _activeZone == _GestureZone.center) {
                final current = context.read<PlayerProvider>().position;
                final newPos = current + _seekDelta;
                context.read<PlayerProvider>().seekTo(
                      newPos < Duration.zero ? Duration.zero : newPos,
                    );
              }
              _seekDelta = Duration.zero;
              _isPinching = false;
              _activeZone = null;
              _dragAnchor = null;
            }
          : null,
      child: Stack(
        fit: StackFit.expand,
        children: [
          widget.child,
          if (_feedbackText != null)
            Center(
              child: Container(
                padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 12),
                decoration: BoxDecoration(
                  color: Colors.black54,
                  borderRadius: BorderRadius.circular(12),
                ),
                child: Row(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Icon(_feedbackIcon, color: Colors.white, size: 28),
                    const SizedBox(width: 8),
                    Text(
                      _feedbackText!,
                      style: const TextStyle(
                        color: Colors.white,
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ],
                ),
              ),
            ),
        ],
      ),
    );
  }

  @override
  void dispose() {
    _feedbackTimer?.cancel();
    super.dispose();
  }
}

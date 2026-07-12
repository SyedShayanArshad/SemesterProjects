import 'package:flutter/material.dart';
import '../../../data/services/subtitle_service.dart';

/// Overlays the current subtitle cue on top of the video.
class SubtitleOverlay extends StatelessWidget {
  final List<SubtitleCue> cues;
  final Duration position;

  const SubtitleOverlay({
    super.key,
    required this.cues,
    required this.position,
  });

  @override
  Widget build(BuildContext context) {
    final current = _currentCue();
    if (current == null) return const SizedBox.shrink();

    return Positioned(
      left: 16,
      right: 16,
      bottom: 40,
      child: IgnorePointer(
        child: Container(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 6),
          decoration: BoxDecoration(
            color: Colors.black.withValues(alpha: 0.60),
            borderRadius: BorderRadius.circular(6),
          ),
          child: Text(
            current.text,
            textAlign: TextAlign.center,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 20,
              fontWeight: FontWeight.w600,
              letterSpacing: 0.5,
              height: 1.3,
              shadows: [
                Shadow(
                  blurRadius: 4,
                  color: Colors.black,
                  offset: Offset(2, 2),
                ),
                Shadow(
                  blurRadius: 8,
                  color: Colors.black,
                  offset: Offset(0, 0),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  SubtitleCue? _currentCue() {
    for (final cue in cues) {
      if (position >= cue.start && position <= cue.end) {
        return cue;
      }
    }
    return null;
  }
}

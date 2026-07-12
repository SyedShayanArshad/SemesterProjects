import 'package:flutter/material.dart';

class VideoSeekBar extends StatefulWidget {
  final Duration position;
  final Duration duration;
  final void Function(Duration) onSeek;
  final Duration? abStart;
  final Duration? abEnd;

  const VideoSeekBar({
    super.key,
    required this.position,
    required this.duration,
    required this.onSeek,
    this.abStart,
    this.abEnd,
  });

  @override
  State<VideoSeekBar> createState() => _VideoSeekBarState();
}

class _VideoSeekBarState extends State<VideoSeekBar> {
  double? _dragValue;

  double get _progress {
    if (widget.duration.inMilliseconds == 0) return 0;
    if (_dragValue != null) return _dragValue!;
    return widget.position.inMilliseconds / widget.duration.inMilliseconds;
  }

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onHorizontalDragStart: (d) {},
      onHorizontalDragUpdate: (d) {
        final box = context.findRenderObject() as RenderBox?;
        if (box == null) return;
        final value = (d.localPosition.dx / box.size.width).clamp(0.0, 1.0);
        setState(() => _dragValue = value);
      },
      onHorizontalDragEnd: (_) {
        if (_dragValue != null) {
          final seekMs = (_dragValue! * widget.duration.inMilliseconds).round();
          widget.onSeek(Duration(milliseconds: seekMs));
          setState(() => _dragValue = null);
        }
      },
      child: SizedBox(
        height: 36,
        child: CustomPaint(
          painter: _SeekBarPainter(
            progress: _progress,
            abStart: widget.abStart != null && widget.duration.inMilliseconds > 0
                ? widget.abStart!.inMilliseconds / widget.duration.inMilliseconds
                : null,
            abEnd: widget.abEnd != null && widget.duration.inMilliseconds > 0
                ? widget.abEnd!.inMilliseconds / widget.duration.inMilliseconds
                : null,
          ),
          size: const Size(double.infinity, 36),
        ),
      ),
    );
  }
}

class _SeekBarPainter extends CustomPainter {
  final double progress;
  final double? abStart;
  final double? abEnd;

  _SeekBarPainter({required this.progress, this.abStart, this.abEnd});

  @override
  void paint(Canvas canvas, Size size) {
    final cy = size.height / 2;
    final trackH = 4.0;
    final thumbR = 8.0;

    // Background track
    canvas.drawRRect(
      RRect.fromRectAndRadius(
        Rect.fromLTWH(0, cy - trackH / 2, size.width, trackH),
        const Radius.circular(4),
      ),
      Paint()..color = Colors.white24,
    );

    // A-B region
    if (abStart != null && abEnd != null) {
      canvas.drawRRect(
        RRect.fromRectAndRadius(
          Rect.fromLTWH(
            abStart! * size.width,
            cy - trackH / 2,
            (abEnd! - abStart!) * size.width,
            trackH,
          ),
          const Radius.circular(4),
        ),
        Paint()..color = Colors.orange.withValues(alpha: 0.7),
      );
    }

    // Played track
    final playedW = progress * size.width;
    canvas.drawRRect(
      RRect.fromRectAndRadius(
        Rect.fromLTWH(0, cy - trackH / 2, playedW, trackH),
        const Radius.circular(4),
      ),
      Paint()..color = const Color(0xFF42A5F5),
    );

    // Thumb
    canvas.drawCircle(
      Offset(playedW, cy),
      thumbR,
      Paint()..color = const Color(0xFF42A5F5),
    );
    canvas.drawCircle(
      Offset(playedW, cy),
      thumbR - 2,
      Paint()..color = Colors.white,
    );
  }

  @override
  bool shouldRepaint(covariant _SeekBarPainter old) =>
      old.progress != progress || old.abStart != abStart || old.abEnd != abEnd;
}

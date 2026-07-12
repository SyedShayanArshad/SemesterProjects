import 'dart:io';
import 'package:flutter/material.dart';
import '../../../data/models/video_model.dart';
import '../../../data/services/thumbnail_service.dart';
import '../../../core/utils/duration_utils.dart';
import '../../../core/theme/app_theme.dart';

class VideoCard extends StatelessWidget {
  final VideoModel video;
  final VoidCallback onTap;
  final VoidCallback? onLongPress;
  final double? resumeProgress;

  const VideoCard({
    super.key,
    required this.video,
    required this.onTap,
    this.onLongPress,
    this.resumeProgress,
  });

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final isDark = theme.brightness == Brightness.dark;

    return Material(
      color: isDark ? const Color(0xFF1A1A28) : Colors.white,
      borderRadius: BorderRadius.circular(16),
      clipBehavior: Clip.antiAlias,
      elevation: isDark ? 0 : 2,
      shadowColor: Colors.black12,
      child: InkWell(
        borderRadius: BorderRadius.circular(16),
        onTap: onTap,
        onLongPress: onLongPress,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // ── Thumbnail ──────────────────────────────────────────────
            Expanded(
              child: Stack(
                fit: StackFit.expand,
                children: [
                  FutureBuilder<String?>(
                    future: ThumbnailService.instance.getThumbnail(video.path),
                    builder: (context, snap) {
                      final thumbPath = snap.data;
                      if (thumbPath != null && File(thumbPath).existsSync()) {
                        return Image.file(
                          File(thumbPath),
                          fit: BoxFit.cover,
                          width: double.infinity,
                          height: double.infinity,
                          errorBuilder: (_, p2, p3) => _Placeholder(isDark: isDark),
                        );
                      }
                      // Show placeholder while loading
                      return _Placeholder(isDark: isDark);
                    },
                  ),

                  // Gradient overlay (bottom fade for readability)
                  Positioned(
                    bottom: 0,
                    left: 0,
                    right: 0,
                    height: 56,
                    child: DecoratedBox(
                      decoration: BoxDecoration(
                        gradient: LinearGradient(
                          begin: Alignment.topCenter,
                          end: Alignment.bottomCenter,
                          colors: [
                            Colors.transparent,
                            Colors.black.withValues(alpha: 0.65),
                          ],
                        ),
                      ),
                    ),
                  ),

                  // Extension badge (top-left)
                  Positioned(
                    top: 8,
                    left: 8,
                    child: _ExtBadge(ext: video.extension),
                  ),

                  // Duration badge (bottom-right)
                  if (video.duration != null)
                    Positioned(
                      bottom: 8,
                      right: 8,
                      child: Container(
                        padding: const EdgeInsets.symmetric(
                            horizontal: 7, vertical: 3),
                        decoration: BoxDecoration(
                          color: Colors.black87,
                          borderRadius: BorderRadius.circular(6),
                        ),
                        child: Text(
                          DurationUtils.format(video.duration!),
                          style: const TextStyle(
                              color: Colors.white,
                              fontSize: 10,
                              fontWeight: FontWeight.w600),
                        ),
                      ),
                    ),

                  // Resume progress bar
                  if (resumeProgress != null && resumeProgress! > 0)
                    Positioned(
                      bottom: 0,
                      left: 0,
                      right: 0,
                      child: LinearProgressIndicator(
                        value: resumeProgress!.clamp(0.0, 1.0),
                        minHeight: 3,
                        backgroundColor: Colors.white12,
                        valueColor:
                            const AlwaysStoppedAnimation(AppTheme.accent),
                      ),
                    ),

                  // Play icon overlay (visible on placeholder)
                  Positioned.fill(
                    child: FutureBuilder<String?>(
                      future: ThumbnailService.instance.getThumbnail(video.path),
                      builder: (context, snap) {
                        if (snap.data == null) return const SizedBox.shrink();
                        return const SizedBox.shrink();
                      },
                    ),
                  ),
                ],
              ),
            ),

            // ── Info section ──────────────────────────────────────────
            Padding(
              padding: const EdgeInsets.fromLTRB(10, 8, 10, 10),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    video.displayName,
                    style: theme.textTheme.bodyMedium?.copyWith(
                      fontWeight: FontWeight.w700,
                      fontSize: 12.5,
                    ),
                    maxLines: 2,
                    overflow: TextOverflow.ellipsis,
                  ),
                  const SizedBox(height: 4),
                  Text(
                    video.sizeFormatted,
                    style: theme.textTheme.bodySmall?.copyWith(
                      color: theme.colorScheme.onSurface
                          .withValues(alpha: 0.45),
                      fontSize: 11,
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}

// ── Private helpers ──────────────────────────────────────────────────────────

class _Placeholder extends StatelessWidget {
  final bool isDark;
  const _Placeholder({required this.isDark});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: isDark ? const Color(0xFF0D0D18) : const Color(0xFFE8E8F0),
      child: Center(
        child: Icon(
          Icons.play_circle_outline_rounded,
          size: 44,
          color: isDark ? Colors.white10 : const Color(0x1A000000),
        ),
      ),
    );
  }
}

class _ExtBadge extends StatelessWidget {
  final String ext;
  const _ExtBadge({required this.ext});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 6, vertical: 3),
      decoration: BoxDecoration(
        color: AppTheme.accent.withValues(alpha: 0.85),
        borderRadius: BorderRadius.circular(6),
      ),
      child: Text(
        ext.toUpperCase(),
        style: const TextStyle(
            color: Colors.white, fontSize: 9, fontWeight: FontWeight.w800),
      ),
    );
  }
}
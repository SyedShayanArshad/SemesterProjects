import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../../../core/utils/duration_utils.dart';
import '../../providers/player_provider.dart';

class AbRepeatControl extends StatelessWidget {
  const AbRepeatControl({super.key});

  @override
  Widget build(BuildContext context) {
    final player = context.watch<PlayerProvider>();

    return Padding(
      padding: const EdgeInsets.all(20),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          const Text(
            'A-B Repeat',
            style: TextStyle(
                color: Colors.white, fontSize: 16, fontWeight: FontWeight.bold),
          ),
          const SizedBox(height: 20),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              _AbButton(
                label: 'Set A',
                value: player.abStart != null
                    ? DurationUtils.format(player.abStart!)
                    : '--:--',
                isSet: player.abStart != null,
                onTap: player.setAbStart,
              ),
              _AbButton(
                label: 'Set B',
                value: player.abEnd != null
                    ? DurationUtils.format(player.abEnd!)
                    : '--:--',
                isSet: player.abEnd != null,
                onTap: player.setAbEnd,
              ),
              _AbButton(
                label: 'Clear',
                value: '',
                isSet: false,
                onTap: () {
                  player.clearAbRepeat();
                  Navigator.pop(context);
                },
                icon: Icons.clear_rounded,
              ),
            ],
          ),
          const SizedBox(height: 16),
          if (player.abRepeatActive)
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
              decoration: BoxDecoration(
                color: Colors.orange.withValues(alpha: 0.2),
                borderRadius: BorderRadius.circular(8),
                border: Border.all(color: Colors.orange),
              ),
              child: Text(
                'Repeating: ${DurationUtils.format(player.abStart!)} → ${DurationUtils.format(player.abEnd!)}',
                style: const TextStyle(color: Colors.orange),
              ),
            ),
        ],
      ),
    );
  }
}

class _AbButton extends StatelessWidget {
  final String label;
  final String value;
  final bool isSet;
  final VoidCallback onTap;
  final IconData? icon;

  const _AbButton({
    required this.label,
    required this.value,
    required this.isSet,
    required this.onTap,
    this.icon,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Container(
        width: 90,
        padding: const EdgeInsets.symmetric(vertical: 12),
        decoration: BoxDecoration(
          color: isSet ? Colors.orange.withValues(alpha: 0.2) : Colors.grey[800],
          borderRadius: BorderRadius.circular(10),
          border: isSet ? Border.all(color: Colors.orange) : null,
        ),
        child: Column(
          children: [
            if (icon != null)
              Icon(icon, color: Colors.white70)
            else ...[
              Text(label, style: const TextStyle(color: Colors.white70, fontSize: 12)),
              const SizedBox(height: 4),
              Text(
                value,
                style: TextStyle(
                  color: isSet ? Colors.orange : Colors.white38,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ],
          ],
        ),
      ),
    );
  }
}

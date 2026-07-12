import 'package:flutter/material.dart';

class SleepTimerDialog extends StatelessWidget {
  final Duration? remaining;
  final void Function(Duration) onSet;
  final VoidCallback onCancel;

  const SleepTimerDialog({
    super.key,
    this.remaining,
    required this.onSet,
    required this.onCancel,
  });

  static const _presets = [
    Duration(minutes: 5),
    Duration(minutes: 10),
    Duration(minutes: 15),
    Duration(minutes: 30),
    Duration(minutes: 45),
    Duration(hours: 1),
    Duration(hours: 2),
  ];

  @override
  Widget build(BuildContext context) {
    final selected = _selectedPreset(remaining);

    return Padding(
      padding: const EdgeInsets.all(20),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          const Text(
            'Sleep Timer',
            style: TextStyle(
              color: Colors.white,
              fontSize: 16,
              fontWeight: FontWeight.bold,
            ),
          ),
          const SizedBox(height: 8),
          Flexible(
            child: ListView(
              shrinkWrap: true,
              children: [
                ListTile(
                  title: const Text('Off', style: TextStyle(color: Colors.white)),
                  trailing: remaining == null
                      ? const Icon(Icons.check_rounded, color: Colors.white)
                      : null,
                  onTap: onCancel,
                ),
                ..._presets.map((d) {
                  final isSelected = selected == d;
                  return ListTile(
                    title: Text(_optionLabel(d),
                        style: const TextStyle(color: Colors.white)),
                    trailing: isSelected
                        ? const Icon(Icons.check_rounded, color: Colors.white)
                        : null,
                    onTap: () => onSet(d),
                  );
                }),
              ],
            ),
          ),
          Align(
            alignment: Alignment.centerRight,
            child: TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Cancel'),
            ),
          ),
        ],
      ),
    );
  }

  Duration? _selectedPreset(Duration? value) {
    if (value == null) return null;
    for (final preset in _presets) {
      if ((preset.inSeconds - value.inSeconds).abs() <= 60) {
        return preset;
      }
    }
    return null;
  }

  String _optionLabel(Duration d) {
    if (d.inHours > 0) {
      final mins = d.inMinutes.remainder(60);
      return mins == 0 ? '${d.inHours} hour' : '${d.inHours}h ${mins}m';
    }
    return '${d.inMinutes} minutes';
  }
}

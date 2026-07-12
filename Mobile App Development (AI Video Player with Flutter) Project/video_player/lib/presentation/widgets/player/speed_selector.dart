import 'package:flutter/material.dart';
import '../../../core/constants/app_constants.dart';

class SpeedSelector extends StatefulWidget {
  final double currentSpeed;
  final void Function(double) onSpeedSelected;

  const SpeedSelector({
    super.key,
    required this.currentSpeed,
    required this.onSpeedSelected,
  });

  @override
  State<SpeedSelector> createState() => _SpeedSelectorState();
}

class _SpeedSelectorState extends State<SpeedSelector> {
  late double _customSpeed;

  @override
  void initState() {
    super.initState();
    _customSpeed = widget.currentSpeed;
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          const Padding(
            padding: EdgeInsets.fromLTRB(16, 16, 16, 8),
            child: Text(
              'Playback Speed',
              style: TextStyle(
                color: Colors.white,
                fontSize: 16,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          Flexible(
            child: ListView(
              shrinkWrap: true,
              children: [
                ...AppConstants.speedOptions.map((speed) {
                  final isSelected =
                      (speed - widget.currentSpeed).abs() < 0.01;
                  return ListTile(
                    title: Text(
                      '${speed}x',
                      style: const TextStyle(color: Colors.white),
                    ),
                    trailing: isSelected
                        ? const Icon(Icons.check_rounded, color: Colors.white)
                        : null,
                    onTap: () {
                      setState(() => _customSpeed = speed);
                      widget.onSpeedSelected(speed);
                    },
                  );
                }),
                const Divider(color: Colors.white24, height: 1),
                Padding(
                  padding: const EdgeInsets.fromLTRB(16, 10, 16, 2),
                  child: Text(
                    'Custom: ${_customSpeed.toStringAsFixed(2)}x',
                    style: const TextStyle(color: Colors.white70, fontSize: 13),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 12),
                  child: Slider(
                    min: 0.1,
                    max: 3.0,
                    value: _customSpeed.clamp(0.1, 3.0),
                    divisions: 58,
                    label: '${_customSpeed.toStringAsFixed(2)}x',
                    activeColor: const Color(0xFF42A5F5),
                    inactiveColor: Colors.grey[700],
                    onChanged: (v) => setState(() => _customSpeed = v),
                    onChangeEnd: (v) {
                      final rounded = double.parse(v.toStringAsFixed(2));
                      widget.onSpeedSelected(rounded);
                    },
                  ),
                ),
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
}

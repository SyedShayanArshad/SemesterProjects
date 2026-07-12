import 'package:flutter/material.dart';

class LockScreenOverlay extends StatelessWidget {
  final VoidCallback onUnlock;
  const LockScreenOverlay({super.key, required this.onUnlock});

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {}, // absorb all taps
      child: Container(
        color: Colors.transparent,
        child: Align(
          alignment: Alignment.centerLeft,
          child: Padding(
            padding: const EdgeInsets.only(left: 20),
            child: GestureDetector(
              onTap: onUnlock,
              child: Container(
                padding: const EdgeInsets.all(12),
                decoration: BoxDecoration(
                  color: Colors.black54,
                  borderRadius: BorderRadius.circular(30),
                ),
                child: const Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Icon(Icons.lock, color: Colors.white, size: 28),
                    SizedBox(height: 4),
                    Text('Tap to\nunlock',
                        textAlign: TextAlign.center,
                        style: TextStyle(color: Colors.white70, fontSize: 11)),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}

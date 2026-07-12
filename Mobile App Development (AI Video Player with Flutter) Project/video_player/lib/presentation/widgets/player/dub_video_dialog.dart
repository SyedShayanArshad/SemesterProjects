import 'package:flutter/material.dart';
import '../../../data/services/dub_service.dart';
import '../../../data/services/processing_tracker.dart';

/// Shown when the user taps "Dub Video".
/// Guides the user through: language picker → progress → done.
class DubVideoDialog extends StatefulWidget {
  final String videoPath;
  const DubVideoDialog({super.key, required this.videoPath});

  @override
  State<DubVideoDialog> createState() => _DubVideoDialogState();
}

class _DubVideoDialogState extends State<DubVideoDialog> {
  // ── State ─────────────────────────────────────────────────────────────────
  bool _loadingLanguages = true;
  List<DubLanguage> _languages = [];
  String? _selectedLang;

  bool _running = false;
  bool _done = false;
  String? _error;
  String _status = '';
  int _percent = 0;
  String? _dubbedVideoPath;

  @override
  void initState() {
    super.initState();
    _loadLanguages();
  }

  Future<void> _loadLanguages() async {
    try {
      final langs = await DubService.fetchDubLanguages();
      if (mounted) {
        setState(() {
          _languages = langs;
          _selectedLang = langs.isNotEmpty ? langs.first.code : null;
          _loadingLanguages = false;
        });
      }
    } catch (e) {
      if (mounted) {
        setState(() {
          _error = 'Could not load languages: $e';
          _loadingLanguages = false;
        });
      }
    }
  }

  Future<void> _startDubbing() async {
    if (_selectedLang == null) return;
    setState(() {
      _running = true;
      _error = null;
      _percent = 0;
      _status = 'Starting…';
    });

    try {
      final task = ProcessingTracker.createTask(
        name: 'Dubbing Generation',
        videoPath: widget.videoPath,
        targetLanguage: _selectedLang,
      );

      final result = await DubService.generateDub(
        videoPath: widget.videoPath,
        targetLanguage: _selectedLang!,
        task: task,
        onStatusUpdate: (s) {
          if (mounted) setState(() => _status = s);
        },
        onProgressUpdate: (p) {
          if (mounted) setState(() => _percent = p);
        },
      );
      if (mounted) {
        setState(() {
          _done = true;
          _running = false;
          _dubbedVideoPath = result.dubbedVideoPath;
          _percent = 100;
          _status = 'Done!';
        });
      }
    } catch (e) {
      if (mounted) {
        setState(() {
          _error = e.toString();
          _running = false;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    final maxHeight = MediaQuery.sizeOf(context).height * 0.85;
    return Dialog(
      backgroundColor: const Color(0xFF1E1E1E),
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
      insetPadding: const EdgeInsets.symmetric(horizontal: 28, vertical: 40),
      child: ConstrainedBox(
        constraints: BoxConstraints(maxHeight: maxHeight),
        child: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.all(24),
            child: _running || _done ? _buildProgress() : _buildPicker(),
          ),
        ),
      ),
    );
  }

  // ── Language picker ───────────────────────────────────────────────────────
  Widget _buildPicker() {
    return Column(
      mainAxisSize: MainAxisSize.min,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        const Row(
          children: [
            Icon(Icons.record_voice_over_rounded,
                color: Colors.deepPurpleAccent, size: 22),
            SizedBox(width: 8),
            Text(
              'Dub Video (AI Voice Clone)',
              style: TextStyle(
                  color: Colors.white,
                  fontSize: 16,
                  fontWeight: FontWeight.w700),
            ),
          ],
        ),
        const SizedBox(height: 6),
        const Text(
          'Clones the speaker\'s voice and translates it to the selected language. '
          'May take several minutes.',
          style: TextStyle(color: Colors.white54, fontSize: 12),
        ),
        const SizedBox(height: 20),

        if (_loadingLanguages)
          const Center(
              child: CircularProgressIndicator(color: Colors.deepPurpleAccent))
        else if (_error != null)
          Text(_error!, style: const TextStyle(color: Colors.redAccent))
        else ...[
          const Text('Target language',
              style: TextStyle(color: Colors.white70, fontSize: 13)),
          const SizedBox(height: 8),
          _LanguageDropdown(
            languages: _languages,
            selected: _selectedLang,
            onChanged: (c) => setState(() => _selectedLang = c),
          ),
        ],
        const SizedBox(height: 24),
        Row(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Cancel',
                  style: TextStyle(color: Colors.white54)),
            ),
            const SizedBox(width: 8),
            ElevatedButton.icon(
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.deepPurpleAccent,
                foregroundColor: Colors.white,
                shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10)),
              ),
              icon: const Icon(Icons.mic_rounded, size: 18),
              label: const Text('Start Dubbing'),
              onPressed: (_loadingLanguages || _selectedLang == null || _error != null)
                  ? null
                  : _startDubbing,
            ),
          ],
        ),
      ],
    );
  }

  // ── Progress view ─────────────────────────────────────────────────────────
  Widget _buildProgress() {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        // Circular progress with % in center
        SizedBox(
          width: 72,
          height: 72,
          child: Stack(
            alignment: Alignment.center,
            children: [
              SizedBox.expand(
                child: CircularProgressIndicator(
                  value: _percent / 100,
                  strokeWidth: 5,
                  backgroundColor: Colors.white10,
                  valueColor: const AlwaysStoppedAnimation(Colors.deepPurpleAccent),
                ),
              ),
              Text(
                '$_percent%',
                style: const TextStyle(
                    color: Colors.white,
                    fontSize: 16,
                    fontWeight: FontWeight.bold),
              ),
            ],
          ),
        ),
        const SizedBox(height: 12),

        // Linear bar
        ClipRRect(
          borderRadius: BorderRadius.circular(4),
          child: LinearProgressIndicator(
            value: _percent / 100,
            minHeight: 5,
            backgroundColor: Colors.white10,
            valueColor:
                const AlwaysStoppedAnimation(Colors.deepPurpleAccent),
          ),
        ),
        const SizedBox(height: 10),

        // Status text
        Text(
          _error != null ? 'Error' : _status,
          textAlign: TextAlign.center,
          style: TextStyle(
              color: _error != null ? Colors.redAccent : Colors.white70,
              fontSize: 13),
        ),

        if (_error != null) ...[
          const SizedBox(height: 6),
          Text(_error!,
              textAlign: TextAlign.center,
              style: const TextStyle(color: Colors.redAccent, fontSize: 11)),
          const SizedBox(height: 10),
          TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Close',
                  style: TextStyle(color: Colors.white54))),
        ],

        if (_done && _error == null) ...[
          const SizedBox(height: 14),
          ElevatedButton.icon(
            style: ElevatedButton.styleFrom(
              backgroundColor: Colors.deepPurpleAccent,
              foregroundColor: Colors.white,
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8)),
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
            ),
            icon: const Icon(Icons.play_arrow_rounded, size: 18),
            label: const Text('Play Dubbed Version', style: TextStyle(fontSize: 13)),
            onPressed: () => Navigator.pop(context, _dubbedVideoPath),
          ),
          const SizedBox(height: 4),
          TextButton(
            onPressed: () => Navigator.pop(context, null),
            style: TextButton.styleFrom(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 4),
              minimumSize: Size.zero,
            ),
            child: const Text('Keep Original',
                style: TextStyle(color: Colors.white38, fontSize: 12)),
          ),
        ],

        if (!_done && _error == null) ...[
          const SizedBox(height: 10),
          TextButton.icon(
            onPressed: () {
              Navigator.of(context).pop();
              ScaffoldMessenger.of(context).showSnackBar(
                const SnackBar(
                  content: Text('Dubbing in background...'),
                  behavior: SnackBarBehavior.floating,
                ),
              );
            },
            icon: const Icon(Icons.keyboard_arrow_down_rounded, size: 20),
            label: const Text('Run in background', style: TextStyle(fontSize: 12)),
            style: TextButton.styleFrom(
              foregroundColor: Colors.deepPurpleAccent,
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
              minimumSize: Size.zero,
            ),
          ),
        ],
      ],
    );
  }
}

// ── Language dropdown ─────────────────────────────────────────────────────────
class _LanguageDropdown extends StatelessWidget {
  final List<DubLanguage> languages;
  final String? selected;
  final ValueChanged<String?> onChanged;

  const _LanguageDropdown({
    required this.languages,
    required this.selected,
    required this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 12),
      decoration: BoxDecoration(
        color: Colors.white10,
        borderRadius: BorderRadius.circular(10),
      ),
      child: DropdownButtonHideUnderline(
        child: DropdownButton<String>(
          value: selected,
          isExpanded: true,
          dropdownColor: const Color(0xFF2A2A2A),
          style: const TextStyle(color: Colors.white, fontSize: 14),
          iconEnabledColor: Colors.white54,
          onChanged: onChanged,
          items: languages
              .map((l) => DropdownMenuItem(
                    value: l.code,
                    child: Text(l.name),
                  ))
              .toList(),
        ),
      ),
    );
  }
}

import 'package:flutter/material.dart';
import '../../../data/services/subtitle_service.dart';
import '../../../data/services/processing_tracker.dart';

/// Dialog that lets the user pick a language and then triggers AI subtitle
/// generation. Shows progress status while working.
class GenerateSubtitleDialog extends StatefulWidget {
  final String videoPath;

  const GenerateSubtitleDialog({super.key, required this.videoPath});

  @override
  State<GenerateSubtitleDialog> createState() => _GenerateSubtitleDialogState();
}

class _GenerateSubtitleDialogState extends State<GenerateSubtitleDialog> {
  List<Map<String, String>> _languages = [];
  String _selectedLanguage = 'auto';
  String _selectedModel = 'base';
  bool _loading = false;
  bool _fetchingLanguages = true;
  String _status = '';
  String? _error;
  int _percent = 0;

  final List<Map<String, String>> _modelOptions = [
    {'value': 'tiny', 'label': 'Tiny (fastest)'},
    {'value': 'base', 'label': 'Base (recommended)'},
    {'value': 'small', 'label': 'Small (better quality)'},
    {'value': 'medium', 'label': 'Medium (high quality)'},
    {'value': 'large', 'label': 'Large (best quality)'},
  ];

  @override
  void initState() {
    super.initState();
    _loadLanguages();
  }

  Future<void> _loadLanguages() async {
    final langs = await SubtitleService.fetchLanguages();
    if (mounted) {
      setState(() {
        _languages = langs;
        _fetchingLanguages = false;
      });
    }
  }

  Future<void> _generate() async {
    setState(() {
      _loading = true;
      _error = null;
      _status = 'Starting…';
      _percent = 0;
    });

    try {
      final task = ProcessingTracker.createTask(
        name: 'Subtitle Generation',
        videoPath: widget.videoPath,
        targetLanguage: _selectedLanguage,
      );

      final result = await SubtitleService.generateSubtitles(
        videoPath: widget.videoPath,
        language: _selectedLanguage,
        modelSize: _selectedModel,
        task: task,
        onStatusUpdate: (s) {
          if (mounted) setState(() => _status = s);
        },
        onProgressUpdate: (p) {
          if (mounted) setState(() => _percent = p);
        },
      );

      if (mounted) {
        Navigator.of(context).pop(result);
      }
    } catch (e) {
      if (mounted) {
        setState(() {
          _loading = false;
          _error = e.toString().replaceFirst('Exception: ', '');
          _status = '';
          _percent = 0;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      scrollable: true,
      backgroundColor: Colors.grey[900],
      title: const Text(
        'Generate Subtitles',
        style: TextStyle(color: Colors.white),
      ),
      content: SizedBox(
        width: double.maxFinite,
        child: _loading ? _buildProgress() : _buildForm(),
      ),
      actions: _loading
          ? null
          : [
              TextButton(
                onPressed: () => Navigator.of(context).pop(),
                child: const Text('Cancel'),
              ),
              ElevatedButton.icon(
                onPressed: _fetchingLanguages ? null : _generate,
                icon: const Icon(Icons.auto_awesome),
                label: const Text('Generate'),
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blueAccent,
                  foregroundColor: Colors.white,
                ),
              ),
            ],
    );
  }

  Widget _buildProgress() {
    final isTranscribing = _percent > 0;
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        // ── Circular progress with % in center ──────────────────────────
        SizedBox(
          width: 72,
          height: 72,
          child: Stack(
            alignment: Alignment.center,
            children: [
              SizedBox(
                width: 72,
                height: 72,
                child: CircularProgressIndicator(
                  value: isTranscribing ? _percent / 100 : null,
                  strokeWidth: 6,
                  color: Colors.blueAccent,
                  backgroundColor: Colors.white12,
                ),
              ),
              if (isTranscribing)
                Text(
                  '$_percent%',
                  style: const TextStyle(
                    color: Colors.white,
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                  ),
                )
              else
                const Icon(Icons.auto_awesome, color: Colors.blueAccent, size: 24),
            ],
          ),
        ),

        const SizedBox(height: 12),

        // ── Status text ─────────────────────────────────────────────────
        Text(
          _status,
          style: const TextStyle(color: Colors.white, fontSize: 13),
          textAlign: TextAlign.center,
        ),

        const SizedBox(height: 8),

        // ── Linear progress bar ─────────────────────────────────────────
        ClipRRect(
          borderRadius: BorderRadius.circular(6),
          child: LinearProgressIndicator(
            value: isTranscribing ? _percent / 100 : null,
            minHeight: 5,
            color: Colors.blueAccent,
            backgroundColor: Colors.white12,
          ),
        ),

        const SizedBox(height: 8),

        Text(
          isTranscribing
              ? 'Transcribing… $_percent% complete'
              : 'Preparing transcription…',
          style: const TextStyle(color: Colors.white54, fontSize: 11),
          textAlign: TextAlign.center,
        ),

        const SizedBox(height: 4),
        const Text(
          'Audio is deleted from server as soon as subtitles are ready.',
          style: TextStyle(color: Colors.white38, fontSize: 10),
          textAlign: TextAlign.center,
        ),

        const SizedBox(height: 10),
        TextButton.icon(
          onPressed: () {
            Navigator.of(context).pop();
            ScaffoldMessenger.of(context).showSnackBar(
              const SnackBar(
                content: Text('Processing subtitles in background...'),
                behavior: SnackBarBehavior.floating,
              ),
            );
          },
          icon: const Icon(Icons.keyboard_arrow_down_rounded, size: 20),
          label: const Text('Run in background', style: TextStyle(fontSize: 12)),
          style: TextButton.styleFrom(
            foregroundColor: Colors.blueAccent,
            minimumSize: Size.zero,
            padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 8),
          ),
        ),
      ],
    );
  }

  Widget _buildForm() {
    return Column(
      mainAxisSize: MainAxisSize.min,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        if (_error != null) ...[
          Container(
            padding: const EdgeInsets.all(10),
            decoration: BoxDecoration(
              color: Colors.red.withValues(alpha: 0.2),
              borderRadius: BorderRadius.circular(6),
              border: Border.all(color: Colors.red.withValues(alpha: 0.4)),
            ),
            child: Row(
              children: [
                const Icon(Icons.error_outline, color: Colors.red, size: 18),
                const SizedBox(width: 8),
                Expanded(
                  child: Text(
                    _error!,
                    style: const TextStyle(color: Colors.red, fontSize: 12),
                  ),
                ),
              ],
            ),
          ),
          const SizedBox(height: 16),
        ],

        const Text(
          'Language',
          style: TextStyle(color: Colors.white70, fontSize: 13),
        ),
        const SizedBox(height: 6),
        _fetchingLanguages
            ? const Center(
                child: Padding(
                  padding: EdgeInsets.all(8.0),
                  child: CircularProgressIndicator(strokeWidth: 2),
                ),
              )
            : DropdownButtonFormField<String>(
                initialValue: _selectedLanguage,
                dropdownColor: Colors.grey[850],
                style: const TextStyle(color: Colors.white),
                decoration: InputDecoration(
                  filled: true,
                  fillColor: Colors.grey[800],
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(8),
                    borderSide: BorderSide.none,
                  ),
                  contentPadding:
                      const EdgeInsets.symmetric(horizontal: 12, vertical: 10),
                ),
                items: _languages
                    .map(
                      (l) => DropdownMenuItem<String>(
                        value: l['code'],
                        child: Text(l['name']!),
                      ),
                    )
                    .toList(),
                onChanged: (v) {
                  if (v != null) setState(() => _selectedLanguage = v);
                },
              ),

        const SizedBox(height: 16),

        const Text(
          'Model (Quality vs Speed)',
          style: TextStyle(color: Colors.white70, fontSize: 13),
        ),
        const SizedBox(height: 6),
        DropdownButtonFormField<String>(
          initialValue: _selectedModel,
          dropdownColor: Colors.grey[850],
          style: const TextStyle(color: Colors.white),
          decoration: InputDecoration(
            filled: true,
            fillColor: Colors.grey[800],
            border: OutlineInputBorder(
              borderRadius: BorderRadius.circular(8),
              borderSide: BorderSide.none,
            ),
            contentPadding:
                const EdgeInsets.symmetric(horizontal: 12, vertical: 10),
          ),
          items: _modelOptions
              .map(
                (m) => DropdownMenuItem<String>(
                  value: m['value'],
                  child: Text(m['label']!),
                ),
              )
              .toList(),
          onChanged: (v) {
            if (v != null) setState(() => _selectedModel = v);
          },
        ),

        const SizedBox(height: 12),
        const Text(
          'Audio will be temporarily extracted, sent to the AI server, then deleted.',
          style: TextStyle(color: Colors.white38, fontSize: 11),
        ),
      ],
    );
  }
}

import 'dart:io';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/player_provider.dart';
import '../widgets/common/empty_state.dart';
import '../../data/models/video_model.dart';
import '../../data/services/history_service.dart';
import '../../data/models/playback_history_item.dart';
import '../../core/utils/duration_utils.dart';
import 'player_screen.dart';

class HistoryScreen extends StatefulWidget {
  const HistoryScreen({super.key});

  @override
  State<HistoryScreen> createState() => _HistoryScreenState();
}

class _HistoryScreenState extends State<HistoryScreen> {
  List<PlaybackHistoryItem> _history = [];
  bool _loading = true;

  @override
  void initState() {
    super.initState();
    _loadHistory();
  }

  @override
  void dispose() {
    super.dispose();
  }

  Future<void> _loadHistory() async {
    final h = await context.read<HistoryService>().getHistory();
    if (mounted) {
      setState(() {
        _history = h;
        _loading = false;
      });
    }
  }

  Future<void> _clearHistory() async {
    final confirm = await showDialog<bool>(
      context: context,
      builder: (_) => AlertDialog(
        title: const Text('Clear History'),
        content: const Text('Remove all playback history?'),
        actions: [
          TextButton(onPressed: () => Navigator.pop(context, false), child: const Text('Cancel')),
          TextButton(
            onPressed: () => Navigator.pop(context, true),
            child: const Text('Clear', style: TextStyle(color: Colors.red)),
          ),
        ],
      ),
    );
    if (confirm == true && mounted) {
      await context.read<HistoryService>().clearHistory();
      setState(() => _history = []);
    }
  }

  Future<void> _openVideo(PlaybackHistoryItem item) async {
    final file = File(item.videoPath);
    if (!file.existsSync()) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('File not found: ${item.videoName}')),
      );
      return;
    }
    final video = VideoModel.fromFile(file);

    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => MultiProvider(
          providers: [
            ChangeNotifierProvider(
              create: (_) => PlayerProvider(context.read()),
            ),
          ],
          child: PlayerScreen(playlist: [video]),
        ),
      ),
    ).then((_) => _loadHistory());
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: Navigator.canPop(context)
            ? IconButton(
                icon: const Icon(Icons.arrow_back_rounded),
                onPressed: () => Navigator.pop(context),
              )
            : null,
        title: const Text('History'),
        actions: [
          if (_history.isNotEmpty)
            IconButton(
              icon: const Icon(Icons.delete_sweep_outlined),
              onPressed: _clearHistory,
              tooltip: 'Clear History',
            ),
        ],
      ),
      body: RefreshIndicator(
        onRefresh: _loadHistory,
        child: ListView(
          padding: const EdgeInsets.all(8),
          children: [
            const Padding(
              padding: EdgeInsets.fromLTRB(8, 4, 8, 10),
              child: Text(
                'Recently Played',
                style: TextStyle(fontSize: 13, fontWeight: FontWeight.w700),
              ),
            ),
            if (_loading)
              const Padding(
                padding: EdgeInsets.symmetric(vertical: 40),
                child: Center(child: CircularProgressIndicator()),
              )
            else if (_history.isEmpty)
              const EmptyState(
                icon: Icons.history_toggle_off,
                title: 'No history yet',
                subtitle: 'Videos you watch will appear here',
              )
            else
              ..._history.map(
                (item) => _HistoryTile(
                  item: item,
                  onTap: () => _openVideo(item),
                  onRemove: () async {
                    await context.read<HistoryService>().remove(item.videoPath);
                    _loadHistory();
                  },
                ),
              ),
          ],
        ),
      ),
    );
  }
}

class _HistoryTile extends StatelessWidget {
  final PlaybackHistoryItem item;
  final VoidCallback onTap;
  final VoidCallback onRemove;

  const _HistoryTile({
    required this.item,
    required this.onTap,
    required this.onRemove,
  });

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final progress = item.progress;

    return Card(
      child: ListTile(
        leading: SizedBox(
          width: 56,
          height: 56,
          child: Stack(
            fit: StackFit.expand,
            children: [
              Container(
                decoration: BoxDecoration(
                  color: Colors.black,
                  borderRadius: BorderRadius.circular(6),
                ),
                child: const Icon(Icons.play_circle_fill_rounded,
                    color: Colors.white38, size: 32),
              ),
              if (progress > 0)
                Positioned(
                  bottom: 0,
                  left: 0,
                  right: 0,
                  child: LinearProgressIndicator(
                    value: progress.clamp(0.0, 1.0),
                    minHeight: 3,
                    backgroundColor: Colors.white24,
                    valueColor: const AlwaysStoppedAnimation(Color(0xFF42A5F5)),
                  ),
                ),
            ],
          ),
        ),
        title: Text(item.videoName, maxLines: 2, overflow: TextOverflow.ellipsis),
        subtitle: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              '${DurationUtils.format(item.lastPosition)}'
              '${item.totalDuration != null ? ' / ${DurationUtils.format(item.totalDuration!)}' : ''}',
              style: const TextStyle(fontSize: 12),
            ),
            Text(
              _timeAgo(item.lastPlayed),
              style: TextStyle(fontSize: 11, color: theme.colorScheme.onSurface.withValues(alpha: 0.5)),
            ),
          ],
        ),
        trailing: IconButton(
          icon: const Icon(Icons.close, size: 18),
          onPressed: onRemove,
        ),
        isThreeLine: true,
        onTap: onTap,
      ),
    );
  }

  String _timeAgo(DateTime dt) {
    final diff = DateTime.now().difference(dt);
    if (diff.inSeconds < 60) return 'Just now';
    if (diff.inMinutes < 60) return '${diff.inMinutes}m ago';
    if (diff.inHours < 24) return '${diff.inHours}h ago';
    if (diff.inDays < 7) return '${diff.inDays}d ago';
    return '${dt.day}/${dt.month}/${dt.year}';
  }
}

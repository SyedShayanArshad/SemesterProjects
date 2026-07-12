import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../../../core/utils/duration_utils.dart';
import '../../providers/player_provider.dart';
import '../../../data/models/bookmark_model.dart';

class BookmarkPanel extends StatelessWidget {
  const BookmarkPanel({super.key});

  @override
  Widget build(BuildContext context) {
    final player = context.watch<PlayerProvider>();
    final bookmarks = player.bookmarks;

    return DraggableScrollableSheet(
      initialChildSize: 0.65,
      minChildSize: 0.35,
      maxChildSize: 0.92,
      expand: false,
      builder: (_, ctrl) => Stack(
        children: [
          Container(color: Colors.transparent),
          Align(
            alignment: Alignment.bottomCenter,
            child: Container(
              decoration: BoxDecoration(
                color: Colors.grey[900],
                borderRadius:
                    const BorderRadius.vertical(top: Radius.circular(18)),
              ),
              child: Column(
                children: [
                  Container(
                    padding: const EdgeInsets.only(top: 10, bottom: 8),
                    child: Center(
                      child: Container(
                        width: 42,
                        height: 4,
                        decoration: BoxDecoration(
                          color: Colors.white24,
                          borderRadius: BorderRadius.circular(2),
                        ),
                      ),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 16),
                    child: Row(
                      children: [
                        const Text(
                          'Bookmarks',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 16,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        const Spacer(),
                        FilledButton.tonalIcon(
                          onPressed: () => _addBookmark(context),
                          icon: const Icon(Icons.add_rounded),
                          label: const Text('Add'),
                        ),
                      ],
                    ),
                  ),
                  Expanded(
                    child: bookmarks.isEmpty
                        ? const Center(
                            child: Text(
                              'No bookmarks yet',
                              style: TextStyle(color: Colors.white54),
                            ),
                          )
                        : ListView.separated(
                            controller: ctrl,
                            itemCount: bookmarks.length,
                            separatorBuilder: (_, _) => const Divider(
                              height: 1,
                              color: Colors.white12,
                            ),
                            itemBuilder: (_, i) => _BookmarkRow(
                              bookmark: bookmarks[i],
                              onTap: () {
                                player.seekToBookmark(bookmarks[i]);
                                Navigator.pop(context);
                              },
                              onDelete: () =>
                                  player.removeBookmark(bookmarks[i].id),
                            ),
                          ),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }

  void _addBookmark(BuildContext context) {
    final ctrl = TextEditingController();
    showDialog(
      context: context,
      builder: (ctx) => AlertDialog(
        backgroundColor: Colors.grey[900],
        title: const Text('Add Bookmark', style: TextStyle(color: Colors.white)),
        content: TextField(
          controller: ctrl,
          style: const TextStyle(color: Colors.black),
          cursorColor: Colors.black,
          decoration: const InputDecoration(
            hintText: 'Bookmark name',
            hintStyle: TextStyle(color: Colors.black54),
            filled: true,
            fillColor: Colors.white,
            border: OutlineInputBorder(),
          ),
          autofocus: true,
        ),
        actions: [
          TextButton(onPressed: () => Navigator.pop(ctx), child: const Text('Cancel')),
          TextButton(
            onPressed: () {
              context.read<PlayerProvider>().addBookmark(
                    ctrl.text.isEmpty ? 'Bookmark' : ctrl.text,
                  );
              Navigator.pop(ctx);
            },
            child: const Text('Add'),
          ),
        ],
      ),
    );
  }
}

class _BookmarkRow extends StatelessWidget {
  final BookmarkModel bookmark;
  final VoidCallback onTap;
  final VoidCallback onDelete;

  const _BookmarkRow({
    required this.bookmark,
    required this.onTap,
    required this.onDelete,
  });

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onTap,
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
        child: Row(
          children: [
            Text(
              DurationUtils.format(bookmark.position),
              style: const TextStyle(
                color: Colors.amber,
                fontWeight: FontWeight.w600,
              ),
            ),
            const SizedBox(width: 12),
            Expanded(
              child: Text(
                bookmark.label,
                maxLines: 1,
                overflow: TextOverflow.ellipsis,
                style: const TextStyle(color: Colors.white),
              ),
            ),
            IconButton(
              icon: const Icon(Icons.delete_outline, color: Colors.red),
              onPressed: onDelete,
            ),
          ],
        ),
      ),
    );
  }
}

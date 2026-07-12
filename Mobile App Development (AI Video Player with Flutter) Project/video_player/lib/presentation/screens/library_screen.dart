import 'package:flutter/material.dart';
import 'package:file_picker/file_picker.dart';
import 'package:provider/provider.dart';
import 'package:share_plus/share_plus.dart';
import 'dart:io';
import '../providers/library_provider.dart';
import '../providers/settings_provider.dart';
import '../providers/player_provider.dart';
import '../widgets/library/video_card.dart';
import '../widgets/library/folder_card.dart';
import '../widgets/common/empty_state.dart';
import '../../data/models/video_model.dart';
import '../../data/models/player_settings.dart';
import '../../data/services/thumbnail_service.dart';
import '../../core/constants/app_constants.dart';
import '../../core/utils/duration_utils.dart';
import 'player_screen.dart';
import 'folder_screen.dart';

class LibraryScreen extends StatefulWidget {
  const LibraryScreen({super.key});

  @override
  State<LibraryScreen> createState() => _LibraryScreenState();
}

class _LibraryScreenState extends State<LibraryScreen>
    with SingleTickerProviderStateMixin {
  late TabController _tabController;
  final _searchController = TextEditingController();
  bool _isGrid = true;

  @override
  void initState() {
    super.initState();
    _tabController = TabController(length: 2, vsync: this);
    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<LibraryProvider>().initLibrary();
    });
  }

  @override
  void dispose() {
    _tabController.dispose();
    _searchController.dispose();
    super.dispose();
  }

  Future<void> _pickVideoFile() async {
    final lib = context.read<LibraryProvider>();
    final result = await FilePicker.platform.pickFiles(
      type: FileType.custom,
      allowedExtensions: AppConstants.supportedVideoExtensions,
      allowMultiple: true,
    );
    if (result == null) return;
    for (final f in result.files) {
      if (f.path != null) {
        lib.addVideo(VideoModel.fromFile(File(f.path!)));
      }
    }
  }

  Future<void> _openVideo(VideoModel video, List<VideoModel> playlist) async {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (_) => MultiProvider(
          providers: [
            ChangeNotifierProvider(
              create: (_) => PlayerProvider(context.read()),
            ),
          ],
          child: PlayerScreen(
            playlist: playlist,
            startIndex: playlist.indexOf(video),
          ),
        ),
      ),
    );
  }

  void _showSortDialog() {
    final lib = context.read<LibraryProvider>();
    final settings = context.read<SettingsProvider>();
    showModalBottomSheet(
      context: context,
      builder: (_) => _SortBottomSheet(
        currentBy: settings.settings.sortBy,
        currentOrder: settings.settings.sortOrder,
        onApply: (by, order) {
          lib.setSortBy(by, order);
          settings.setSortBy(by);
          settings.setSortOrder(order);
        },
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final isDark = theme.brightness == Brightness.dark;
    final lib = context.watch<LibraryProvider>();

    return Scaffold(
      appBar: AppBar(
        leading: Navigator.canPop(context)
            ? IconButton(
                icon: const Icon(Icons.arrow_back_rounded),
                onPressed: () => Navigator.pop(context),
              )
            : null,
        title: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisSize: MainAxisSize.min,
          children: [
            const Text('Library'),
            if (!lib.isScanning && lib.videos.isNotEmpty)
              Text(
                '${lib.videos.length} video${lib.videos.length == 1 ? '' : 's'}',
                style: TextStyle(
                  fontSize: 11,
                  fontWeight: FontWeight.w400,
                  color: isDark ? Colors.white38 : Colors.black38,
                ),
              ),
          ],
        ),
        actions: [
          _AppBarIconButton(
            icon: Icons.search_rounded,
            onPressed: () {
              if (_searchController.text.isNotEmpty) {
                _searchController.clear();
                context.read<LibraryProvider>().search('');
              }
            },
          ),
          _AppBarIconButton(
            icon: _isGrid ? Icons.view_list_rounded : Icons.grid_view_rounded,
            onPressed: () => setState(() => _isGrid = !_isGrid),
          ),
          _AppBarIconButton(
            icon: Icons.sort_rounded,
            onPressed: _showSortDialog,
          ),
          PopupMenuButton<String>(
            icon: const Icon(Icons.more_vert_rounded),
            shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(14)),
            offset: const Offset(0, 48),
            itemBuilder: (_) => [
              const PopupMenuItem(
                value: 'pick',
                child: Row(children: [
                  Icon(Icons.folder_open_outlined, size: 18),
                  SizedBox(width: 10),
                  Text('Open file...'),
                ]),
              ),
              const PopupMenuItem(
                value: 'refresh',
                child: Row(children: [
                  Icon(Icons.refresh_rounded, size: 18),
                  SizedBox(width: 10),
                  Text('Refresh library'),
                ]),
              ),
            ],
            onSelected: (v) {
              if (v == 'pick') _pickVideoFile();
              if (v == 'refresh') context.read<LibraryProvider>().refresh();
            },
          ),
          const SizedBox(width: 4),
        ],
      ),
      body: Column(
        children: [
          TabBar(
            controller: _tabController,
            padding: const EdgeInsets.symmetric(horizontal: 16),
            tabs: const [
              Tab(
                child: Row(mainAxisSize: MainAxisSize.min, children: [
                  Icon(Icons.play_circle_outline_rounded, size: 16),
                  SizedBox(width: 6),
                  Text('Videos'),
                ]),
              ),
              Tab(
                child: Row(mainAxisSize: MainAxisSize.min, children: [
                  Icon(Icons.folder_outlined, size: 16),
                  SizedBox(width: 6),
                  Text('Folders'),
                ]),
              ),
            ],
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(16, 10, 16, 8),
            child: TextField(
              controller: _searchController,
              onChanged: context.read<LibraryProvider>().search,
              decoration: InputDecoration(
                hintText: 'Search videos',
                prefixIcon: const Icon(Icons.search_rounded),
                suffixIcon: _searchController.text.isEmpty
                    ? null
                    : IconButton(
                        icon: const Icon(Icons.close_rounded),
                        onPressed: () {
                          setState(_searchController.clear);
                          context.read<LibraryProvider>().search('');
                        },
                      ),
                isDense: true,
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(14),
                ),
              ),
            ),
          ),
          Expanded(
            child: TabBarView(
              controller: _tabController,
              children: [
                _VideosTab(isGrid: _isGrid, onVideoTap: _openVideo),
                _FoldersTab(onVideoTap: _openVideo),
              ],
            ),
          ),
        ],
      ),
      floatingActionButton: FloatingActionButton.extended(
        onPressed: _pickVideoFile,
        icon: const Icon(Icons.add_rounded),
        label: const Text(
          'Open Video',
          style: TextStyle(fontWeight: FontWeight.w600),
        ),
      ),
    );
  }
}

// Small helper wrapper so repeated AppBar icon buttons share consistent padding
class _AppBarIconButton extends StatelessWidget {
  final IconData icon;
  final VoidCallback onPressed;
  const _AppBarIconButton({required this.icon, required this.onPressed});

  @override
  Widget build(BuildContext context) {
    return IconButton(
      icon: Icon(icon),
      onPressed: onPressed,
      style: IconButton.styleFrom(
        tapTargetSize: MaterialTapTargetSize.shrinkWrap,
      ),
    );
  }
}

// ─── Videos Tab ───────────────────────────────────────────────────────────────

class _VideosTab extends StatelessWidget {
  final bool isGrid;
  final void Function(VideoModel, List<VideoModel>) onVideoTap;

  const _VideosTab({required this.isGrid, required this.onVideoTap});

  @override
  Widget build(BuildContext context) {
    final lib = context.watch<LibraryProvider>();

    if (lib.isScanning) {
      return Center(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            const SizedBox(
              width: 48,
              height: 48,
              child: CircularProgressIndicator(strokeWidth: 3),
            ),
            const SizedBox(height: 20),
            Text(
              'Scanning for videos\u2026',
              style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                    color: Theme.of(context)
                        .colorScheme
                        .onSurface
                        .withValues(alpha: 0.5),
                  ),
            ),
          ],
        ),
      );
    }

    if (lib.error != null && lib.videos.isEmpty) {
      return EmptyState(
        icon: Icons.error_outline_rounded,
        title: 'Permission Required',
        subtitle: lib.error,
        action: FilledButton.icon(
          onPressed: lib.requestPermissionAndScan,
          icon: const Icon(Icons.lock_open_rounded),
          label: const Text('Grant Permission'),
        ),
      );
    }

    if (lib.videos.isEmpty) {
      return EmptyState(
        icon: Icons.video_library_outlined,
        title: 'No videos yet',
        subtitle: 'Tap \u201cOpen Video\u201d below to browse your files',
        action: FilledButton.icon(
          onPressed: () async {
            final result = await FilePicker.platform.pickFiles(
              type: FileType.custom,
              allowedExtensions: AppConstants.supportedVideoExtensions,
            );
            if (result != null && result.files.isNotEmpty) {
              final path = result.files.first.path;
              if (path != null && context.mounted) {
                final video = VideoModel.fromFile(File(path));
                context.read<LibraryProvider>().addVideo(video);
              }
            }
          },
          icon: const Icon(Icons.folder_open_rounded),
          label: const Text('Browse Files'),
        ),
      );
    }

    if (isGrid) {
      return RefreshIndicator(
        onRefresh: lib.refresh,
        child: GridView.builder(
          padding: const EdgeInsets.fromLTRB(14, 14, 14, 100),
          gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
            crossAxisCount: 2,
            childAspectRatio: 0.72,
            mainAxisSpacing: 14,
            crossAxisSpacing: 14,
          ),
          itemCount: lib.videos.length,
          itemBuilder: (_, i) {
            final video = lib.videos[i];
            return VideoCard(
              video: video,
              onTap: () => onVideoTap(video, lib.videos),
              onLongPress: () => _showVideoOptions(context, video),
            );
          },
        ),
      );
    }

    return RefreshIndicator(
      onRefresh: lib.refresh,
      child: ListView.separated(
        padding: const EdgeInsets.fromLTRB(14, 14, 14, 100),
        itemCount: lib.videos.length,
        separatorBuilder: (_, p2) => const SizedBox(height: 8),
        itemBuilder: (_, i) {
          final video = lib.videos[i];
          return _VideoListTile(
            video: video,
            onTap: () => onVideoTap(video, lib.videos),
            onLongPress: () => _showVideoOptions(context, video),
          );
        },
      ),
    );
  }

  void _showVideoOptions(BuildContext context, VideoModel video) {
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      builder: (_) => _VideoOptionsSheet(
        video: video,
        onShare: () {
          Navigator.pop(context);
          Share.shareXFiles([XFile(video.path)], text: video.displayName);
        },
        onRename: () {
          Navigator.pop(context);
          _showRenameDialog(context, video);
        },
        onDelete: () {
          context.read<LibraryProvider>().removeVideo(video.path);
          Navigator.pop(context);
          try { File(video.path).deleteSync(); } catch (_) {}
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(content: Text('Deleted ${video.displayName}')),
          );
        },
      ),
    );
  }

  void _showRenameDialog(BuildContext context, VideoModel video) {
    final controller = TextEditingController(text: video.displayName);
    showDialog(
      context: context,
      builder: (ctx) => AlertDialog(
        title: const Text('Rename Video'),
        content: TextField(
          controller: controller,
          decoration: const InputDecoration(hintText: 'Enter new name'),
          autofocus: true,
          onSubmitted: (_) => _doRename(ctx, context, controller, video),
        ),
        actions: [
          TextButton(
              onPressed: () => Navigator.pop(ctx),
              child: const Text('Cancel')),
          TextButton(
            onPressed: () =>
                _doRename(ctx, context, controller, video),
            child: const Text('Rename'),
          ),
        ],
      ),
    );
  }

  void _doRename(BuildContext ctx, BuildContext parentCtx,
      TextEditingController ctrl, VideoModel video) async {
    final newName = ctrl.text.trim();
    if (newName.isEmpty || newName == video.displayName) {
      Navigator.pop(ctx);
      return;
    }
    final dir = video.path
        .substring(0, video.path.lastIndexOf(Platform.pathSeparator));
    final newPath =
        '$dir${Platform.pathSeparator}$newName.${video.extension}';
    try {
      await File(video.path).rename(newPath);
      if (ctx.mounted) Navigator.pop(ctx);
      if (parentCtx.mounted) {
        parentCtx.read<LibraryProvider>().refresh();
        ScaffoldMessenger.of(parentCtx).showSnackBar(
          SnackBar(content: Text('Renamed to $newName')),
        );
      }
    } catch (e) {
      if (ctx.mounted) Navigator.pop(ctx);
      if (parentCtx.mounted) {
        ScaffoldMessenger.of(parentCtx).showSnackBar(
          SnackBar(content: Text('Failed to rename: $e')),
        );
      }
    }
  }
}

class _VideoListTile extends StatelessWidget {
  final VideoModel video;
  final VoidCallback onTap;
  final VoidCallback? onLongPress;

  const _VideoListTile({required this.video, required this.onTap, this.onLongPress});

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final isDark = theme.brightness == Brightness.dark;

    return Material(
      color: isDark ? const Color(0xFF1A1A28) : Colors.white,
      borderRadius: BorderRadius.circular(14),
      clipBehavior: Clip.antiAlias,
      child: InkWell(
        onTap: onTap,
        onLongPress: onLongPress,
        child: Padding(
          padding: const EdgeInsets.all(10),
          child: Row(
            children: [
              // Thumbnail
              ClipRRect(
                borderRadius: BorderRadius.circular(10),
                child: SizedBox(
                  width: 90,
                  height: 62,
                  child: FutureBuilder<String?>(
                    future: ThumbnailService.instance.getThumbnail(video.path),
                    builder: (context, snap) {
                      final thumbPath = snap.data;
                      if (thumbPath != null && File(thumbPath).existsSync()) {
                        return Stack(
                          fit: StackFit.expand,
                          children: [
                            Image.file(File(thumbPath),
                                fit: BoxFit.cover,
                                errorBuilder: (_, p2, p3) =>
                                    _listPlaceholder(isDark)),
                            if (video.duration != null)
                              Positioned(
                                bottom: 4,
                                right: 4,
                                child: Container(
                                  padding: const EdgeInsets.symmetric(
                                      horizontal: 5, vertical: 2),
                                  decoration: BoxDecoration(
                                    color: Colors.black87,
                                    borderRadius: BorderRadius.circular(4),
                                  ),
                                  child: Text(
                                    DurationUtils.format(video.duration!),
                                    style: const TextStyle(
                                        color: Colors.white, fontSize: 9),
                                  ),
                                ),
                              ),
                          ],
                        );
                      }
                      return _listPlaceholder(isDark);
                    },
                  ),
                ),
              ),
              const SizedBox(width: 12),
              // Info
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      video.displayName,
                      maxLines: 2,
                      overflow: TextOverflow.ellipsis,
                      style: theme.textTheme.bodyMedium?.copyWith(
                          fontWeight: FontWeight.w600),
                    ),
                    const SizedBox(height: 4),
                    Row(
                      children: [
                        _Badge(
                          text: video.extension.toUpperCase(),
                          color: const Color(0xFF6C63FF),
                        ),
                        const SizedBox(width: 6),
                        Text(
                          video.sizeFormatted,
                          style: theme.textTheme.bodySmall?.copyWith(
                              color: theme.colorScheme.onSurface
                                  .withValues(alpha: 0.45)),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
              const SizedBox(width: 4),
              Icon(Icons.more_vert_rounded,
                  size: 20,
                  color: theme.colorScheme.onSurface.withValues(alpha: 0.3)),
            ],
          ),
        ),
      ),
    );
  }

  Widget _listPlaceholder(bool isDark) {
    return Container(
      color: isDark ? const Color(0xFF0D0D14) : const Color(0xFFEEEEF6),
      child: Center(
        child: Icon(Icons.play_circle_fill_rounded,
            color: isDark ? Colors.white12 : Colors.black12, size: 28),
      ),
    );
  }
}

class _VideoOptionsSheet extends StatelessWidget {
  final VideoModel video;
  final VoidCallback onDelete;
  final VoidCallback? onShare;
  final VoidCallback? onRename;

  const _VideoOptionsSheet({
    required this.video,
    required this.onDelete,
    this.onShare,
    this.onRename,
  });

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    return SafeArea(
      child: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          // Handle
          Center(
            child: Container(
              margin: const EdgeInsets.only(top: 12, bottom: 16),
              width: 40,
              height: 4,
              decoration: BoxDecoration(
                color: theme.colorScheme.onSurface.withValues(alpha: 0.2),
                borderRadius: BorderRadius.circular(2),
              ),
            ),
          ),
          // File title row
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 20),
            child: Row(
              children: [
                Container(
                  width: 44,
                  height: 44,
                  decoration: BoxDecoration(
                    color: const Color(0x336C63FF),
                    borderRadius: BorderRadius.circular(10),
                  ),
                  child: const Icon(Icons.play_circle_outline_rounded,
                      color: Color(0xFF6C63FF), size: 24),
                ),
                const SizedBox(width: 12),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(video.displayName,
                          style: const TextStyle(
                              fontWeight: FontWeight.w700, fontSize: 14),
                          maxLines: 2,
                          overflow: TextOverflow.ellipsis),
                      const SizedBox(height: 2),
                      Text(
                        '${video.extension.toUpperCase()}  •  ${video.sizeFormatted}',
                        style: theme.textTheme.bodySmall?.copyWith(
                            color: theme.colorScheme.onSurface
                                .withValues(alpha: 0.45)),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          const SizedBox(height: 12),
          const Divider(height: 1),
          const SizedBox(height: 4),
          _SheetTile(Icons.info_outline_rounded, 'Details', onTap: () {
            Navigator.pop(context);
            showDialog(
              context: context,
              builder: (dialogCtx) => AlertDialog(
                title: Text(video.displayName,
                    style: const TextStyle(fontSize: 16)),
                content: Column(
                  mainAxisSize: MainAxisSize.min,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    _detail(theme, 'Path', video.path),
                    _detail(theme, 'Size', video.sizeFormatted),
                    _detail(theme, 'Format', video.extension.toUpperCase()),
                    if (video.duration != null)
                      _detail(theme, 'Duration',
                          '${video.duration!.inMinutes}m ${video.duration!.inSeconds.remainder(60)}s'),
                  ],
                ),
                actions: [
                  TextButton(
                      onPressed: () => Navigator.pop(dialogCtx),
                      child: const Text('Close'))
                ],
              ),
            );
          }),
          if (onShare != null)
            _SheetTile(Icons.share_outlined, 'Share', onTap: onShare!),
          if (onRename != null)
            _SheetTile(Icons.drive_file_rename_outline_rounded, 'Rename',
                onTap: onRename!),
          _SheetTile(Icons.delete_outline_rounded, 'Delete',
              color: theme.colorScheme.error, onTap: onDelete),
          const SizedBox(height: 8),
        ],
      ),
    );
  }

  Widget _detail(ThemeData theme, String label, String value) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(label,
              style: theme.textTheme.labelSmall?.copyWith(
                  color: theme.colorScheme.onSurface.withValues(alpha: 0.4))),
          const SizedBox(height: 2),
          Text(value, style: theme.textTheme.bodyMedium),
        ],
      ),
    );
  }
}

class _SheetTile extends StatelessWidget {
  final IconData icon;
  final String label;
  final Color? color;
  final VoidCallback onTap;
  const _SheetTile(this.icon, this.label,
      {this.color, required this.onTap});

  @override
  Widget build(BuildContext context) {
    final c = color ?? Theme.of(context).colorScheme.onSurface;
    return ListTile(
      leading: Icon(icon, color: c, size: 22),
      title: Text(label, style: TextStyle(color: c, fontSize: 15)),
      onTap: onTap,
      contentPadding: const EdgeInsets.symmetric(horizontal: 20, vertical: 0),
      dense: true,
    );
  }
}

// Small format badge
class _Badge extends StatelessWidget {
  final String text;
  final Color color;
  const _Badge({required this.text, required this.color});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 6, vertical: 2),
      decoration: BoxDecoration(
        color: color.withValues(alpha: 0.15),
        borderRadius: BorderRadius.circular(4),
      ),
      child: Text(text,
          style: TextStyle(
              color: color, fontSize: 9, fontWeight: FontWeight.w700)),
    );
  }
}

// ─── Folders Tab ──────────────────────────────────────────────────────────────

class _FoldersTab extends StatelessWidget {
  final void Function(VideoModel, List<VideoModel>) onVideoTap;
  const _FoldersTab({required this.onVideoTap});

  @override
  Widget build(BuildContext context) {
    final lib = context.watch<LibraryProvider>();
    final folders = lib.folders;

    if (lib.isScanning) {
      return const Center(child: CircularProgressIndicator());
    }

    if (folders.isEmpty) {
      return const EmptyState(
        icon: Icons.folder_off_outlined,
        title: 'No folders found',
        subtitle: 'Scan your device to discover videos',
      );
    }

    final keys = folders.keys.toList()..sort();
    return GridView.builder(
      padding: const EdgeInsets.fromLTRB(14, 14, 14, 100),
      gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
        crossAxisCount: 2,
        mainAxisSpacing: 12,
        crossAxisSpacing: 12,
        childAspectRatio: 1.25,
      ),
      itemCount: keys.length,
      itemBuilder: (_, i) {
        final folder = keys[i];
        final videos = folders[folder]!;
        return FolderCard(
          folderPath: folder,
          videoCount: videos.length,
          onTap: () => Navigator.push(
            context,
            MaterialPageRoute(
              builder: (_) => FolderScreen(
                folderPath: folder,
                videos: videos,
                onVideoTap: onVideoTap,
              ),
            ),
          ),
        );
      },
    );
  }
}

// ─── Sort Bottom Sheet ────────────────────────────────────────────────────────

class _SortBottomSheet extends StatefulWidget {
  final SortBy currentBy;
  final SortOrder currentOrder;
  final void Function(SortBy, SortOrder) onApply;

  const _SortBottomSheet({
    required this.currentBy,
    required this.currentOrder,
    required this.onApply,
  });

  @override
  State<_SortBottomSheet> createState() => _SortBottomSheetState();
}

class _SortBottomSheetState extends State<_SortBottomSheet> {
  late SortBy _by;
  late SortOrder _order;

  @override
  void initState() {
    super.initState();
    _by = widget.currentBy;
    _order = widget.currentOrder;
  }

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    return Padding(
      padding: const EdgeInsets.fromLTRB(20, 16, 20, 24),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          // Handle
          Center(
            child: Container(
              width: 40,
              height: 4,
              decoration: BoxDecoration(
                color: theme.colorScheme.onSurface.withValues(alpha: 0.2),
                borderRadius: BorderRadius.circular(2),
              ),
            ),
          ),
          const SizedBox(height: 20),
          Text('Sort By',
              style: theme.textTheme.titleMedium
                  ?.copyWith(fontWeight: FontWeight.w700)),
          const SizedBox(height: 12),
          Wrap(
            spacing: 8,
            runSpacing: 8,
            children: SortBy.values.map((by) {
              final sel = _by == by;
              return ChoiceChip(
                label: Text(by.name[0].toUpperCase() + by.name.substring(1)),
                selected: sel,
                selectedColor: const Color(0x336C63FF),
                labelStyle: TextStyle(
                  color: sel ? const Color(0xFF6C63FF) : null,
                  fontWeight: sel ? FontWeight.w700 : FontWeight.w400,
                ),
                onSelected: (_) => setState(() => _by = by),
              );
            }).toList(),
          ),
          const SizedBox(height: 20),
          Text('Order',
              style: theme.textTheme.titleMedium
                  ?.copyWith(fontWeight: FontWeight.w700)),
          const SizedBox(height: 8),
          Row(
            children: SortOrder.values.map((order) {
              final sel = _order == order;
              return Expanded(
                child: GestureDetector(
                  onTap: () => setState(() => _order = order),
                  child: AnimatedContainer(
                    duration: const Duration(milliseconds: 200),
                    margin: const EdgeInsets.only(right: 8),
                    padding: const EdgeInsets.symmetric(vertical: 12),
                    decoration: BoxDecoration(
                      color: sel
                          ? const Color(0x336C63FF)
                          : theme.colorScheme.onSurface.withValues(alpha: 0.06),
                      borderRadius: BorderRadius.circular(12),
                      border: sel
                          ? Border.all(color: const Color(0xFF6C63FF), width: 1.5)
                          : null,
                    ),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(
                          order == SortOrder.ascending
                              ? Icons.arrow_upward_rounded
                              : Icons.arrow_downward_rounded,
                          size: 16,
                          color: sel ? const Color(0xFF6C63FF) : null,
                        ),
                        const SizedBox(width: 6),
                        Text(
                          order == SortOrder.ascending
                              ? 'Ascending'
                              : 'Descending',
                          style: TextStyle(
                            color: sel ? const Color(0xFF6C63FF) : null,
                            fontWeight:
                                sel ? FontWeight.w700 : FontWeight.w400,
                            fontSize: 13,
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              );
            }).toList(),
          ),
          const SizedBox(height: 20),
          SizedBox(
            width: double.infinity,
            child: FilledButton(
              onPressed: () {
                widget.onApply(_by, _order);
                Navigator.pop(context);
              },
              style: FilledButton.styleFrom(
                padding: const EdgeInsets.symmetric(vertical: 14),
                shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(12)),
              ),
              child: const Text('Apply',
                  style: TextStyle(fontWeight: FontWeight.w700, fontSize: 15)),
            ),
          ),
        ],
      ),
    );
  }
}

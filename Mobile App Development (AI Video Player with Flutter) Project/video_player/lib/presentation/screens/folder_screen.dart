import 'package:flutter/material.dart';
import '../../data/models/video_model.dart';
import '../widgets/library/video_card.dart';

class FolderScreen extends StatelessWidget {
  final String folderPath;
  final List<VideoModel> videos;
  final void Function(VideoModel, List<VideoModel>) onVideoTap;

  const FolderScreen({
    super.key,
    required this.folderPath,
    required this.videos,
    required this.onVideoTap,
  });

  String get _folderName {
    final parts = folderPath.replaceAll('\\', '/').split('/');
    return parts.isNotEmpty ? parts.last : folderPath;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back_rounded),
          onPressed: () => Navigator.pop(context),
        ),
        title: Text(_folderName),
      ),
      body: Padding(
        padding: const EdgeInsets.all(12),
        child: GridView.builder(
          gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
            crossAxisCount: 2,
            childAspectRatio: 0.75,
            mainAxisSpacing: 12,
            crossAxisSpacing: 12,
          ),
          itemCount: videos.length,
          itemBuilder: (_, i) => VideoCard(
            video: videos[i],
            onTap: () => onVideoTap(videos[i], videos),
          ),
        ),
      ),
    );
  }
}

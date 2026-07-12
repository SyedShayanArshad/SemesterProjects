import 'package:flutter/material.dart';
import 'package:flutter_colorpicker/flutter_colorpicker.dart';
import 'package:provider/provider.dart';
import '../providers/auth_provider.dart';
import '../providers/settings_provider.dart';
import '../widgets/google_sign_in_button.dart';
import '../../data/models/player_settings.dart';
import '../../core/constants/app_constants.dart';

class SettingsScreen extends StatelessWidget {
  const SettingsScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final sp = context.watch<SettingsProvider>();
    final auth = context.watch<AuthProvider>();
    final s = sp.settings;

    return Scaffold(
      appBar: AppBar(title: const Text('Settings')),
      body: ListView(
        children: [
          if (auth.user != null)
            Padding(
              padding: const EdgeInsets.fromLTRB(16, 16, 16, 8),
              child: Card(
                child: ListTile(
                  leading: const CircleAvatar(child: Icon(Icons.person_outline)),
                  title: Text(
                    auth.user?.displayName ?? 'Signed in',
                    maxLines: 1,
                    overflow: TextOverflow.ellipsis,
                  ),
                  subtitle: Text(auth.user?.email ?? ''),
                  trailing: TextButton(
                    onPressed: () async {
                      await auth.signOut();
                    },
                    child: const Text('Sign out'),
                  ),
                ),
              ),
            ),
          if (auth.user == null)
            Padding(
              padding: const EdgeInsets.fromLTRB(16, 16, 16, 8),
              child: Card(
                child: Padding(
                  padding: const EdgeInsets.all(16),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.stretch,
                    children: [
                      const ListTile(
                        contentPadding: EdgeInsets.zero,
                        leading: Icon(Icons.cloud_outlined),
                        title: Text('Cloud sync is off'),
                        subtitle: Text('Sign in to sync history and settings with Firebase.'),
                      ),
                      const SizedBox(height: 8),
                      const GoogleSignInButton(),
                    ],
                  ),
                ),
              ),
            ),
          // Base tree section (explicitly mirrors provided widget tree)
          ListTile(
            leading: const Icon(Icons.palette_outlined),
            title: const Text('Theme'),
            subtitle: Text(s.darkMode ? 'Dark' : 'Light'),
            onTap: () => sp.toggle(darkMode: !s.darkMode),
          ),
          SwitchListTile(
            title: const Text('Auto play next'),
            value: s.autoPlayNext,
            onChanged: (v) => sp.toggle(autoPlayNext: v),
          ),
          ListTile(
            leading: const Icon(Icons.speed_outlined),
            title: const Text('Default speed'),
            trailing: Text('${s.playbackSpeed}x'),
            onTap: () => _showSpeedPicker(context, sp, s.playbackSpeed),
          ),
          ListTile(
            leading: const Icon(Icons.storage_outlined),
            title: const Text('Storage'),
            subtitle: const Text('Manage cache and media storage'),
            onTap: () {},
          ),
          ListTile(
            leading: const Icon(Icons.info_outline),
            title: const Text('About'),
            subtitle: const Text('Version, licenses, and app information'),
            onTap: () {},
          ),
          ListTile(
            leading: const Icon(Icons.help_outline_rounded),
            title: const Text('Help'),
            subtitle: const Text('Support and troubleshooting'),
            onTap: () {},
          ),

          // Progressive enhancement section
          const SizedBox(height: 12),
          _SectionHeader('More Settings'),
          SwitchListTile(
            title: const Text('Hardware Decoding'),
            subtitle: const Text('Use GPU for video decoding'),
            secondary: const Icon(Icons.memory_outlined),
            value: s.hardwareDecoding,
            onChanged: (v) => sp.toggle(hardwareDecoding: v),
          ),
          SwitchListTile(
            title: const Text('Resume Playback'),
            subtitle: const Text('Resume from where you left off'),
            secondary: const Icon(Icons.restore_outlined),
            value: s.resumePlayback,
            onChanged: (v) => sp.toggle(resumePlayback: v),
          ),
          SwitchListTile(
            title: const Text('Loop Video'),
            secondary: const Icon(Icons.loop_outlined),
            value: s.loopVideo,
            onChanged: (v) => sp.toggle(loopVideo: v),
          ),
          SwitchListTile(
            title: const Text('Shuffle Playlist'),
            secondary: const Icon(Icons.shuffle_outlined),
            value: s.shufflePlaylist,
            onChanged: (v) => sp.toggle(shufflePlaylist: v),
          ),
          SwitchListTile(
            title: const Text('Keep Screen On'),
            subtitle: const Text('Prevent screen from sleeping'),
            secondary: const Icon(Icons.screen_lock_rotation_outlined),
            value: s.keepScreenOn,
            onChanged: (v) => sp.toggle(keepScreenOn: v),
          ),
          SwitchListTile(
            title: const Text('Enable Gestures'),
            secondary: const Icon(Icons.touch_app_outlined),
            value: s.gesturesEnabled,
            onChanged: (v) => sp.toggle(gesturesEnabled: v),
          ),
          if (s.gesturesEnabled) ...[
            SwitchListTile(
              title: const Text('Brightness Gesture'),
              subtitle: const Text('Swipe up/down on left side'),
              secondary: const Icon(Icons.brightness_6_outlined),
              value: s.brightnessGesture,
              onChanged: (v) => sp.toggle(brightnessGesture: v),
            ),
            SwitchListTile(
              title: const Text('Volume Gesture'),
              subtitle: const Text('Swipe up/down on right side'),
              secondary: const Icon(Icons.volume_up_outlined),
              value: s.volumeGesture,
              onChanged: (v) => sp.toggle(volumeGesture: v),
            ),
            SwitchListTile(
              title: const Text('Seek Gesture'),
              subtitle: const Text('Swipe left/right to seek'),
              secondary: const Icon(Icons.swipe_outlined),
              value: s.seekGesture,
              onChanged: (v) => sp.toggle(seekGesture: v),
            ),
          ],
          SwitchListTile(
            title: const Text('Auto-Hide Controls'),
            secondary: const Icon(Icons.timer_outlined),
            value: s.autoHideControls,
            onChanged: (v) => sp.toggle(autoHideControls: v),
          ),
          if (s.autoHideControls)
            ListTile(
              leading: const Icon(Icons.timer_3_outlined),
              title: const Text('Auto-Hide Delay'),
              trailing: Text('${s.autoHideDelay}s'),
              onTap: () => _showDelayPicker(context, sp, s.autoHideDelay),
            ),
          SwitchListTile(
            title: const Text('Show Subtitles'),
            secondary: const Icon(Icons.subtitles_outlined),
            value: s.subtitle.enabled,
            onChanged: (v) =>
                sp.updateSubtitle(s.subtitle.copyWith(enabled: v)),
          ),
          if (s.subtitle.enabled) ...[
            ListTile(
              leading: const Icon(Icons.format_size_outlined),
              title: const Text('Font Size'),
              trailing: Text('${s.subtitle.fontSize.toInt()}'),
              onTap: () => _showFontSizePicker(context, sp, s),
            ),
            ListTile(
              leading: const Icon(Icons.color_lens_outlined),
              title: const Text('Text Color'),
              trailing: _ColorDot(color: s.subtitle.textColor),
              onTap: () => _showColorPicker(context, sp, s, isText: true),
            ),
            ListTile(
              leading: const Icon(Icons.color_lens_outlined),
              title: const Text('Background Color'),
              trailing: _ColorDot(color: s.subtitle.backgroundColor),
              onTap: () => _showColorPicker(context, sp, s, isText: false),
            ),
            ListTile(
              leading: const Icon(Icons.vertical_align_bottom_outlined),
              title: const Text('Position'),
              trailing: DropdownButton<SubtitlePosition>(
                value: s.subtitle.position,
                underline: const SizedBox(),
                onChanged: (v) =>
                    sp.updateSubtitle(s.subtitle.copyWith(position: v)),
                items: SubtitlePosition.values
                    .map((p) => DropdownMenuItem(
                          value: p,
                          child: Text(
                            p.name[0].toUpperCase() + p.name.substring(1),
                          ),
                        ))
                    .toList(),
              ),
            ),
            ListTile(
              leading: const Icon(Icons.av_timer_outlined),
              title: const Text('Subtitle Delay'),
              subtitle: Text('${s.subtitle.delayMs}ms'),
              trailing: Row(
                mainAxisSize: MainAxisSize.min,
                children: [
                  IconButton(
                    icon: const Icon(Icons.remove),
                    onPressed: () => sp.updateSubtitle(
                      s.subtitle.copyWith(delayMs: s.subtitle.delayMs - 100),
                    ),
                  ),
                  Text('${s.subtitle.delayMs}ms'),
                  IconButton(
                    icon: const Icon(Icons.add),
                    onPressed: () => sp.updateSubtitle(
                      s.subtitle.copyWith(delayMs: s.subtitle.delayMs + 100),
                    ),
                  ),
                ],
              ),
            ),
          ],
          SwitchListTile(
            title: const Text('Show Hidden Folders'),
            secondary: const Icon(Icons.folder_off_outlined),
            value: s.showHiddenFolders,
            onChanged: (v) => sp.toggle(showHiddenFolders: v),
          ),
          ListTile(
            leading: const Icon(Icons.video_settings_outlined),
            title: const Text('Supported Formats'),
            subtitle: Text(
              AppConstants.supportedVideoExtensions
                  .map((e) => e.toUpperCase())
                  .join(', '),
            ),
          ),
          const SizedBox(height: 20),
        ],
      ),
    );
  }

  void _showSpeedPicker(BuildContext context, SettingsProvider sp, double current) {
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      builder: (_) => SafeArea(
        child: SingleChildScrollView(
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              const Padding(
                padding: EdgeInsets.all(16),
                child: Text('Default Speed',
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16)),
              ),
              RadioGroup<double>(
                groupValue: current,
                onChanged: (v) {
                  if (v != null) sp.setSpeed(v);
                  Navigator.pop(context);
                },
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    ...AppConstants.speedOptions.map(
                      (s) => RadioListTile<double>(
                        title: Text('${s}x'),
                        value: s,
                      ),
                    ),
                    const SizedBox(height: 8),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  void _showDelayPicker(BuildContext context, SettingsProvider sp, int current) {
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      builder: (_) => SafeArea(
        child: SingleChildScrollView(
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              const Padding(
                padding: EdgeInsets.all(16),
                child: Text('Auto-Hide Delay',
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16)),
              ),
              RadioGroup<int>(
                groupValue: current,
                onChanged: (v) {
                  if (v != null) {
                    sp.update(sp.settings.copyWith(autoHideDelay: v));
                  }
                  Navigator.pop(context);
                },
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    ...[1, 2, 3, 5, 8].map(
                      (s) => RadioListTile<int>(
                        title: Text('${s}s'),
                        value: s,
                      ),
                    ),
                    const SizedBox(height: 8),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  void _showFontSizePicker(BuildContext context, SettingsProvider sp, PlayerSettings s) {
    double size = s.subtitle.fontSize;
    showDialog(
      context: context,
      builder: (_) => StatefulBuilder(
        builder: (ctx, setS) => AlertDialog(
          title: const Text('Font Size'),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Text('${size.toInt()}', style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold)),
              Slider(
                min: 10,
                max: 40,
                value: size,
                divisions: 30,
                label: '${size.toInt()}',
                onChanged: (v) => setS(() => size = v),
              ),
            ],
          ),
          actions: [
            TextButton(onPressed: () => Navigator.pop(context), child: const Text('Cancel')),
            TextButton(
              onPressed: () {
                sp.updateSubtitle(s.subtitle.copyWith(fontSize: size));
                Navigator.pop(context);
              },
              child: const Text('Apply'),
            ),
          ],
        ),
      ),
    );
  }

  void _showColorPicker(BuildContext context, SettingsProvider sp, PlayerSettings s,
      {required bool isText}) {
    Color picked = isText ? s.subtitle.textColor : s.subtitle.backgroundColor;
    showDialog(
      context: context,
      builder: (_) => AlertDialog(
        title: Text(isText ? 'Text Color' : 'Background Color'),
        content: SingleChildScrollView(
          child: ColorPicker(
            pickerColor: picked,
            onColorChanged: (c) => picked = c,
          ),
        ),
        actions: [
          TextButton(onPressed: () => Navigator.pop(context), child: const Text('Cancel')),
          TextButton(
            onPressed: () {
              sp.updateSubtitle(isText
                  ? s.subtitle.copyWith(textColor: picked)
                  : s.subtitle.copyWith(backgroundColor: picked));
              Navigator.pop(context);
            },
            child: const Text('Apply'),
          ),
        ],
      ),
    );
  }
}

class _SectionHeader extends StatelessWidget {
  final String title;
  const _SectionHeader(this.title);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(16, 20, 16, 4),
      child: Text(
        title,
        style: TextStyle(
          fontSize: 13,
          fontWeight: FontWeight.bold,
          color: Theme.of(context).colorScheme.primary,
          letterSpacing: 0.5,
        ),
      ),
    );
  }
}

class _ColorDot extends StatelessWidget {
  final Color color;
  const _ColorDot({required this.color});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 24,
      height: 24,
      decoration: BoxDecoration(
        color: color,
        shape: BoxShape.circle,
        border: Border.all(color: Colors.grey),
      ),
    );
  }
}

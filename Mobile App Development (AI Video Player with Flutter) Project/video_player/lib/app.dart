import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'core/theme/app_theme.dart';
import 'data/services/firebase_user_data_service.dart';
import 'data/services/history_service.dart';
import 'data/services/settings_service.dart';
import 'data/services/media_scanner_service.dart';
import 'presentation/providers/auth_provider.dart';
import 'presentation/providers/library_provider.dart';
import 'presentation/providers/settings_provider.dart';
import 'presentation/screens/auth_screen.dart';
import 'presentation/screens/home_screen.dart';

class App extends StatefulWidget {
  const App({super.key});

  @override
  State<App> createState() => _AppState();
}

class _AppState extends State<App> {
  final _historyService = HistoryService();
  final _settingsService = SettingsService();
  final _scannerService = MediaScannerService();
  final _firebaseUserDataService = FirebaseUserDataService();

  late final SettingsProvider _settingsProvider;
  late final LibraryProvider _libraryProvider;
  late final AuthProvider _authProvider;

  @override
  void initState() {
    super.initState();
    _settingsProvider = SettingsProvider(_settingsService)..load();
    _libraryProvider = LibraryProvider(_scannerService);
    _authProvider = AuthProvider(_firebaseUserDataService);
    _authProvider.addListener(_syncSettingsWithAuthState);
  }

  void _syncSettingsWithAuthState() {
    if (!mounted || !_authProvider.ready) {
      return;
    }
    _settingsProvider.load();
  }

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        Provider<HistoryService>.value(value: _historyService),
        Provider<SettingsService>.value(value: _settingsService),
        Provider<MediaScannerService>.value(value: _scannerService),
        ChangeNotifierProvider<AuthProvider>.value(value: _authProvider),
        ChangeNotifierProvider<SettingsProvider>.value(value: _settingsProvider),
        ChangeNotifierProvider<LibraryProvider>.value(value: _libraryProvider),
      ],
      child: Consumer2<SettingsProvider, AuthProvider>(
        builder: (_, settings, auth, _) {
          return MaterialApp(
            title: 'CineKit',
            debugShowCheckedModeBanner: false,
            theme: AppTheme.lightTheme,
            darkTheme: AppTheme.darkTheme,
            themeMode: settings.settings.darkMode ? ThemeMode.dark : ThemeMode.light,
            home: auth.ready
                ? (auth.user == null ? const AuthScreen() : const HomeScreen())
                : const _BootScreen(),
          );
        },
      ),
    );
  }

  @override
  void dispose() {
    _authProvider.removeListener(_syncSettingsWithAuthState);
    _authProvider.dispose();
    super.dispose();
  }
}

class _BootScreen extends StatelessWidget {
  const _BootScreen();

  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      body: Center(child: CircularProgressIndicator()),
    );
  }
}

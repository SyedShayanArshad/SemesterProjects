import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class AppTheme {
  AppTheme._();

  // ── Cinematic colour palette ────────────────────────────────────────────────
  static const Color accent      = Color(0xFF6C63FF); // electric violet
  static const Color accentLight = Color(0xFF9D96FF);
  static const Color accentGlow  = Color(0x336C63FF);

  // Dark palette
  static const Color _darkBg      = Color(0xFF0D0D14);
  static const Color _darkSurface = Color(0xFF14141E);
  static const Color _darkCard    = Color(0xFF1A1A28);
  static const Color _darkAppBar  = Color(0xFF10101A);

  // Light palette
  static const Color _lightBg      = Color(0xFFF0F0F8);
  static const Color _lightSurface = Color(0xFFFFFFFF);
  static const Color _lightCard    = Color(0xFFFFFFFF);
  static const Color _lightAppBar  = Color(0xFFFFFFFF);

  static const _shape = RoundedRectangleBorder(
    borderRadius: BorderRadius.all(Radius.circular(16)),
  );

  // ── Dark Theme ──────────────────────────────────────────────────────────────
  static ThemeData darkTheme = ThemeData(
    useMaterial3: true,
    brightness: Brightness.dark,
    colorScheme: ColorScheme.fromSeed(
      seedColor: accent,
      brightness: Brightness.dark,
      primary: accent,
      secondary: accentLight,
      surface: _darkSurface,
      error: const Color(0xFFFF5C5C),
    ),
    scaffoldBackgroundColor: _darkBg,
    appBarTheme: const AppBarTheme(
      backgroundColor: _darkAppBar,
      foregroundColor: Colors.white,
      elevation: 0,
      centerTitle: false,
      scrolledUnderElevation: 0,
      systemOverlayStyle: SystemUiOverlayStyle(
        statusBarBrightness: Brightness.dark,
        statusBarIconBrightness: Brightness.light,
      ),
      titleTextStyle: TextStyle(
        color: Colors.white,
        fontSize: 20,
        fontWeight: FontWeight.w700,
        letterSpacing: -0.3,
      ),
    ),
    cardTheme: CardThemeData(
      color: _darkCard,
      elevation: 0,
      shape: _shape,
      margin: EdgeInsets.zero,
    ),
    navigationBarTheme: NavigationBarThemeData(
      backgroundColor: _darkAppBar,
      indicatorColor: accentGlow,
      iconTheme: WidgetStateProperty.resolveWith((states) {
        if (states.contains(WidgetState.selected)) {
          return const IconThemeData(color: accent, size: 24);
        }
        return const IconThemeData(color: Colors.white38, size: 24);
      }),
      labelTextStyle: WidgetStateProperty.resolveWith((states) {
        if (states.contains(WidgetState.selected)) {
          return const TextStyle(
              color: accent, fontSize: 11, fontWeight: FontWeight.w600);
        }
        return const TextStyle(color: Colors.white38, fontSize: 11);
      }),
      elevation: 8,
      height: 62,
    ),
    sliderTheme: SliderThemeData(
      activeTrackColor: accent,
      thumbColor: accent,
      inactiveTrackColor: Colors.white12,
      overlayColor: accentGlow,
      trackHeight: 3,
      thumbShape: const RoundSliderThumbShape(enabledThumbRadius: 7),
    ),
    tabBarTheme: const TabBarThemeData(
      labelColor: accent,
      unselectedLabelColor: Colors.white38,
      indicatorColor: accent,
      dividerColor: Colors.transparent,
      labelStyle: TextStyle(fontSize: 13, fontWeight: FontWeight.w600),
      unselectedLabelStyle: TextStyle(fontSize: 13),
    ),
    listTileTheme: const ListTileThemeData(
      iconColor: Colors.white60,
      contentPadding: EdgeInsets.symmetric(horizontal: 20, vertical: 2),
    ),
    switchTheme: SwitchThemeData(
      thumbColor: WidgetStateProperty.resolveWith(
          (s) => s.contains(WidgetState.selected) ? accent : Colors.white38),
      trackColor: WidgetStateProperty.resolveWith(
          (s) => s.contains(WidgetState.selected) ? accentGlow : Colors.white12),
    ),
    iconTheme: const IconThemeData(color: Colors.white70),
    dividerTheme: const DividerThemeData(color: Colors.white10, thickness: 1),
    snackBarTheme: SnackBarThemeData(
      backgroundColor: _darkCard,
      contentTextStyle: const TextStyle(color: Colors.white),
      behavior: SnackBarBehavior.floating,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
    ),
    inputDecorationTheme: InputDecorationTheme(
      filled: true,
      fillColor: _darkCard,
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(12),
        borderSide: BorderSide.none,
      ),
      hintStyle: const TextStyle(color: Colors.white30),
      contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
    ),
    dialogTheme: DialogThemeData(
      backgroundColor: _darkCard,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
      titleTextStyle: const TextStyle(
          color: Colors.white, fontSize: 18, fontWeight: FontWeight.w700),
    ),
    bottomSheetTheme: const BottomSheetThemeData(
      backgroundColor: _darkCard,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.vertical(top: Radius.circular(24)),
      ),
    ),
    progressIndicatorTheme: const ProgressIndicatorThemeData(color: accent),
    floatingActionButtonTheme: const FloatingActionButtonThemeData(
      backgroundColor: accent,
      foregroundColor: Colors.white,
      shape: StadiumBorder(),
      elevation: 4,
    ),
    popupMenuTheme: PopupMenuThemeData(
      color: _darkCard,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
      textStyle: const TextStyle(color: Colors.white, fontSize: 14),
    ),
  );

  // ── Light Theme ─────────────────────────────────────────────────────────────
  static ThemeData lightTheme = ThemeData(
    useMaterial3: true,
    brightness: Brightness.light,
    colorScheme: ColorScheme.fromSeed(
      seedColor: accent,
      brightness: Brightness.light,
      primary: accent,
      secondary: accentLight,
      surface: _lightSurface,
      error: const Color(0xFFE53935),
    ),
    scaffoldBackgroundColor: _lightBg,
    appBarTheme: const AppBarTheme(
      backgroundColor: _lightAppBar,
      foregroundColor: Color(0xFF1A1A28),
      elevation: 0,
      centerTitle: false,
      scrolledUnderElevation: 0,
      systemOverlayStyle: SystemUiOverlayStyle(
        statusBarBrightness: Brightness.light,
        statusBarIconBrightness: Brightness.dark,
      ),
      titleTextStyle: TextStyle(
        color: Color(0xFF1A1A28),
        fontSize: 20,
        fontWeight: FontWeight.w700,
        letterSpacing: -0.3,
      ),
    ),
    cardTheme: CardThemeData(
      color: _lightCard,
      elevation: 0,
      shape: _shape,
      margin: EdgeInsets.zero,
      shadowColor: Colors.black12,
    ),
    navigationBarTheme: NavigationBarThemeData(
      backgroundColor: _lightAppBar,
      indicatorColor: const Color(0x196C63FF),
      iconTheme: WidgetStateProperty.resolveWith((states) {
        if (states.contains(WidgetState.selected)) {
          return const IconThemeData(color: accent, size: 24);
        }
        return const IconThemeData(color: Colors.black38, size: 24);
      }),
      labelTextStyle: WidgetStateProperty.resolveWith((states) {
        if (states.contains(WidgetState.selected)) {
          return const TextStyle(
              color: accent, fontSize: 11, fontWeight: FontWeight.w600);
        }
        return const TextStyle(color: Colors.black38, fontSize: 11);
      }),
      elevation: 8,
      height: 62,
    ),
    sliderTheme: SliderThemeData(
      activeTrackColor: accent,
      thumbColor: accent,
      inactiveTrackColor: Colors.black12,
      overlayColor: accentGlow,
      trackHeight: 3,
      thumbShape: const RoundSliderThumbShape(enabledThumbRadius: 7),
    ),
    tabBarTheme: const TabBarThemeData(
      labelColor: accent,
      unselectedLabelColor: Colors.black38,
      indicatorColor: accent,
      dividerColor: Colors.transparent,
      labelStyle: TextStyle(fontSize: 13, fontWeight: FontWeight.w600),
      unselectedLabelStyle: TextStyle(fontSize: 13),
    ),
    listTileTheme: const ListTileThemeData(
      iconColor: Color(0xFF6C63FF),
      contentPadding: EdgeInsets.symmetric(horizontal: 20, vertical: 2),
    ),
    switchTheme: SwitchThemeData(
      thumbColor: WidgetStateProperty.resolveWith(
          (s) => s.contains(WidgetState.selected) ? accent : Colors.white),
      trackColor: WidgetStateProperty.resolveWith(
          (s) => s.contains(WidgetState.selected) ? accentGlow : Colors.black12),
    ),
    dividerTheme: const DividerThemeData(color: Color(0x14000000), thickness: 1),
    snackBarTheme: SnackBarThemeData(
      backgroundColor: const Color(0xFF1A1A28),
      contentTextStyle: const TextStyle(color: Colors.white),
      behavior: SnackBarBehavior.floating,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
    ),
    inputDecorationTheme: InputDecorationTheme(
      filled: true,
      fillColor: const Color(0xFFEEEEF6),
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(12),
        borderSide: BorderSide.none,
      ),
      hintStyle: const TextStyle(color: Colors.black38),
      contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
    ),
    dialogTheme: DialogThemeData(
      backgroundColor: _lightSurface,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
      titleTextStyle: const TextStyle(
          color: Color(0xFF1A1A28), fontSize: 18, fontWeight: FontWeight.w700),
    ),
    bottomSheetTheme: const BottomSheetThemeData(
      backgroundColor: _lightSurface,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.vertical(top: Radius.circular(24)),
      ),
    ),
    progressIndicatorTheme: const ProgressIndicatorThemeData(color: accent),
    floatingActionButtonTheme: const FloatingActionButtonThemeData(
      backgroundColor: accent,
      foregroundColor: Colors.white,
      shape: StadiumBorder(),
      elevation: 4,
    ),
    popupMenuTheme: PopupMenuThemeData(
      color: _lightSurface,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
      textStyle: const TextStyle(color: Color(0xFF1A1A28), fontSize: 14),
    ),
  );
}

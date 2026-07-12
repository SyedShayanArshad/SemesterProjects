import 'package:flutter/foundation.dart'
    show TargetPlatform, defaultTargetPlatform, kIsWeb;

/// Centralized Google Mobile Ads test IDs.
///
/// Keep these while developing / for coursework so you don't accidentally
/// request real ads using production AdMob units.
class AdMobConstants {
  static String? bannerAdUnitId() {
    if (kIsWeb) return null;

    switch (defaultTargetPlatform) {
      case TargetPlatform.android:
        // Google sample banner unit.
        return 'ca-app-pub-3940256099942544/6300978111';
      case TargetPlatform.iOS:
        // Google sample banner unit.
        return 'ca-app-pub-3940256099942544/2934735716';
      default:
        return null;
    }
  }

  static String? interstitialAdUnitId() {
    if (kIsWeb) return null;

    switch (defaultTargetPlatform) {
      case TargetPlatform.android:
        // Google sample interstitial unit.
        return 'ca-app-pub-3940256099942544/1033173712';
      case TargetPlatform.iOS:
        // Google sample interstitial unit.
        return 'ca-app-pub-3940256099942544/4411468910';
      default:
        return null;
    }
  }
}

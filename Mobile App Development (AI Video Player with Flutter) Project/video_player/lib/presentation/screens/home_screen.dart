import 'package:flutter/material.dart';
import 'package:flutter/foundation.dart' show kDebugMode;
import 'package:google_mobile_ads/google_mobile_ads.dart';
import '../../core/utils/logger.dart';
import 'library_screen.dart';
import 'history_screen.dart';
import 'settings_screen.dart';
import '../../core/constants/admob_constants.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen>
    with SingleTickerProviderStateMixin {
  int _currentIndex = 0;
  late AnimationController _animController;
  late Animation<double> _fadeAnim;

  BannerAd? _bannerAd;
  bool _isBannerAdReady = false;
  InterstitialAd? _interstitialAd;
  bool _interstitialShownForHistory = false;
  bool _interstitialShownForSettings = false;

  final List<Widget> _pages = const [
    LibraryScreen(),
    HistoryScreen(),
    SettingsScreen(),
  ];

  @override
  void initState() {
    super.initState();
    _animController = AnimationController(
      vsync: this,
      duration: const Duration(milliseconds: 200),
    );
    _fadeAnim = CurvedAnimation(parent: _animController, curve: Curves.easeOut);
    _animController.forward();

    _loadBannerAd();
    _loadInterstitialAd();
  }

  void _loadBannerAd() {
    final adUnitId = AdMobConstants.bannerAdUnitId();
    if (adUnitId == null) {
      return;
    }

    final ad = BannerAd(
      adUnitId: adUnitId,
      request: const AdRequest(),
      size: AdSize.banner,
      listener: BannerAdListener(
        onAdLoaded: (ad) {
          if (!mounted) {
            ad.dispose();
            return;
          }
          setState(() {
            _bannerAd = ad as BannerAd;
            _isBannerAdReady = true;
          });
        },
        onAdFailedToLoad: (ad, error) {
          if (kDebugMode) {
            debugPrint('BannerAd failed to load: $error');
          }
          ad.dispose();
        },
      ),
    );

    ad.load();
  }

  void _loadInterstitialAd() {
    final adUnitId = AdMobConstants.interstitialAdUnitId();
    if (adUnitId == null) {
      return;
    }

    InterstitialAd.load(
      adUnitId: adUnitId,
      request: const AdRequest(),
      adLoadCallback: InterstitialAdLoadCallback(
        onAdLoaded: (ad) {
          _interstitialAd = ad;
        },
        onAdFailedToLoad: (error) {
          if (kDebugMode) {
            debugPrint('InterstitialAd failed to load: $error');
          }
          _interstitialAd = null;
        },
      ),
    );
  }

  Future<bool> _showInterstitialIfReady() async {
    final ad = _interstitialAd;
    if (ad == null) return false;

    _interstitialAd = null;

    ad.fullScreenContentCallback = FullScreenContentCallback(
      onAdDismissedFullScreenContent: (ad) {
        ad.dispose();
        _loadInterstitialAd();
      },
      onAdFailedToShowFullScreenContent: (ad, error) {
        ad.dispose();
        _loadInterstitialAd();
      },
    );

    await ad.show();
    return true;
  }

  // Ad unit IDs are centralized in AdMobConstants.

  @override
  void dispose() {
    _animController.dispose();
    _bannerAd?.dispose();
    _interstitialAd?.dispose();
    super.dispose();
  }

  Future<void> _onTabTapped(int index) async {
    if (index == _currentIndex) return;
    final shouldShowInterstitial =
        (index == 1 && !_interstitialShownForHistory) ||
        (index == 2 && !_interstitialShownForSettings);
    if (shouldShowInterstitial) {
      final didShow = await _showInterstitialIfReady();
      if (didShow) {
        if (index == 1) {
          _interstitialShownForHistory = true;
        } else if (index == 2) {
          _interstitialShownForSettings = true;
        }
      }
      if (!mounted) return;
    }
    _animController.forward(from: 0);
    setState(() => _currentIndex = index);
  }

  void _onDestinationSelected(int index) {
    _onTabTapped(index);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          const SizedBox(height: kToolbarHeight * 0.2),
          Expanded(
            child: Container(
              color: Colors.transparent,
              child: FadeTransition(
                opacity: _fadeAnim,
                child: IndexedStack(index: _currentIndex, children: _pages),
              ),
            ),
          ),
        ],
      ),
      bottomNavigationBar: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          if (_isBannerAdReady && _bannerAd != null)
            SizedBox(
              width: _bannerAd!.size.width.toDouble(),
              height: _bannerAd!.size.height.toDouble(),
              child: AdWidget(ad: _bannerAd!),
            ),
          NavigationBar(
            selectedIndex: _currentIndex,
            onDestinationSelected: _onDestinationSelected,
            destinations: const [
              NavigationDestination(
                icon: Icon(Icons.video_library_outlined),
                selectedIcon: Icon(Icons.video_library_rounded),
                label: 'Library',
              ),
              NavigationDestination(
                icon: Icon(Icons.history_outlined),
                selectedIcon: Icon(Icons.history_rounded),
                label: 'History',
              ),
              NavigationDestination(
                icon: Icon(Icons.settings_outlined),
                selectedIcon: Icon(Icons.settings_rounded),
                label: 'Settings',
              ),
            ],
          ),
        ],
      ),
    );
  }
}

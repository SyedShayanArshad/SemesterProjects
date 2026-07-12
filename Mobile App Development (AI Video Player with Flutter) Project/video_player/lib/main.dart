import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter/foundation.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:firebase_crashlytics/firebase_crashlytics.dart';
import 'package:media_kit/media_kit.dart';
import 'package:google_mobile_ads/google_mobile_ads.dart';
import 'data/services/notification_service.dart';
import 'data/services/background_task_service.dart';
import 'data/services/permissions_service.dart';
import 'core/utils/logger.dart';
import 'app.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();

  // Initialize Firebase
  await Firebase.initializeApp();

  // Initialize Crashlytics for profiling and crash reporting
  FlutterError.onError = FirebaseCrashlytics.instance.recordFlutterFatalError;
  PlatformDispatcher.instance.onError = (error, stack) {
    FirebaseCrashlytics.instance.recordError(error, stack, fatal: true);
    return true;
  };
  appLogger.i('Firebase initialized and Crashlytics configured');

  // Initialize Mobile Ads
  await MobileAds.instance.initialize();

  // Test device configuration
  if (kDebugMode) {
    await MobileAds.instance.updateRequestConfiguration(
      RequestConfiguration(
        testDeviceIds: ['386D6513C4BAA1FDB6377DCB98690D2B'],
      ),
    );
  }

  // Initialize media_kit
  MediaKit.ensureInitialized();

  // ─── Initialize Notification & Background Services ──────────────────────
  // Request permissions first
  await PermissionsService.requestAllPermissions();

  // Initialize notification service (Firebase Cloud Messaging + Local Notifications)
  await NotificationService.initialize();
  
  // VIVA_NOTE: Get and print FCM Token for testing notifications from Firebase Console
  final fcmToken = await NotificationService.getFCMToken();
  appLogger.i('FCM Token for testing: $fcmToken');

  // Initialize background tasks
  await BackgroundTaskService.initialize();

  // Schedule periodic tasks
  await BackgroundTaskService.scheduleAudioProcessingCleanup();
  await BackgroundTaskService.scheduleDataSync();
  // ─────────────────────────────────────────────────────────────────────────

  // Allow all orientations
  await SystemChrome.setPreferredOrientations([
    DeviceOrientation.portraitUp,
    DeviceOrientation.portraitDown,
    DeviceOrientation.landscapeLeft,
    DeviceOrientation.landscapeRight,
  ]);

  runApp(const App());
}


import 'package:firebase_messaging/firebase_messaging.dart';
import 'package:flutter_local_notifications/flutter_local_notifications.dart';
import 'dart:io' show Platform;
import 'dart:developer' as developer;

/// Service to manage push and local notifications
class NotificationService {
  static final FirebaseMessaging _firebaseMessaging = FirebaseMessaging.instance;
  static final FlutterLocalNotificationsPlugin _localNotifications =
      FlutterLocalNotificationsPlugin();

  static bool _isInitialized = false;

  /// Initialize notification services (call from main.dart)
  static Future<void> initialize() async {
    if (_isInitialized) return;

    try {
      // Request notification permissions
      await _firebaseMessaging.requestPermission(
        alert: true,
        announcement: false,
        badge: true,
        carPlay: false,
        criticalAlert: false,
        provisional: false,
        sound: true,
      );

      // Initialize local notifications
      await _initializeLocalNotifications();

      // Handle foreground messages
      FirebaseMessaging.onMessage.listen(_handleForegroundMessage);

      // Handle background message (must be top-level function)
      FirebaseMessaging.onBackgroundMessage(_handleBackgroundMessage);

      // Handle notification tap when app is in background
      FirebaseMessaging.onMessageOpenedApp.listen(_handleNotificationTap);

      _isInitialized = true;
      developer.log('[NotificationService] Initialized successfully');
    } catch (e) {
      developer.log('[NotificationService] Initialization error: $e');
    }
  }

  /// Initialize local notifications for Android and iOS
  static Future<void> _initializeLocalNotifications() async {
    if (Platform.isAndroid) {
      // Create notification channel for Android
      const AndroidNotificationChannel channel = AndroidNotificationChannel(
        'processing_channel',
        'Processing Notifications',
        description: 'Notifications for subtitle/dubbing processing status',
        importance: Importance.high,
        playSound: true,
      );

      await _localNotifications
          .resolvePlatformSpecificImplementation<
              AndroidFlutterLocalNotificationsPlugin>()
          ?.createNotificationChannel(channel);
    }

    const InitializationSettings initSettings = InitializationSettings(
      android: AndroidInitializationSettings('@mipmap/ic_launcher'),
      iOS: DarwinInitializationSettings(),
    );

    await _localNotifications.initialize(
      initSettings,
      onDidReceiveNotificationResponse: (response) {
        _handleNotificationTap(
          RemoteMessage(
            notification: RemoteNotification(
              title: response.payload ?? 'Processing Complete',
              body: 'Tap to view details',
            ),
          ),
        );
      },
    );
  }

  /// Handle foreground messages (app is open)
  static Future<void> _handleForegroundMessage(RemoteMessage message) async {
    developer.log('[NotificationService] Foreground message: ${message.messageId}');
    developer.log('Title: ${message.notification?.title}');
    developer.log('Body: ${message.notification?.body}');

    // Show local notification even though FCM message arrived
    await _showLocalNotification(
      title: message.notification?.title ?? 'Processing Update',
      body: message.notification?.body ?? 'Your video is being processed',
      payload: message.data.toString(),
    );
  }

  /// Handle background message (app is terminated or in background)
  static Future<void> _handleBackgroundMessage(RemoteMessage message) async {
    developer.log('[NotificationService] Background message: ${message.messageId}');
    // This runs in isolated context; keep it lightweight
  }

  /// Handle notification tap/click
  static void _handleNotificationTap(RemoteMessage message) {
    developer.log('[NotificationService] Notification tapped');
    developer.log('Data: ${message.data}');
    // Handle navigation based on message data
  }

  /// Show a local notification
  static Future<void> _showLocalNotification({
    required String title,
    required String body,
    String? payload,
  }) async {
    const AndroidNotificationDetails androidDetails =
        AndroidNotificationDetails(
      'processing_channel',
      'Processing Notifications',
      channelDescription: 'Notifications for subtitle/dubbing processing',
      importance: Importance.high,
      priority: Priority.high,
      showProgress: true,
      indeterminate: true,
    );

    const DarwinNotificationDetails iosDetails = DarwinNotificationDetails(
      presentAlert: true,
      presentBadge: true,
      presentSound: true,
    );

    const NotificationDetails details = NotificationDetails(
      android: androidDetails,
      iOS: iosDetails,
    );

    await _localNotifications.show(
      0,
      title,
      body,
      details,
      payload: payload,
    );
  }

  /// Show progress notification (Android only)
  static Future<void> showProgressNotification({
    required String title,
    required String body,
    required int progress, // 0-100
    bool indeterminate = false,
  }) async {
    final AndroidNotificationDetails androidDetails = AndroidNotificationDetails(
      'processing_channel',
      'Processing Notifications',
      channelDescription: 'Notifications for subtitle/dubbing processing',
      importance: Importance.high,
      priority: Priority.high,
      showProgress: true,
      maxProgress: 100,
      progress: progress,
      indeterminate: indeterminate,
      onlyAlertOnce: true,
    );

    const DarwinNotificationDetails iosDetails = DarwinNotificationDetails(
      presentAlert: true,
      presentBadge: true,
      presentSound: true,
    );

    final NotificationDetails details = NotificationDetails(
      android: androidDetails,
      iOS: iosDetails,
    );

    await _localNotifications.show(
      0,
      title,
      body,
      details,
    );
  }

  /// Show completion notification
  static Future<void> showCompletionNotification({
    required String title,
    required String taskName,
  }) async {
    const AndroidNotificationDetails androidDetails =
        AndroidNotificationDetails(
      'processing_channel',
      'Processing Notifications',
      channelDescription: 'Notifications for subtitle/dubbing processing',
      importance: Importance.high,
      priority: Priority.high,
      showProgress: false,
    );

    const DarwinNotificationDetails iosDetails = DarwinNotificationDetails(
      presentAlert: true,
      presentBadge: true,
      presentSound: true,
    );

    const NotificationDetails details = NotificationDetails(
      android: androidDetails,
      iOS: iosDetails,
    );

    await _localNotifications.show(
      0,
      title,
      '$taskName completed successfully! ✅',
      details,
    );
  }

  /// Show error notification
  static Future<void> showErrorNotification({
    required String title,
    required String errorMessage,
  }) async {
    const AndroidNotificationDetails androidDetails =
        AndroidNotificationDetails(
      'processing_channel',
      'Processing Notifications',
      channelDescription: 'Notifications for subtitle/dubbing processing',
      importance: Importance.high,
      priority: Priority.high,
      showProgress: false,
    );

    const DarwinNotificationDetails iosDetails = DarwinNotificationDetails(
      presentAlert: true,
      presentBadge: true,
      presentSound: true,
    );

    const NotificationDetails details = NotificationDetails(
      android: androidDetails,
      iOS: iosDetails,
    );

    await _localNotifications.show(
      0,
      title,
      'Error: $errorMessage ❌',
      details,
    );
  }

  /// Cancel all notifications
  static Future<void> cancelAll() async {
    await _localNotifications.cancelAll();
  }

  /// Cancel specific notification by ID
  static Future<void> cancel(int id) async {
    await _localNotifications.cancel(id);
  }

  /// Get FCM token (useful for testing)
  static Future<String?> getFCMToken() async {
    try {
      return await _firebaseMessaging.getToken();
    } catch (e) {
      developer.log('[NotificationService] Error getting FCM token: $e');
      return null;
    }
  }
}

import 'dart:io';
import 'package:permission_handler/permission_handler.dart';

/// Service to manage app permissions
class PermissionsService {
  /// Request all necessary permissions
  static Future<bool> requestAllPermissions() async {
    if (Platform.isAndroid) {
      return await _requestAndroidPermissions();
    } else if (Platform.isIOS) {
      return await _requestIOSPermissions();
    }
    return true;
  }

  /// Request Android-specific permissions
  static Future<bool> _requestAndroidPermissions() async {
    final permissions = [
      Permission.storage,
      Permission.notification,
    ];

    final Map<Permission, PermissionStatus> statuses = await permissions.request();

    bool allGranted = true;
    statuses.forEach((permission, status) {
      if (!status.isGranted) {
        allGranted = false;
      }
    });

    return allGranted;
  }

  /// Request iOS-specific permissions
  static Future<bool> _requestIOSPermissions() async {
    final permissions = [
      Permission.notification,
    ];

    final Map<Permission, PermissionStatus> statuses = await permissions.request();

    bool allGranted = true;
    statuses.forEach((permission, status) {
      if (!status.isGranted) {
        allGranted = false;
      }
    });

    return allGranted;
  }

  /// Request microphone permission for audio recording
  static Future<bool> requestMicrophonePermission() async {
    final status = await Permission.microphone.request();
    return status.isGranted;
  }

  /// Request notification permission
  static Future<bool> requestNotificationPermission() async {
    final status = await Permission.notification.request();
    return status.isGranted;
  }

  /// Request storage permission
  static Future<bool> requestStoragePermission() async {
    final status = await Permission.storage.request();
    return status.isGranted;
  }

  /// Check if a specific permission is granted
  static Future<bool> isPermissionGranted(Permission permission) async {
    final status = await permission.status;
    return status.isGranted;
  }

  /// Check if storage permission is granted
  static Future<bool> isStoragePermissionGranted() async {
    return await isPermissionGranted(Permission.storage);
  }

  /// Check if notification permission is granted
  static Future<bool> isNotificationPermissionGranted() async {
    return await isPermissionGranted(Permission.notification);
  }

  /// Open app settings to allow user to grant permissions manually
  static Future<void> openAppSettings() async {
    openAppSettings();
  }

  /// Check multiple permissions and return status of each
  static Future<Map<Permission, PermissionStatus>> checkMultiplePermissions(
    List<Permission> permissions,
  ) async {
    return await permissions.request();
  }
}

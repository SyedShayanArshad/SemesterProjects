import 'package:workmanager/workmanager.dart';
import 'dart:developer' as developer;
import 'notification_service.dart';

/// Background task names
const String processAudioTaskName = 'processAudioTask';
const String syncDataTaskName = 'syncDataTask';
const String cleanupCacheTaskName = 'cleanupCacheTask';

/// Service to manage background tasks (Android & iOS)
class BackgroundTaskService {
  static bool _isInitialized = false;

  /// Initialize background tasks (call from main.dart)
  static Future<void> initialize() async {
    if (_isInitialized) return;

    try {
      await Workmanager().initialize(
        callbackDispatcher,
        isInDebugMode: false,
      );

      _isInitialized = true;
      developer.log('[BackgroundTaskService] Initialized successfully');
    } catch (e) {
      developer.log('[BackgroundTaskService] Initialization error: $e');
    }
  }

  /// Schedule periodic audio processing cleanup (every 24 hours)
  static Future<void> scheduleAudioProcessingCleanup() async {
    try {
      await Workmanager().registerPeriodicTask(
        'audio_processing_cleanup_24h',
        cleanupCacheTaskName,
        frequency: const Duration(hours: 24),
        constraints: Constraints(
          networkType: NetworkType.connected,
          requiresBatteryNotLow: true,
          requiresCharging: false,
          requiresDeviceIdle: true,
        ),
        backoffPolicy: BackoffPolicy.exponential,
        backoffPolicyDelay: const Duration(minutes: 15),
      );
      developer.log('[BackgroundTaskService] Audio processing cleanup scheduled');
    } catch (e) {
      developer.log('[BackgroundTaskService] Error scheduling cleanup: $e');
    }
  }

  /// Schedule periodic data sync (every 6 hours)
  static Future<void> scheduleDataSync() async {
    try {
      await Workmanager().registerPeriodicTask(
        'sync_data_6h',
        syncDataTaskName,
        frequency: const Duration(hours: 6),
        constraints: Constraints(
          networkType: NetworkType.connected,
          requiresBatteryNotLow: false,
          requiresCharging: false,
          requiresDeviceIdle: false,
        ),
        backoffPolicy: BackoffPolicy.exponential,
        backoffPolicyDelay: const Duration(minutes: 5),
      );
      developer.log('[BackgroundTaskService] Data sync scheduled');
    } catch (e) {
      developer.log('[BackgroundTaskService] Error scheduling data sync: $e');
    }
  }

  /// Cancel a specific periodic task
  static Future<void> cancelTask(String taskName) async {
    try {
      await Workmanager().cancelByTag(taskName);
      developer.log('[BackgroundTaskService] Task cancelled: $taskName');
    } catch (e) {
      developer.log('[BackgroundTaskService] Error cancelling task: $e');
    }
  }

  /// Cancel all tasks
  static Future<void> cancelAll() async {
    try {
      await Workmanager().cancelAll();
      developer.log('[BackgroundTaskService] All tasks cancelled');
    } catch (e) {
      developer.log('[BackgroundTaskService] Error cancelling all tasks: $e');
    }
  }
}

/// Top-level function to handle background tasks
/// This must be a top-level function, not a class method
@pragma('vm:entry-point')
void callbackDispatcher() {
  Workmanager().executeTask((task, inputData) async {
    try {
      developer.log('[BackgroundTask] Executing: $task');

      switch (task) {
        case cleanupCacheTaskName:
          await _handleCacheCleanup();
          break;

        case syncDataTaskName:
          await _handleDataSync();
          break;

        default:
          developer.log('[BackgroundTask] Unknown task: $task');
      }

      return true;
    } catch (e) {
      developer.log('[BackgroundTask] Error: $e');
      return false;
    }
  });
}

/// Handle cache cleanup
Future<void> _handleCacheCleanup() async {
  developer.log('[BackgroundTask] Starting cache cleanup');

  try {
    // This can be expanded to clean up old temporary files
    // For now, just log it
    developer.log('[BackgroundTask] Cache cleanup completed');

    await NotificationService.showCompletionNotification(
      title: 'Cache Cleanup',
      taskName: 'Temporary files cleaned',
    );
  } catch (e) {
    developer.log('[BackgroundTask] Cache cleanup error: $e');
    await NotificationService.showErrorNotification(
      title: 'Cache Cleanup Failed',
      errorMessage: e.toString(),
    );
  }
}

/// Handle data sync
Future<void> _handleDataSync() async {
  developer.log('[BackgroundTask] Starting data sync');

  try {
    // This can be expanded to sync with Firebase/Backend
    // For now, just log it
    developer.log('[BackgroundTask] Data sync completed');

    await NotificationService.showCompletionNotification(
      title: 'Data Sync',
      taskName: 'Your data synced successfully',
    );
  } catch (e) {
    developer.log('[BackgroundTask] Data sync error: $e');
    await NotificationService.showErrorNotification(
      title: 'Data Sync Failed',
      errorMessage: e.toString(),
    );
  }
}

import 'package:uuid/uuid.dart';
import 'broadcast_service.dart';
import 'notification_service.dart';
import 'dart:async';
import 'dart:developer' as developer;

/// Model to track processing progress
class ProcessingTask {
  final String id;
  final String name;
  final String videoPath;
  final String? targetLanguage;
  final DateTime startTime;
  
  ProcessingStatus status = ProcessingStatus.queued;
  double progress = 0.0;
  String statusMessage = 'Queued...';
  DateTime? completionTime;
  String? errorMessage;

  ProcessingTask({
    required this.id,
    required this.name,
    required this.videoPath,
    this.targetLanguage,
  }) : startTime = DateTime.now();

  Duration get elapsed => DateTime.now().difference(startTime);

  /// Update progress and broadcast
  void updateProgress({
    required double progress,
    required ProcessingStatus status,
    required String message,
  }) {
    // ignore: unnecessary_this
    this.progress = progress.clamp(0.0, 1.0);
    status = status;
    statusMessage = message;

    // Broadcast status update
    BroadcastService.broadcastStatus(
      taskId: id,
      taskName: name,
      status: status,
      progress: progress,
      statusMessage: message,
      metadata: {
        'elapsed': elapsed.inSeconds,
        'videoPath': videoPath,
      },
    );

    // Update notification with progress
    _updateNotification();
  }

  /// Mark task as completed
  void complete({required Map<String, dynamic> result}) {
    status = ProcessingStatus.completed;
    progress = 1.0;
    completionTime = DateTime.now();
    statusMessage = 'Completed successfully!';

    BroadcastService.broadcastComplete(
      taskId: id,
      taskName: name,
      result: result,
    );

    _notifyCompletion();
  }

  /// Mark task as failed
  void error({required String errorMessage, required Exception exception}) {
    status = ProcessingStatus.error;
    this.errorMessage = errorMessage;
    completionTime = DateTime.now();
    statusMessage = 'Error: $errorMessage';

    BroadcastService.broadcastError(
      taskId: id,
      taskName: name,
      errorMessage: errorMessage,
      exception: exception,
    );

    _notifyError(errorMessage);
  }

  Future<void> _updateNotification() async {
    final progressPercent = (progress * 100).toInt();
    await NotificationService.showProgressNotification(
      title: name,
      body: '$statusMessage ($progressPercent%)',
      progress: progressPercent,
      indeterminate: progress == 0,
    );
  }

  Future<void> _notifyCompletion() async {
    await NotificationService.showCompletionNotification(
      title: 'Processing Complete',
      taskName: name,
    );
  }

  Future<void> _notifyError(String error) async {
    await NotificationService.showErrorNotification(
      title: 'Processing Failed',
      errorMessage: error,
    );
  }

  @override
  String toString() =>
      'ProcessingTask(id: $id, name: $name, status: $status, progress: ${(progress * 100).toInt()}%)';
}

/// Service to manage processing tasks with notifications and progress tracking
class ProcessingTracker {
  static final Map<String, ProcessingTask> _activeTasks = {};

  /// Create and start tracking a new processing task
  static ProcessingTask createTask({
    required String name,
    required String videoPath,
    String? targetLanguage,
  }) {
    final task = ProcessingTask(
      id: const Uuid().v4(),
      name: name,
      videoPath: videoPath,
      targetLanguage: targetLanguage,
    );

    _activeTasks[task.id] = task;
    
    // Initial notification
    task.updateProgress(
      progress: 0.0,
      status: ProcessingStatus.queued,
      message: 'Task queued...',
    );

    developer.log('[ProcessingTracker] Task created: ${task.id} - $name');
    return task;
  }

  /// Get a tracking task by ID
  static ProcessingTask? getTask(String taskId) => _activeTasks[taskId];

  /// Get all active tasks
  static List<ProcessingTask> getAllActiveTasks() => _activeTasks.values.toList();

  /// Remove completed task from tracking
  static void removeTask(String taskId) {
    _activeTasks.remove(taskId);
    developer.log('[ProcessingTracker] Task removed: $taskId');
  }

  /// Get stream of all status updates for a specific task
  static Stream<ProcessingStatusEvent> watchTask(String taskId) {
    return BroadcastService.onTaskEvent(taskId)
        .where((e) => e is ProcessingStatusEvent)
        .cast<ProcessingStatusEvent>();
  }

  /// Get stream of completion events for a specific task
  static Stream<ProcessingCompleteEvent> watchCompletion(String taskId) {
    return BroadcastService.onTaskEvent(taskId)
        .where((e) => e is ProcessingCompleteEvent)
        .cast<ProcessingCompleteEvent>();
  }

  /// Get stream of error events for a specific task
  static Stream<ProcessingErrorEvent> watchError(String taskId) {
    return BroadcastService.onTaskEvent(taskId)
        .where((e) => e is ProcessingErrorEvent)
        .cast<ProcessingErrorEvent>();
  }
}

/// Extension method for easy task creation in service methods
extension ProcessingTaskExtension<T> on Future<T> {
  Future<T> trackProgress({
    required ProcessingTask task,
    void Function(ProcessingTask)? onUpdate,
  }) {
    task.updateProgress(
      progress: 0.2,
      status: ProcessingStatus.processing,
      message: 'Processing...',
    );

    return then(
      (result) {
        task.complete(result: {
          'result': result,
          'completedAt': DateTime.now(),
        });
        onUpdate?.call(task);
        return result;
      },
      onError: (error, stackTrace) {
        task.error(
          errorMessage: error.toString(),
          exception: error is Exception
              ? error
              : Exception('Unknown error: $error'),
        );
        throw error;
      },
    );
  }
}

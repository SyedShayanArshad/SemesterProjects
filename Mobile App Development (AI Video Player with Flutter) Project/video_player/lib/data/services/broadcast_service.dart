import 'package:event_bus/event_bus.dart';

/// Event fired when processing status changes
class ProcessingStatusEvent {
  final String taskId;
  final String taskName; // 'subtitles', 'dubbing', 'full_process'
  final ProcessingStatus status;
  final double progress; // 0.0 to 1.0
  final String statusMessage;
  final DateTime timestamp;
  final Map<String, dynamic>? metadata;

  ProcessingStatusEvent({
    required this.taskId,
    required this.taskName,
    required this.status,
    required this.progress,
    required this.statusMessage,
    required this.timestamp,
    this.metadata,
  });

  @override
  String toString() =>
      'ProcessingStatusEvent(taskId: $taskId, taskName: $taskName, status: $status, progress: ${(progress * 100).toStringAsFixed(1)}%, message: $statusMessage)';
}

/// Status of processing task
enum ProcessingStatus {
  queued,
  extracting,
  uploading,
  processing,
  downloading,
  mixing,
  completed,
  error,
}

/// Event fired when processing is completed successfully
class ProcessingCompleteEvent {
  final String taskId;
  final String taskName;
  final Map<String, dynamic> result;
  final DateTime timestamp;

  ProcessingCompleteEvent({
    required this.taskId,
    required this.taskName,
    required this.result,
    required this.timestamp,
  });
}

/// Event fired when processing encounters an error
class ProcessingErrorEvent {
  final String taskId;
  final String taskName;
  final String errorMessage;
  final Exception exception;
  final DateTime timestamp;

  ProcessingErrorEvent({
    required this.taskId,
    required this.taskName,
    required this.errorMessage,
    required this.exception,
    required this.timestamp,
  });
}

/// Global event bus for broadcasting progress and status updates
final eventBus = EventBus();

/// Service to broadcast and listen to processing events
class BroadcastService {
  /// Broadcast a processing status update
  static void broadcastStatus({
    required String taskId,
    required String taskName,
    required ProcessingStatus status,
    required double progress,
    required String statusMessage,
    Map<String, dynamic>? metadata,
  }) {
    eventBus.fire(ProcessingStatusEvent(
      taskId: taskId,
      taskName: taskName,
      status: status,
      progress: progress,
      statusMessage: statusMessage,
      timestamp: DateTime.now(),
      metadata: metadata,
    ));
  }

  /// Broadcast processing completion
  static void broadcastComplete({
    required String taskId,
    required String taskName,
    required Map<String, dynamic> result,
  }) {
    eventBus.fire(ProcessingCompleteEvent(
      taskId: taskId,
      taskName: taskName,
      result: result,
      timestamp: DateTime.now(),
    ));
  }

  /// Broadcast processing error
  static void broadcastError({
    required String taskId,
    required String taskName,
    required String errorMessage,
    required Exception exception,
  }) {
    eventBus.fire(ProcessingErrorEvent(
      taskId: taskId,
      taskName: taskName,
      errorMessage: errorMessage,
      exception: exception,
      timestamp: DateTime.now(),
    ));
  }

  /// Listen to status updates
  static Stream<ProcessingStatusEvent> onStatusUpdate() =>
      eventBus.on<ProcessingStatusEvent>();

  /// Listen to completion events
  static Stream<ProcessingCompleteEvent> onComplete() =>
      eventBus.on<ProcessingCompleteEvent>();

  /// Listen to error events
  static Stream<ProcessingErrorEvent> onError() =>
      eventBus.on<ProcessingErrorEvent>();

  /// Listen to any event for a specific task
  static Stream<dynamic> onTaskEvent(String taskId) {
    return eventBus.on().where((event) {
      if (event is ProcessingStatusEvent) return event.taskId == taskId;
      if (event is ProcessingCompleteEvent) return event.taskId == taskId;
      if (event is ProcessingErrorEvent) return event.taskId == taskId;
      return false;
    });
  }
}

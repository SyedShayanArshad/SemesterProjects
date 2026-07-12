#ifndef SCHEDULER_H
#define SCHEDULER_H

void enqueue_request(int client_fd, int priority);

int dequeue_request();

void init_scheduler();

#endif

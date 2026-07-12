#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>
#include <semaphore.h>

#include "scheduler.h"
#include "common.h"

typedef struct
{
    int client_fd;
} Request;
typedef struct
{
    Request queue[MAX_QUEUE_SIZE];
    int front, rear, count;
} Queue;
static Queue high_q, med_q, low_q;

static pthread_mutex_t sched_lock = PTHREAD_MUTEX_INITIALIZER;
static sem_t sched_sem;

void init_queue(Queue *q)
{
    q->front = q->rear = q->count = 0;
}

int enqueue(Queue *q, Request r)
{
    if (q->count == MAX_QUEUE_SIZE)
    {
        return -1;
    }

    q->queue[q->rear] = r;
    q->rear = (q->rear + 1) % MAX_QUEUE_SIZE;
    q->count++;
    return 0;
}

int dequeue(Queue *q, Request *r)
{
    if (q->count == 0)
    {
        return -1;
    }

    *r = q->queue[q->front];
    q->front = (q->front + 1) % MAX_QUEUE_SIZE;
    q->count--;
    return 0;
}

void init_scheduler()
{
    init_queue(&high_q);
    init_queue(&med_q);
    init_queue(&low_q);
    sem_init(&sched_sem, 0, 0);
}
void enqueue_request(int client_fd, int priority)
{
    pthread_mutex_lock(&sched_lock);

    Request r;
    r.client_fd = client_fd;

    int res = -1;

    if (priority == PRIORITY_HIGH)
    {
        res = enqueue(&high_q, r);
    }
    else if (priority == PRIORITY_MEDIUM)
    {
        res = enqueue(&med_q, r);
    }
    else
    {
        res = enqueue(&low_q, r);
    }
    if (res == -1)
    {
        printf("[Scheduler] Queue full, dropping request\n");
        close(client_fd);
    }
    else
    {
        sem_post(&sched_sem);
    }

    pthread_mutex_unlock(&sched_lock);
}
int dequeue_request()
{
    Request r;

    sem_wait(&sched_sem);
    pthread_mutex_lock(&sched_lock);

    if (high_q.count > 0)
    {
        dequeue(&high_q, &r);
    }
    else if (med_q.count > 0)
    {
        dequeue(&med_q, &r);
    }
    else
    {
        dequeue(&low_q, &r);
    }
    pthread_mutex_unlock(&sched_lock);
    return r.client_fd;
}

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

#include "thread_pool.h"
#include "scheduler.h"
#include "cache.h"
#include "ipc.h"
#include "common.h"

static pthread_t workers[MAX_THREADS];

void *worker_thread(void *arg)
{
    int client_fd;

    while (1)
    {
        client_fd = dequeue_request();

        printf("[Thread %lu] Handling client\n", pthread_self());

        handle_client(client_fd);

        close(client_fd);
    }

    return NULL;
}

void init_thread_pool()
{
    int i;

    init_scheduler();

    for (i = 0; i < MAX_THREADS; i++)
    {
        if (pthread_create(&workers[i], NULL, worker_thread, NULL) != 0)
        {
            perror("pthread_create failed");
            exit(EXIT_FAILURE);
        }
    }

    printf("[Thread Pool] %d worker threads created\n", MAX_THREADS);
}

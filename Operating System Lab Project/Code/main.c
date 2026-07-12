#include <stdio.h>
#include <stdlib.h>
#include <signal.h>
#include <unistd.h>

#include "server.h"
#include "thread_pool.h"
#include "ipc.h"
#include "cache.h"

void shutdown_handler(int sig)
{
    printf("\n[Server] Shutting down, generating report...\n");
    export_cache_stats();
    cleanup_shared_memory();
    destroy_cache();
    exit(0);
}
int main()
{
    signal(SIGINT, shutdown_handler);
    printf("=== OS Lab Project: Multithreaded Proxy Server ===\n");
    if (init_shared_memory() == -1)
    {
        perror("Shared memory failed");
        exit(1);
    }
    init_cache();
    if (fork() == 0)
    {
        execlp("xterm", "xterm", "-e", "./logger", NULL);
        exit(1);
    }
    if (fork() == 0)
    {
        execl("./monitor", "monitor", NULL);
        exit(1);
    }
    init_thread_pool();
    start_server();
    return 0;
}

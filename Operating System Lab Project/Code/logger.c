#include <stdio.h>
#include <unistd.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include "ipc.h"
int main()
{
    int shm_id;
    SharedStats *stats;
    shm_id = shmget(SHM_KEY, sizeof(SharedStats), 0666);
    if (shm_id < 0)
    {
        perror("Logger shmget failed");
        return 1;
    }
    stats = (SharedStats *)shmat(shm_id, NULL, 0);
    if (stats == (void *)-1)
    {
        perror("Logger shmat failed");
        return 1;
    }
    printf("=== Logger Process Started ===\n");
    while (1)
    {
        printf("[Logger] Cache Hits: %d | Cache Misses: %d\n",
               stats->cacheHits, stats->cacheMisses);
        sleep(5);
    }
    shmdt(stats);
    return 0;
}

#include <sys/ipc.h>
#include <sys/shm.h>
#include <string.h>
#include "ipc.h"

static int shm_id;
static SharedStats *stats;
int init_shared_memory()
{
    shm_id = shmget(SHM_KEY, sizeof(SharedStats),
                    IPC_CREAT | 0666);
    if (shm_id < 0)
    {
        return -1;
    }

    stats = (SharedStats *)shmat(shm_id, NULL, 0);
    memset(stats, 0, sizeof(SharedStats));
    return 0;
}
SharedStats *get_shared_stats()
{
    return stats;
}
void update_cache_hit()
{
    stats->cacheHits++;
    stats->totalRequests++;
}
void update_cache_miss()
{
    stats->cacheMisses++;
    stats->totalRequests++;
}
void cleanup_shared_memory()
{
    shmdt(stats);
    shmctl(shm_id, IPC_RMID, NULL);
}

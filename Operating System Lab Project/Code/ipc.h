#ifndef IPC_H
#define IPC_H

#include "common.h"

#define SHM_KEY 1234

typedef struct
{
    char url[MAX_URL_LEN];
    int accessCount;
    int hits;
    int misses;
} LiveURLStats;

typedef struct
{
    int totalRequests;
    int cacheHits;
    int cacheMisses;
    int urlCount;
    LiveURLStats urls[MAX_URL_STATS];
} SharedStats;
int init_shared_memory();
SharedStats *get_shared_stats();
void update_cache_hit();
void update_cache_miss();
void cleanup_shared_memory();
#endif

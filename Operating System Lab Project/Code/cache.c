#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <pthread.h>
#include <time.h>

#include "cache.h"
#include "ipc.h"
#include "report.h"
#include "common.h"

typedef struct
{
    char url[MAX_URL_LEN];
    char *data;
    int frequency;
    time_t lastAccess;
} CacheEntry;
static CacheEntry cache[MAX_CACHE_SIZE];
static int cacheCount = 0;
static URLStats urlStats[MAX_URL_STATS];
static int statsCounts = 0;
static pthread_mutex_t cacheLock = PTHREAD_MUTEX_INITIALIZER;
static SharedStats *liveStats = NULL;
static int find_url_stats(const char *url)
{
    for (int i = 0; i < statsCounts; i++)
        if (strcmp(urlStats[i].url, url) == 0)
            return i;
    return -1;
}
static int create_url_stats(const char *url)
{
    int idx = statsCounts++;
    strcpy(urlStats[idx].url, url);
    urlStats[idx].access_count = 0;
    urlStats[idx].cache_hits = 0;
    urlStats[idx].cache_misses = 0;
    urlStats[idx].total_latency = 0;
    urlStats[idx].min_latency = 1e9;
    urlStats[idx].max_latency = 0;
    urlStats[idx].first_access_time = time(NULL);
    urlStats[idx].last_access_time = urlStats[idx].first_access_time;
    int lidx = liveStats->urlCount++;
    strcpy(liveStats->urls[lidx].url, url);
    liveStats->urls[lidx].accessCount = 0;
    liveStats->urls[lidx].hits = 0;
    liveStats->urls[lidx].misses = 0;
    return idx;
}

void init_cache()
{
    cacheCount = 0;
    statsCounts = 0;
    liveStats = get_shared_stats();
}

void destroy_cache()
{
    for (int i = 0; i < cacheCount; i++)
    {
        free(cache[i].data);
    }
}

void handle_client(int client_fd)
{
    struct timespec start, end;
    clock_gettime(CLOCK_MONOTONIC, &start);
    char buffer[BUFFER_SIZE], url[MAX_URL_LEN];
    int n = read(client_fd, buffer, BUFFER_SIZE - 1);
    if (n <= 0)
    {
        return;
    }
    buffer[n] = '\0';
    sscanf(buffer, "GET %s", url);
    if (strlen(url) == 0)
    {
        return;
    }
    pthread_mutex_lock(&cacheLock);
    int sidx = find_url_stats(url);
    if (sidx == -1)
    {
        sidx = create_url_stats(url);
    }
    urlStats[sidx].access_count++;
    urlStats[sidx].last_access_time = time(NULL);
    liveStats->urls[sidx].accessCount++;
    int hit = -1;
    for (int i = 0; i < cacheCount; i++)
    {
        if (strcmp(cache[i].url, url) == 0)
        {
            hit = i;
            break;
        }
    }
    if (hit != -1)
    {
        cache[hit].frequency++;
        cache[hit].lastAccess = time(NULL);
        write(client_fd, cache[hit].data, strlen(cache[hit].data));
        update_cache_hit();
        urlStats[sidx].cache_hits++;
        liveStats->urls[sidx].hits++;
    }
    else
    {
        if (cacheCount == MAX_CACHE_SIZE)
        {
            free(cache[0].data);
            for (int i = 0; i < cacheCount - 1; i++)
            {
                cache[i] = cache[i + 1];
            }
            cacheCount--;
        }
        char *resp = malloc(BUFFER_SIZE);
        snprintf(resp, BUFFER_SIZE,
                 "HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\nCached response for %s\n",
                 url);
        strcpy(cache[cacheCount].url, url);
        cache[cacheCount].data = resp;
        cache[cacheCount].frequency = 1;
        cache[cacheCount].lastAccess = time(NULL);
        cacheCount++;
        write(client_fd, resp, strlen(resp));
        update_cache_miss();
        urlStats[sidx].cache_misses++;
        liveStats->urls[sidx].misses++;
    }
    clock_gettime(CLOCK_MONOTONIC, &end);
    double latency =
        (end.tv_sec - start.tv_sec) * 1000.0 +
        (end.tv_nsec - start.tv_nsec) / 1e6;
    urlStats[sidx].total_latency += latency;
    if (latency < urlStats[sidx].min_latency)
    {
        urlStats[sidx].min_latency = latency;
    }
    if (latency > urlStats[sidx].max_latency)
    {
        urlStats[sidx].max_latency = latency;
    }
    pthread_mutex_unlock(&cacheLock);
}
void export_cache_stats()
{
    generate_report(urlStats, statsCounts);
}

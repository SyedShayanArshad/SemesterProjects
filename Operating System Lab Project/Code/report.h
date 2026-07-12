#ifndef REPORT_H
#define REPORT_H

#include <time.h>
#include "common.h"

typedef struct {
    char url[MAX_URL_LEN];

    int access_count;
    int cache_hits;
    int cache_misses;

    double total_latency;
    double min_latency;
    double max_latency;

    time_t first_access_time;   
    time_t last_access_time;    
} URLStats;

void generate_report(URLStats *stats, int count);

#endif

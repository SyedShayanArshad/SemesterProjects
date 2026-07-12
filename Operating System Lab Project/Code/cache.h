#ifndef CACHE_H
#define CACHE_H

void init_cache();
void destroy_cache();
void handle_client(int client_fd);
void export_cache_stats();

#endif

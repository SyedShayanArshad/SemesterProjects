#ifndef THREAD_POOL_H
#define THREAD_POOL_H

void init_thread_pool();
void *worker_thread(void *arg);

#endif

CC = gcc
CFLAGS = -Wall -pthread

PROXY = proxy
LOGGER = logger
MONITOR = monitor

PROXY_SRC = main.c server.c scheduler.c thread_pool.c cache.c ipc.c report.c
LOGGER_SRC = logger.c ipc.c
MONITOR_SRC = monitor.c ipc.c

all: $(PROXY) $(LOGGER) $(MONITOR)

$(PROXY):
	$(CC) $(CFLAGS) $(PROXY_SRC) -o $(PROXY)

$(LOGGER):
	$(CC) $(LOGGER_SRC) -o $(LOGGER)

$(MONITOR):
	$(CC) $(MONITOR_SRC) -lncurses -o $(MONITOR)

clean:
	rm -f proxy logger monitor *.o proxy_report.txt

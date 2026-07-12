#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>

#include "server.h"
#include "scheduler.h"
#include "common.h"

static int server_fd;
void init_server()
{
    struct sockaddr_in server_addr;
    int opt = 1;

    server_fd = socket(AF_INET, SOCK_STREAM, 0);
    if (server_fd < 0)
    {
        perror("socket failed");
        exit(EXIT_FAILURE);
    }

    setsockopt(server_fd, SOL_SOCKET, SO_REUSEADDR, &opt, sizeof(opt));

    server_addr.sin_family = AF_INET;
    server_addr.sin_addr.s_addr = INADDR_ANY;
    server_addr.sin_port = htons(SERVER_PORT);

    if (bind(server_fd, (struct sockaddr *)&server_addr,
             sizeof(server_addr)) < 0)
    {
        perror("bind failed");
        exit(EXIT_FAILURE);
    }

    if (listen(server_fd, BACKLOG) < 0)
    {
        perror("listen failed");
        exit(EXIT_FAILURE);
    }

    printf("[Server] Listening on port %d...\n", SERVER_PORT);
}

void start_server()
{
    int client_fd;
    struct sockaddr_in client_addr;
    socklen_t addr_len = sizeof(client_addr);

    init_server();

    while (1)
    {
        client_fd = accept(server_fd,
                           (struct sockaddr *)&client_addr,
                           &addr_len);

        if (client_fd < 0)
        {
            perror("accept failed");
            continue;
        }

        printf("[Server] Client connected\n");
        int priority = PRIORITY_MEDIUM;

        if (client_addr.sin_addr.s_addr == htonl(INADDR_LOOPBACK))
        {
            priority = PRIORITY_HIGH;
        }

        enqueue_request(client_fd, priority);
    }
}

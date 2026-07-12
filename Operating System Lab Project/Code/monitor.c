#include <ncurses.h>
#include <unistd.h>
#include <sys/ipc.h>
#include <sys/shm.h>

#include "ipc.h"
#include "common.h"

int main()
{
    int shm_id = shmget(SHM_KEY, sizeof(SharedStats), 0666);
    if (shm_id < 0)
    {
        return 1;
    }
    SharedStats *stats =
        (SharedStats *)shmat(shm_id, NULL, 0);
    initscr();
    noecho();
    curs_set(0);
    nodelay(stdscr, TRUE);
    while (1)
    {
        clear();
        mvprintw(1, 2, "============== PROXY LIVE DASHBOARD ==============");
        mvprintw(3, 2, "Total Requests : %d", stats->totalRequests);
        mvprintw(4, 2, "Cache Hits     : %d", stats->cacheHits);
        mvprintw(5, 2, "Cache Misses   : %d", stats->cacheMisses);
        mvprintw(7, 2, "--------------------------------------------------");
        mvprintw(8, 2, " URL                     Access   Hits   Misses");
        mvprintw(9, 2, "--------------------------------------------------");
        for (int i = 0; i < stats->urlCount; i++)
        {
            mvprintw(10 + i, 2, "%-24s %7d %7d %8d",
                     stats->urls[i].url,
                     stats->urls[i].accessCount,
                     stats->urls[i].hits,
                     stats->urls[i].misses);
        }
        mvprintw(12 + stats->urlCount, 2,
                 "Press 'q' to quit monitor");

        refresh();

        int ch = getch();
        if (ch == 'q')
        {
            break;
        }
        sleep(1);
    }
    endwin();
    shmdt(stats);
    return 0;
}

#include <stdio.h>
#include <cs50.h>

int main(void)
{
    int startLlamas;
    int endLlamas;

    do
    {
        startLlamas = get_int("Start size: ");
    } while(startLlamas < 9);

    do
    {
        endLlamas = get_int("End size: ");
    } while(endLlamas < startLlamas);

    int llamasBorn = 0;
    int llamasAway = 0;
    int totalLlamas = startLlamas;
    int y = 0;

    while(totalLlamas < endLlamas)
    {
        llamasBorn = startLlamas / 3;
        llamasAway = startLlamas / 4;

        startLlamas = startLlamas + llamasBorn - llamasAway;

        totalLlamas = startLlamas;
        y += 1;
    }

    printf("Years: %i\n", y);
}
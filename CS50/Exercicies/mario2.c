#include <stdio.h>
#include <cs50.h>

int main(void)
{
    int x;
    do
    {
        x = get_int("Tamanho: ");
    } while (x < 1 || x > 8);

    for(int i = 0; i < x; i++)
    {
        int z =  i + 1;
        for(int j = 0; j <= i; j++)
        {
            while(z <= x - 1)
            {
                printf(" ");
                z++;
            }
            printf("#");
        }
        printf(" ");
        for(int j = 0; j <= i; j++)
        {
            printf("#");
        }
        printf("\n");
    }
}

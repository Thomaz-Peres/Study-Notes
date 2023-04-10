#include <cs50.h>
#include <stdio.h>
#include <math.h>

int main (void)
{
    float x = get_float("Troca devida: ");
    int moedas = 0;

    int z = 25;
    int y = 10;
    int c = 5;
    int v = 1;

    x = round(x * 100);

    while (x > 0)
    {
        if(z <= x)
        {
            x -= z;
            moedas++;
        }
        else if(y <= x)
        {
            x -= y;
            moedas++;
        }
        else if(c <= x)
        {
            x -= c;
            moedas++;
        }
        else
        {
            x -= v;
            moedas++;
        }
    }

    printf("%i\n", moedas);
}
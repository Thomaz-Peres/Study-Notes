#include <stdio.h>

int main()
{
    int x = 10;
    printf("Valor de x: %i\n", x);

    int* y = &x;
    *y = 30;
    printf("Valor de x: %i\n", x);
    return 0;
}
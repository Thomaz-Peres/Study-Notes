#include <stdio.h>
#include <malloc.h>

int main()
{
    int* y = (int*) malloc(sizeof(int));
    printf("Valor de y: %i\n", y);
    *y = 20;
    int z = sizeof(int);
    printf("y = %i z = %i\n", *y, z);
    return 0;
}
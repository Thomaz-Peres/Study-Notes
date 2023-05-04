#include <cs50.h>
#include <stdio.h>

int factorial(int n);

int main(void)
{
    int n = get_int("The the number: ");

    printf("Result: %i\n", factorial(n));
}

int factorial(int n)
{
    if (n == 1)
        return 1;

    return n * factorial(n - 1);
}
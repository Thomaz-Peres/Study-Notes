#include <cs50.h>
#include <stdio.h>

int main (void)
{
    int numbers[] = {14, 7, 2, 15, 5, 8, 4, 13, 1, 9, 6, 10, 0, 3, 11, 12};

    for(int i = 0; i < 15; i++)
    {
        int x = 15;

        while(x > i)
        {
            if(numbers[i] > numbers[x])
            {
                int smallerNumber = numbers[x];
                int higherNumber = numbers[i];

                numbers[i] = smallerNumber;
                numbers[x] = higherNumber;
            }
            x--;
        }
    }

    for(int i = 0; i < 16; i++)
    {
        printf("Ordered numbers: %i\n", numbers[i]);
    }
}
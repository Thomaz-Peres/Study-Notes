#include <cs50.h>
#include <ctype.h>
#include <math.h>
#include <stdio.h>
#include <string.h>

int convert(string input);

int main(void)
{
    string input = get_string("Enter a positive integer: ");

    for (int i = 0, n = strlen(input); i < n; i++)
    {
        if (!isdigit(input[i]))
        {
            printf("Invalid Input!\n");
            return 1;
        }
    }

    // Convert string to int
    printf("%i\n", convert(input));
}

int convert(string input)
{
    if (input[0] == '\0')
        return 0;

    int i = 0;
    while (input[i] != '\0')
    {
        i++;
    }
    int a = input[i - 1] - '0';
    input[i - 1] = input[i];

    return 10 * convert(input) + (a);
}
#include <stdio.h>
#include <string.h>

int main()
{
    int input;
    scanf("%i", &input);
    char requestLed[1000];

    for (int i = 0; i < input; i++)
    {
        scanf("%s", requestLed);

        int soma = 0;
        for (int j = 0; requestLed[j] != '\0'; j++)
        {
            if (requestLed[j] == '0')
            {
                soma += 6;
            }
            else if (requestLed[j] == '1')
            {
                soma += 2;
            }
            else if (requestLed[j] == '2')
            {
                soma += 5;
            }
            else if (requestLed[j] == '3')
            {
                soma += 5;
            }
            else if (requestLed[j] == '4')
            {
                soma += 4;
            }
            else if (requestLed[j] == '5')
            {
                soma += 5;
            }
            else if (requestLed[j] == '6')
            {
                soma += 6;
            }
            else if (requestLed[j] == '7')
            {
                soma += 3;
            }
            else if (requestLed[j] == '8')
            {
                soma += 7;
            }
            else
            {
                soma += 6;
            }
        }
        printf("%i leds\n", soma);
    }

    return 0;
}
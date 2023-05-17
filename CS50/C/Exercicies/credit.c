#include <stdio.h>
#include <cs50.h>

bool checkSum(long x)
{
    long lastNumber = 0;
    long secondLast;
    long secondLastSum = 0;
    long finalCheckSum;
    int i = 0;
    while(x)
    {
        lastNumber += x % 10;
        secondLast = ((x % 100) / 10) * 2;

        if (secondLast >= 10)
        {
            while(secondLast)
            {
                secondLastSum += secondLast % 10;
                secondLast /= 10;
            }
        }
        else
            secondLastSum += secondLast;

        x /= 100;
        i += 2;
    }

    if(i < 13 || i > 16)
        return false;

    finalCheckSum = secondLastSum + lastNumber;

    if (finalCheckSum % 10 == 0)
        return true;
    else
        return false;
}

int main(void)
{

    long x = get_long("Numero: ");
    bool checked = checkSum(x);
    long twoFirstNumber;

    if(checked)
    {
        while(x >= 100)
        {
            x /= 10;
        }
        twoFirstNumber = x;

        if((twoFirstNumber / 10) == 4)
            printf("VISA\n");
        else if(twoFirstNumber == 34 || twoFirstNumber == 37)
            printf("AMEX\n");
        else if(twoFirstNumber == 51 || twoFirstNumber == 52 || twoFirstNumber == 53 || twoFirstNumber == 54 || twoFirstNumber == 55)
            printf("MASTERCARD\n");
        else
            printf("INVALID\n");
    }
    else
        printf("INVALID\n");
}
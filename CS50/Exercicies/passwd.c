#include <stdio.h>
#include <cs50.h>
#include <string.h>
#include <ctype.h>

bool check(string passwd);

int main(void)
{
    string x = get_string("Enter your password: ");

    bool checked = check(x);

    if(checked)
        printf("Your password is valid!\n");
    else
        printf("Your password needs at least one uppercase letter, lowercase letter, number and symbol!\n");

}

bool check(string passwd)
{
    bool checked;
    bool lower = false, upper = false, letter = false, number = false, simbol = false;
    for(int i = 0, n = strlen(passwd); i < n; i++)
    {
        char c = passwd[i];

        if (islower(c))
        {
            lower = true;
            letter = true;
        }
        else if (isupper(c))
            upper = true;
        else if (isdigit(c))
            number = true;
        else if (isalpha(c))
            letter = true;
        else
            simbol = true;
    }

    if(lower && upper && number && letter && simbol)
        checked = true;
    else
        checked = false;

    return checked;
}
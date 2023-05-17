#include <cs50.h>
#include <ctype.h>
#include <stdio.h>
#include <string.h>

string replace(string word);

int main(int argc, string word[])
{
    if(word[1] == NULL)
    {
        printf("Usage: ./no-vowels word\n");
        return 1;
    }
    else
    {
        replace(word[1]);
        printf("%s\n", word[1]);
        return 0;
    }
}

string replace(string word)
{
    for(int i = 0, n = strlen(word); i < n; i++)
    {
        char c = tolower(word[i]);

        switch(c)
        {
            case 'a':
                word[i] = '6';
                break;
            case 'e':
                word[i] = '3';
                break;
            case 'i':
                word[i] = '1';
                break;
            case 'o':
                word[i] = '0';
                break;
        }
    }
    return word;
}
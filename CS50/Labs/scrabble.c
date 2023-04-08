#include <ctype.h>
#include <cs50.h>
#include <stdio.h>
#include <string.h>

// Points assigned to each letter of the alphabet
int POINTS[] = {1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10};
char CHARS[] = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

int compute_score(string word);

int main(void)
{
    // Get input words from both players
    string word1 = get_string("Player 1: ");
    string word2 = get_string("Player 2: ");

    // Score both words
    int score1 = compute_score(word1);
    printf("score1: %i\n", score1);
    int score2 = compute_score(word2);
    printf("score2: %i\n", score2);

    // Print the winner
    if (score1 > score2)
        printf("Player 1 wins!\n");
    else if (score2 > score1)
        printf("Player 2 wins!\n");
    else
        printf("Tie!\n");
}

int compute_score(string word)
{
    int z = 0;
    // Compute and return score for string
    for (int i = 0, n = strlen(word); i < n; i++)
    {
        char c = tolower(word[i]);
        int b = 0;

        if(!isalpha(c) && ispunct(c))
            z += 0;
        else
        {
            while(CHARS[b] != c && isalpha(c) && !ispunct(c))
            {
                b++;
            }
            z += POINTS[b];
        }
    }

    return z;
}

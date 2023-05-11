// #include <stdio.h>
// #include <stdlib.h>

// int main(void)
// {
//     int *list = malloc(3 * sizeof(int));
//     if (list == NULL)
//     {
//         return 1;
//     }

//     list[0] = 1;
//     list[1] = 2;
//     list[2] = 3;

//     // Creating and improve the range of list

//     int *tmp = malloc(4 * sizeof(int));
//     if(tmp == NULL)
//     {
//         free(list);
//         return 1;
//     }

//     for(int i = 0; i < 3; i++)
//     {
//         tmp[i] = list[i];
//     }

//     tmp[3] = 4;

//     free(list);

//     list = tmp;

//     for(int i = 0; i < 3; i++)
//     {
//         printf("%i\n", list[i]);
//     }

//     free(list);
//     return 0;
// }

// #include <stdio.h>
// #include <stdlib.h>


// int main(void)
// {
//     // that part is just an array that we allocated and then reallocated.
//     int *list = malloc(3 * sizeof(int));
//     if (list == NULL)
//     {
//         return 1;
//     }

//     list[0] = 1;
//     list[1] = 2;
//     list[2] = 3;
//     // Creating and improve the range of list

//     int *tmp = realloc(list, 4 * sizeof(int));
//     if(tmp == NULL)
//     {
//         free(list);
//         return 1;
//     }

//     list = tmp;

//     list[3] = 4;


//     for(int i = 0; i < 3; i++)
//     {
//         printf("%i\n", list[i]);
//     }

//     free(list);
//     return 0;
// }


#include <stdio.h>
#include <stdlib.h>

typedef struct node
{
    int number;
    struct node *next;
}
node;

int main(int argc, char *argv[])
{
    node *list = NULL;

    for (int i = 1; i < argc; i++) // use argc to count, how many words are at the prompt and start 1 because the first is the name of my program (./list)
    {
        int x = atoi(argv[i]);

        node *n = malloc(sizeof(node));
        if (n == NULL)
            return 1;

        n->number = x;
        n->next = NULL;

        n->next = list;
        list = n;
    }

    node *ptr = list;
    while(ptr != NULL)
    {
        printf("%i\n", ptr->number);
        ptr = ptr->next; // taking the next number
    }

    // i can do like this to the line below
    /*
    for(node *ptr = list; ptr != NULL; ptr = ptr->next)
    {
        printf("%i\n", ptr->number);
    }
    */

    ptr = list;
    while (ptr != NULL)
    {
        node *next = ptr->next;
        free(ptr);
        ptr = next;
    }
}
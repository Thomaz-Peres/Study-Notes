#include <stdio.h>
#include <stdlib.h>
#define true 1
#define false 0

typedef int bool;
typedef int tipochave;

typedef struct aux {
    tipochave chave;
    struct aux *esq, *dir;
} no;

typedef no* pont;   //  É o ponteiro desta estrutura


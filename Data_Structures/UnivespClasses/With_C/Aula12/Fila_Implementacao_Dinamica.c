#include <stdio.h>
#include <malloc.h>

typedef int tipochave;

typedef struct {
    tipochave chave;
} registro;

typedef struct aux {
    registro reg;
    struct aux* prox;
} elemento, *pont;

typedef struct{
    pont inicio;
    pont fim;
} fila;


//  Inicialização
void inicializarFila(fila* f)
{
    f->inicio = NULL;
    f->fim = NULL;
}


//  Retornar numero de elementos
int retornarElemFila(fila* f)
{
    pont end = f->inicio;
    int tam = 0;
    while(end != NULL)
    {
        tam++;
        end = end->prox;
    }
    return tam;
}


//  Exibição/Impressão
void exibirFila(fila* f)
{
    pont end = f->inicio;
    printf("Fila: \" ");
    while(end != NULL)
    {
        printf("%i ", end->reg.chave);
        end = end->prox;
    }   
    printf("\"\n");
}



//  Inserção de um elemento
/*
    alocamos memoria para o novo elemento
    colocamos após o ultimo elemento atual da fila
    alteramos o valor do campo 'fim'
    verificar se a fila esta vazia, pois se estiver, o inicio tem q apontar para esse elemento novo também
*/

bool inserirElemFila(fila* f, registro* reg)
{
    pont novo = (pont) malloc(sizeof(elemento));
    novo->reg = reg;
    novo->prox = NULL;

    if(f->inicio == NULL) {
        f->inicio = novo;
    } else {
        f->fim->prox = novo;
    }
    f->fim = novo;
    return true;
}



//  Exclusão de um elemento
bool excluirElemFila(fila* f, registro* reg)
{
    if(f->inicio == NULL) return false;

    *reg = f->inicio->reg;
    pont apagar = f->inicio;
    f->inicio = f->inicio->prox;
    free(apagar);

    if(f->inicio == null) f->fim = NULL;

    return true;
}



//  Reinicialização da fila
void reinicializarFila(fila* f)
{
    pont end = f->inicio;

    while(end != NULL)
    {
        pont apagar = end;
        end = end->prox;
        free(apagar);
    }
    f->inicio = NULL;
    f->fim = NULL;
}
#include <stdio.h>
#include <malloc.h>

typedef int bool;
typedef int TIPOCHAVE;

typedef struct
{
    TIPOCHAVE chave;
} REGISTRO;

typedef struct aux
{
    REGISTRO reg;
    struct aux* prox;
    
} ELEMENTO;

typedef ELEMENTO* PONT;

typedef struct
{
    PONT inicio;
} LISTA;


//  Inicialização
//  para iniciarmos  lista ligada dinamica, basta colocar o valor NULL na variavel inicio, indicando que não possui nenhum elemento valido na estrutura

void inicializarLista(LISTA* l)
{
    l->inicio = NULL;
}

//  Retornar numero de elementos
// Para contar os numeros de elementos, por nao ter um numero campos, basta percorrer todos os elementos 

int tamanhoLista(LISTA* l)
{
    PONT end = l->inicio;
    int tam = 0;
    while(end != null)
    {
    tam++;
    end = end->prox;
    }
    return tam;
}


// Exibição/impressão
// segue exatamente a mesma logica de percorrer o tamanho da lista, porém ao inves de somar 1 em uma variavel, a gente vai imprimir

void exibirLista(LISTA* l)
{
    PONT end = l->inicio;

    printf("Lista: \" ");
    
    while(end != NULL)
    {
        printf("%i ", end -> ennd->reg.chave);
        end = end->prox;
    }
    printf("\"\n");
}

// Busca por elemento
// Busca sequencial

PONT buscaSequencial(LISTA* l, TIPOCHAVE ch)
{
    PONT pos = l->inicio;
    while (pos != NULL)
    {
        if(pos->reg.chave == ch) return pos;
        pos = pos->prox;
    }
    return NULL;    
}

PONT buscaSequencialOrd(LISTA* l, TIPOCHAVE ch)
{
    PONT pos = l->inicio;
    while (pos != NULL && pos->reg.chave < ch) pos = pos->prox;
    if(pos != NULL && pos->reg.chave == ch) return pos;

    return NULL;    
}

// inserção de um elemento

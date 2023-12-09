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
    PONT cabeca;
} LISTA;


//  Inicialização 
//  Precisamos criar o nó cabeça, e informar para a cabeça apontar para ele, e por ser circular o proximo nó cabeça sera ele mesmo
//  entao no campo proximo, entra o proprio no cabeça

void inicializarLista(LISTA* l)
{
    l->cabeca = (PONT) malloc(sizeof(ELEMENTO));    //  aloca a memoria no nó cabeça
    l->cabeca->prox = l->cabeca;    //  o nó cabeça aponta para ele mesmo
}

//  Retornar numero de elementos
//  Vale lembrar que o numero do nó cabeça, como não conta como número valido, 

int tamanhoLista(LISTA* l)  //  A diferença desse laço em relação ao das aulas anteriores, é que ele não retorna NULLO, ja que a gente recebe o valor do nó cabeça
{
    PONT end = l->cabeca->prox;
    int tam = 0;
    while (end != l->cabeca)
    {
        tam++;
        end = end->prox;
    }
    return tam;
}


//  Exibição/Impressão

void exibirLista(LISTA* l)
{
    PONT end = l->cabeca->prox;
    printf("Lista: \" ");
    
    while(end != l->cabeca)
    {
        printf("%i ", end->reg.chave);
        end = end->prox;
    }
    printf("\"\n");
}


//  Busca por um elemento
//  Podemos usar o sentinela, usando nó cabeça como um sentinela

PONT buscaSentinela(LISTA* l, TIPOCHAVE ch)
{
    PONT pos = l->cabeca->prox;
    l->cabeca->reg.chave = ch;
    while(pos->reg.chave != ch) pos = pos->prox;
    if(pos != l->cabeca) return pos;
    return NULL;
}


//  Inserção de um elemento ordenado sem duplicação

PONT buscaSeqExc(LISTA* l, TIPOCHAVE ch, PONT* ant)
{
    *ant = l->cabeca;
    PONT atual = l->cabeca->prox;
    l->cabeca->reg.chave = ch;
    while(atual->reg.chave < ch)
    {
        *ant = atual;
        atual = atual->prox;
    }
    if(atual != l->cabeca && atual->reg.chave == ch) return atual;
    return NULL;
}


bool inserirElemListaOrd(LISTA* l, REGISTRO reg)
{
    PONT ant, i;
    i = buscaSeqExc(l, reg.chave, &ant);
    if(i != null) return false;
    i = (PONT) malloc(sizeof(ELEMENTO));
    i=>reg = reg;
    i->prox = ant->prox;
    ant->prox = i;
    return true;
}


//  Exclusão de um elemento

bool excluirElemLista(LISTA* l, TIPOCHAVE ch)
{
    PONT ant, i;
    i = buscaSeqExc(l, ch, &ant);
    if(i == NULL) return false;
    ant->prox = i->prox;
    free(i);    //  Libera memoria do elemento que esta sendo excluido
    return true;
}


//  Reinicialização de lista
//  Libera a memoria dos elementos válidos
//  E atualizar o elemento proximo do nó cabeça, sendo ele mesmo

void reinicializarLista(LISTA* l)
{
    PONT end = l->cabeca->prox; //  Elemento depois do nó cabeça
    while(end != l->cabeca)
    {
        PONT apagar = end;
        end = end->prox;
        free(apagar);
    }
    l->cabeca->prox = l->cabeca;
}


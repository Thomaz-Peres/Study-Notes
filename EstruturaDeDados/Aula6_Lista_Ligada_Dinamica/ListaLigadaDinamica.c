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

//  inserção de um elemento
//  A inserção vai ser  ondenada pelo valor da chave do registro passado e não permitiremos a inserção de elementos repetidos
//  Na inserção precisamos identificar entre quais elementos o novo elemento sera inserido
//  Alocaremos memoria para o novo elemento
//  Precisamos saber quem será o predecessor do elemento


//  NOVA MANEIRA de retorno de elementos na linguagem C
//  Desenvolveremos uma inserção ordenada, como auxiliar, para procurar por uma dada chave e nos informar
//  Como é a simulação de uma busca, a gente precisa do endereço do elemento caso ele exista
//  E do predecessor desse elemento (independente do elemento existir na lista ou não)
//  O PROBLEMA, como a função passa dois endereços diferentes?

PONT buscaSequencialExc(LISTA* l, TIPOCHAVE ch, PONT* ant)
{
    *ant = NULL;
    PONT atual = l->inicio;
    while((atual != NULL) && (atual->reg.chave<ch))
    {
        *ant = atual;
        atual = atual->prox;
    }
    if((atual != NULL) && (atual->reg.chave == ch)) return atual;
    return NULL;
}

bool inserirElemListaOrd(LISTA* l, REGISTRO reg)
{
    TIPOCHAVE ch = reg.chave;
    PONT ant, i;
    i = buscaSequencialExc(l, ch, &ant);
    if(i != NULL) return false; //  se achar um elemento, quer dizer que estou tentando adicionar um elemento igual
    i = (PONT) malloc(sizeof(ELEMENTO));
    i->reg = reg;
    if(ant == NULL)
    {
        i->prox = l->inicio;
        l->inicio = i;
    }
    else
    {
        i->prox = ant->prox;
        ant->prox = i;
    }
    return true;
}


//  Exclusão de um elemento
//  A exclusão também precisa acertar os ponteiros do elemento que esta sendo excluido
//  Liberar a memoria do elemento que foi excluido
//  Precisamos saber o predecessor de quem foi excluido, vai ter que apontar para o proximo dele

bool excluirElemLista(LISTA* l, TIPOCHAVE ch)
{
    PONT ant, i;
    i = buscaSequencialExc(l, ch, &ant);

    if(i == NULL) return false;
    if(ant == NULL) l->inicio = i->prox;
    else ant->prox = i->prox;
    free(i);
    return true;
}


//  Reinicialização da estrutura
//  Zerar a lista, ou seja, precisamos EXCLUIR todos os elementos, e depois apontar para NULL

void reinicializarLista(LISTA* l)
{
    PONT end = l->inicio;
    while(end != NULL)
    {
        PONT apagar = end;
        end = end->prox;
        free(apagar);
    }
    l->inicio = NULL;
}
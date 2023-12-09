#include <stdio.h>
#include <malloc.h>

typedef struct tempNo {
    float valor;
    int coluna;
    struct tempoNo* prox;
} no;

typedef no* pont;

typedef struct {
    pont* a;
    int linhas;
    int colunas;
} matriz;



//  Inicialização
/*
    Acertar o valor dos campos 'linhas' e 'colunas' (isto é, a ordem da matriz passada pelo usuário)
    Precisamos também criar o arranjo de listas ligadas e iniciar cada posição do arranjo
    com valor NULL (indicando que a lista esta vazia)
*/

void inicializarMatriz(matriz* m, int linha, int coluna)
{
    int i;
    m->linhas = linha;
    m->colunas = coluna;
    m->a = (pont*) malloc(lin*sizeof(pont));
    for (i = 0; i < linha; i++) m->a[i] = NULL;
}



//  Atribuir valor 
/*
    é necessario o usuario informar 'linha, coluna e valor' que deseja ser colocado na matriz

    Se nao houver nenhum nó na posição e o valor for diferente de zero
    temos que inserir um novo nó na respectiva lista ligada.
*/


bool atribuirMatriz(matriz* m, int lin, int col, float val)
{
    //  Busca
    if(lin < 0 || lin >= m->linhas || coll < 0 || col >= m->colunas) return false;

    pont ant = NULL;
    pont atual = m->a[lin];

    while (atual != NULL && atual->coluna < col)
    {
        ant = atual;
        atual = atual->prox;
    }

    //  Nó existe

    if (atual != NULL && atual->coluna == col)
    {
        if(val == 0)
        {
            if(ant == NULL) m->a[lin] = atual->prox;
            else ant->prox = atual->prox;
            free(atual);
        } else atual->valor = val;
    }
    else 
    {
        pont novo = (pont) malloc(sizeof(no));
        novo->coluna = col;
        novo->valor = val;
        novo->prox = atual; 

        if(ant == NULL) m->a[lin] = novo;
        else ant->prox = novo;
    }
    return true;
}



//  Acessar o valor

float valorMatriz(matriz* m, int lin, int col)
{
    if(lin < 0 || lin > m->linhas || col < 0 || col >= m->colunas) return 0;

    pont atual = m->a[lin];
    while(atual != NULL && atual->coluna < col)
        atual = atual->prox;

    if(atual != NULL && atual->coluna == col)
        return atual->valor;
    
    return 0;
}
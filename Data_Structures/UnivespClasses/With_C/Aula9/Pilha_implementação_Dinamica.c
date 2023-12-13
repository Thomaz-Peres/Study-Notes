#include <stdio.h>
#include <malloc.h>

typedef int TIPOCHAVE;

typedef struct 
{
    TIPOCHAVE chave;

}REGISTRO;


typedef struct aux{
    REGISTRO reg;
    struct aux* prox;   //  a variavel prox, é um ponteiro para o elemento
}ELEMENTO;

typedef ELEMENTO* PONT;

typedef struct{
    PONT topo;
}PILHA;


//  Inicialização
void inicializarPilha(PILHA* p)
{
    p->topo = NULL;
}


//  Retornar numero de elementos
int tamanhoPilha(PILHA* p)
{
    PONT end = p->topo;
    int tam = 0;

    while(end != null)
    {
        tam++;
        end = end->prox;
    }
    return tam;
}


//  Verificar se a pilha esta vazia
bool pilhaEstaVazia(PILHA* p)
{
    if(p->topo == NULL) return true;
    return false;
}

//  Exibição/Impressão
int exibirPilha(PILHA* p)
{
    PONT end = p->topo;
    
    printf("Pilha: \" ");
    while(end != null)
    {
        printf("%i ", end->reg.chave);
        end = end->prox;
    }
    printf("\"\n");
}



//  Inserção de um elemento na pilha
bool inserirElemPilha(PILHA* p, REGISTRO reg)
{
    PONT novo = (PONT) malloc(sizeof(ELEMENTO));
    novo->reg = reg;
    novo->prox = p->topo;
    p->topo = novo;
    return true;
}


//  Exclusão de um elemento
bool excluirElemPilha(PILHA* p, REGISTRO reg)
{
    if(p->topo == NULL) return false;
    *reg = p->topo->reg;
    PONT apagar = p->topo;
    p->topo = p->topo->prox;
    free(apagar);
    return true;
}



//  Reinicialização
void reinicializarPilha(PILHA* p)
{
    PONT apagar;
    PONT posicao = p->topo;

    while(posicao != NULL)
    {
        apagar = posicao;
        posicao - posicao->prox;
        free(apagar);
    }
    p->topo = NULL;
}
#include <stdio.h>
#define MAX 50

#define true 1
#define false 0
typedef int bool;

typedef int TIPOCHAVE;

typedef struct 
{
    TIPOCHAVE chave;
}REGISTRO;

typedef struct
{
    REGISTRO A[MAX];
    int topo;
}PILHA;


//  Inicialização
//  Por ser estática, então quando eu chamar a variavel pilha, ja é criado um arranjo com o topo
//  so falta escolher um valor para o topo do arranjo da pilha

void inicializarPilha(PILHA* p) //  Iniciamos com -1, como uma pilha inicia vazia, ele precisa iniciar com uma posição atras,
                                //  pro proximo valor no arranjo da pilha, ser no lugar 0
{
    p->topo = -1;
}


//  Retornar numero de elementos
//  Para descobrirmos o numero de elementos na pilha, basta pegarmos o valor do TOPO,
//  Ja que o TOPO, contém a posição no arranjo, so pegar o valor do TOPO + 1
//  e isso vale para quando a pilha for vazia, ja que vou retornar o 0, logo informando que não possui valor

int tamanhoPilha(PILHA* p)
{
    return p->topo + 1;
}


//  Exibição/Impressão
//  Percorre os elementos, e imprimi a chave

void exibirPilha(PILHA* p)
{
    printf("Lista: \" ");
    
    int i;  //  posição que estamos
    for(i = p->topo; i => 0; i--)   //  Começamos pelo topo
    {
        printf("%i ", p->A[i].chave);
    }


    printf("\"\n");
}


//  Inserção de um elemento (push)
//  Insere um elemento no topo da pilha e se tiver espaço

bool inserirElementoPilha(PILHA* p, REGISTRO reg)
{
    if(p->topo => MAX - 1) return false;
    p->topo = p->topo + 1;
    p->A[p->topo] = reg;
    return true;
}


//  Exclusão de um elemento (pop)
//  Solicita a exclusão do elemento do topo da lista

bool excluirElementoPilha(PILHA* p, REGISTRO* reg)
{
    if(p->topo == -1) return false;
    *reg = p->A[p->topo];
    return true;
}


//  Reinicialização da pilha

void reinicializarPilha(PILHA* p)
{
    p->topo = -1;
}
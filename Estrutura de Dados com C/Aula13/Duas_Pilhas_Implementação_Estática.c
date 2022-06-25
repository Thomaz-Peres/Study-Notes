#include <stdio.h>

#define max 50

typedef int tipochave;

typedef struct {
    tipochave chave;
} registro;

typedef struct {
    registro A[max];
    int topo1;
    int topo2;
} pilhadupla;


//  Inicialização
void inicializarPilhaDupla(pilhadupla* p)
{
    p->topo1 = -1;
    p->topo2 = max;
}


//  Retornar numero de elementos
/*
    Podemos utilizar os valores dos campos topo1 e topo2 para calcular o número de elementos
    Na 'pilha1' há topo1 +1 elementos válidos
    Na 'pilha2' há max - topo2 elementos válidos
*/

int tamanhoPilhaDupla(pilhadupla* p)
{
    return p->topo1 + 1 + max - p->topo2;
}


//  Exibição/Impressão
/*
    Para exibir os elementos da estrutura precisaremos iterar pelos elementos válidos e, por exemplo, imprimir suas chaves

    Um dos parametros da função de impressão irá nos dizer qual das pilhas será exibida
*/

bool exibirUmaPila(pilhadupla* p, int pilha)
{
    if(pilha < 1  || pilha > 2 ) return false;

    printf("Pilha %i: \" ", pilha);
    int i;
    
    if (pilha == 1) for (i = p->topo1; i >= 0; i--) printf("%i ", p->A[i].chave);
    else for (i = p->topo2; i < max; i++) printf("%i ", p->A[i].chave);

    printf("\"\n");
    return true;
}



//  Inserção de um elemento (push)
/*  
    O usuario passa como parametro um registro a ser inserido na pilha e diz em qual pilha deseja inserir
*/


bool inserirElemPilha(pilhadupla* p, registro reg, int pilha)
{
    if(pilha < 1 || pilha > 2) return false;
    if(p->topo1 + 1 == p->topo2) return false;

    if(pilha == 1){
        p->topo1 = p->topo1+1;
        p->A[p->topo1] = reg;
    } else {
        p->topo2 = p->topo2-1;
        p->A[p->topo2] = reg;
    }
    return true;
}



//Exclusão de um elemento (pop)

bool excluirElementoPilha(pilhadupla* p, registro* reg, int pilha)
{
    if(pilha < 1 || pilha > 2) return false;
    if(pilha == 1)
    {
        if(p->topo1 == -1) return false;
        *reg = p.A[p.topo1];
        p.topo1 = p.topo1 - 1;
    } else {
        if(p->topo2 == max) return false;
        *reg = p.A[p.topo2];
        p.topo2 = p.topo2 + 1;
    }
    return true;
}



//  Reinicialização da pilha

void reinicializarPilha(pilhadupla* p)
{
    inicializarPilhaDupla(p);
}
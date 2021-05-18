#include <stdio.h>

#define max 50

typedef int bool;
typedef int tipochave;

typedef struct {
    tipochave chave;
} registro;

typedef struct{
    registro A[max];
    int inicio;
    int nroElem;
} fila;



//  Inicializando a estrutura

void inicializarFila(fila* f)
{
    f->inicio = 0;
    f->nroElem = 0;
    //  exemplo depois de rodar o codigo para inicializar a fila (https://user-images.githubusercontent.com/58439854/118710405-9d116c00-b7f4-11eb-9dbc-e5e45a9875a6.png)
}


//  Retornar numero de elementos
int tamanhoFila(fila* f)
{
    return f->nroElem;
}


//  Exibição/impressão
//  criamos um laço começando do inicio e terminando no fim
void exibirFila(fila* f)
{
    printf("Fila: \" ");
    int i = f->inicio;
    int temp;
    for(temp = 0; temp < f->nroElem; temp++)
    {
        printf("%i ", f->A[i].chave);
        i = (i + 1) % max;  //  se o 'i' passar do valor da ultima posição do arranjo, ele volta para o inicio
    }    
    printf("\"\n");
}



//  Inserção de um elemento
/*
    O usuario passa como parametro o elemento a ser inserido
    identificar a posição no arranjo na qual o registro sera inserido
    e por fim somar em 1 o numero de elementos
*/
bool inserirElemFila(fila* f, registro* reg)
{
    if(f->nroElem >= max) return false; //  verifica se a fila esta cheia

    int posicao = (f->inicio + f->nroElem) % max;
    f->A[posicao] = reg;
    f->nroElem++;
    return true;
}


//  Exclusão de um elemento
/*
    Acertar o valor do campo de numero de elementos na fila
    acertar o valor do campo de inicio
*/
bool excluirElemFila(fila* f, registro* reg)
{
    if(f->nroElem == 0) return false;
    
    *reg = f->A[f->inicio];
    f->inicio = (f->inicio+1) % max;
    f->nroElem--;
    return true;
}


//  Reinicializar fila estatica

void reinicializarFila(fila* f)
{
    f->inicio = 0;
    f->nroElem = 0;

    //  ou

    //  inicializarFila(f);
}
#include <stdio.h>
#include <malloc.h>

typedef int tipochave;

typedef struct {
    tipochave chave;

} registro;

typedef struct auxElem {
    registro reg;
    struct auxElem* ant;
    struct auxElem* prox;
} elemento;

typedef elemento* pont;

typedef struct {
    pont cabeca;
} deque;

//  Inicialização
//  (imagem de representação do que o codigo abaixo faz = https://user-images.githubusercontent.com/58439854/118703818-e362cd00-b7ec-11eb-9b4d-41e965e921fe.png)
/*  Criar o nó cabeça
    a variavel "cabeca" precisa apontar para o nó cabeça
    o nó cabeça apontara para ele mesmo como anterior e proximo
*/
void inicializarDeque(deque* d)
{
    d->cabeca = (pont) malloc(sizeof(elemento));
    d->cabeca->prox = d->cabeca;
    d->cabeca->ant = d->cabeca;
}


//  Retornar numero de elementos
/*
    como é uma estrutura circular, nao contamos ate achar um valor null, mas sim ate acharmos o nó cabeça
    começamos do elemento depois do nó cabeça
    e contamos ate o ultimo elemento antes do nó cabeça
*/
int tamanhoDeque(deque* d)  //  retornar do inicio para o fim
{
    pont end = d->cabeca->prox;
    int tam = 0;

    while(end != d->cabeca) //  Enquanto o elemento não voltar para o nó cabeça, estamos percorrendo elementos validos
    {
        tam++;
        end = end->prox;
    }
    return tam;
}

int tamanhoDeque2(deque* d)  //  retornar do fim para o inicio
{
    pont end = d->cabeca->ant;
    int tam = 0;

    while(end != d->cabeca) //  Enquanto o elemento não voltar para o nó cabeça, estamos percorrendo elementos validos
    {
        tam++;
        end = end->ant;
    }
    return tam;
}


//  Exibição/impressão
//  Também pode ser feita do inicio para o fim ou vice-versa
void exibirDeque(deque* d)
{
    pont end = d->cabeca->ant;
    printf("Deque partindo do fim: \" ");
    while(end != d->cabeca){
        printf("%i ", end->reg.chave);
        end = end->ant;
    }
    printf("\"\n");
}


//  Inserção de um elemento
/*  Também pode ser feita do inicio para o fim ou vice-versa
    A pessoa escolhe a função que insere no inicio ou no fim,
    e passa como parametro o registro a ser inserido.
    e por fim arrumar os ponteiros
*/
bool inserirDequeFim(deque* d, registro reg)
{
    //  um deque antes de rodar o codigo(https://user-images.githubusercontent.com/58439854/118706924-4efa6980-b7f0-11eb-9c34-7f660d95f063.png)

    pont novo = (pont) malloc(sizeof(elemento));

    novo->reg = reg;
    novo->prox = d->cabeca;
    novo->ant = d->cabeca->ant;
    d->cabeca->ant = novo;
    novo->ant->prox = novo;
    return true;

    // depois do codigo  (https://user-images.githubusercontent.com/58439854/118707296-b9aba500-b7f0-11eb-9428-7588b2de141c.png)
}


//  Exclusão de um elemento
/*  Também pode ser feita do inicio para o fim ou vice-versa
    A pessoa escolhe a função que exclui no inicio ou no fim,
    e passa como parametro o registro a ser excluido.
    o elemento excluido tem sua memoria limpa
    e por fim arrumar os ponteiros
*/
bool excluirDequeInicio(deque* d, registro* reg)
{
    if(d->cabeca->prox == d->cabeca) return false;

    pont apagar = d->cabeca->prox;
    *reg = apagar->reg;
    d->cabeca->prox = apagar->prox;
    apagar->prox->ant = d->cabeca;
    free(apagar);
    return true;
}


//  Reinicialização do deque
/*
    Não é necessario excluir o nó cabeça, apenas arrumar os ponteiros e apontar a cabeça no nó cabeça
*/
void reinicializarDeque(deque* d)
{
    pont end = d->cabeca->prox;
    while(end != d->cabeca)
    {
        pont apagar = end;
        end = end->prox;
        free (apagar);
    }
    d->cabeca->prox = d->cabeca;
    d->cabeca->ant = d->cabeca;
}
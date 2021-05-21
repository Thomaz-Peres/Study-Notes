#include <stdio.h>
#include <stdlib.h>
#define true 1
#define false 0

typedef int bool;
typedef int tipochave;

typedef struct aux {
    tipochave chave;
    struct aux *esq, *dir;
} no;

typedef no* pont;   //  É o ponteiro desta estrutura


//  Inicialização de um árvore
/*  
    Para inicializarmos esta árvore, basta iniciarmos o nó raiz como NULL
*/

pont inicializa()
{
    return NULL();
}

int main(){
    pont r = inicializa();

    pont no = criaNovoNo(23);
    r = adicionar(r, no);
}


//  Inserção
/*
    Vamos supor que nao é permitido duplicação de chaves
        Caso permitamos (o que não vai ser o caso dessa aula), basta definir uma politica, por exemplo
            chaves < à de um determinado nó, ficam na subárvore à esquerda deste.

    Imagem de exemplo de como funciona a inserção na arvore binaria(https://user-images.githubusercontent.com/58439854/119197258-d4cf1c80-ba5d-11eb-8004-63b33b71af5d.png)    
*/

pont adiciona(pont raiz, pont no)
{
    if(raiz == null) return(no);
    if(no->chave < raiz->chave)
    {
        raiz->esq = adiciona(raiz->esq, no)
    }
    else {
        raiz->dir = adiciona(raiz->dir, no);
    }
    //  ignoro chave igual
    return (raiz);
}

pont criaNovoNo(tipochave ch) {
    pont novoNo = (pont) malloc(sizeof(no));
    novoNo->esq = NULL;
    novoNo->dir = NULL;
    novoNo->chave = ch;
    return (novoNo);
}
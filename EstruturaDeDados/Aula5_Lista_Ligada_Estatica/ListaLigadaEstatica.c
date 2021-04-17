#define MAX 50
#define INVALIDO -1

/** Dentro desse codigo temos uma diferença perto da aula3
 * Temos um arranjo de elementos ( o elemento é a informação em si, o elemento util para o usuario) e a informação do proximo elemento
 * 
 * E agora no arranjo de LISTA, nos temos o proprio ELEMENTO, e depois o inicio = para sabermos o primeiro elemento valido,
 * E dispo = para saber o primeiro elemento disponivel.
 * Imagem de exemplo = https://user-images.githubusercontent.com/58439854/115046028-679ff880-9ead-11eb-963b-1446e32df552.png
**/ 

typedef int TIPOCHAVE;

typedef struct
{
    TIPOCHAVE chave;
} REGISTRO;

typedef struct 
{
    REGISTRO reg;
    int prox;
} ELEMENTO;

typedef struct
{
    ELEMENTO A[MAX];
    int inicio;
    int dispo;
} LISTA;


void inicializarLista(LISTA* l)
{
    int i;
    for( i = 0; i<MAX-1; i++)
        l->A[i].prox = i + 1;

    l -> A[MAX].prox = INVALIDO;
    l -> inicio = INVALIDO;
    l -> dispo = 0;

    // image de exemplo = https://user-images.githubusercontent.com/58439854/115046983-73d88580-9eae-11eb-8036-7feff5909dd7.png
}

// para o retorno, iremos fazer diferente, como nao optamos por nao criar um campo com o numero de elementos
// precisamos percorrer todos os elementos válidos para contar quantos tem.

int tamanho(LISTA* l)
{
    int i = l -> inicio;
    int tam = 0;
    while( i != INVALIDO)
    {
        tam++;
        i = l -> A[i].prox;
    }
    return tam;
}

void exibitLisTA(LISTA* l){
    int i =l->inicio;
    printf("Lista: \" ");
    
    while( i != INVALIDO)
    {
        printf("%i ", l -> A[i].reg.chave);
        i = l->A[i].prox;
    }
    printf("\"\n");
}

int buscaSequencialOrd(LISTA* l, TIPOCHAVE ch)
{
    int i = l->inicio;
                            // enquanto a chave for menor que a chave que eu passei, continuo indo para o proximo elemento
    while(i != INVALIDO && l-> A[i].reg.chave < ch)
    {
        i = l->A[i].prox;
    }
    if(i != INVALIDO && l->A[i].reg.chave == ch)
    return i;
    else return INVALIDO;
}

// Na inserção precisamos identificar entre quais elementos o novo elementos sera inserido
// O novo elemento será inserido no primeiro lugar que estiver disponivel na lista
// segue uma imagem de exemplo, ja que aqui nao é arquivo MARKDOWN fica dificil fazer bonitin = https://user-images.githubusercontent.com/58439854/115049327-fbbf8f00-9eb0-11eb-853e-ae8244bf6ce2.png

// Nesta inserção faremos uma coisa de cada vez, começando por uma função auxiliar
// A função auxiliar retira o primeiro elemento da lista de disponiveis e retorna sua posição no arranjo

int obterNo(LISTA* l)
{
    int resultado = l->dispo;   // guarda a posição do primeiro elemento disponivel
    if(l->dispo != INVALIDO)    // se o elemento disponivel for valido
        l->dispo = l->A[l->dispo].prox; // o proximo elemento entra como o disponivel
    return resultado;
}

bool inserirElemListaOrd(LISTA* l, REGISTRO reg)
{
    if(l-> dispo == INVALIDO) return false; // se disponive for invalido, a lista esta cheia e nao tem empaço, logo retorna falso e nao faz a inserção
    int ant = INVALIDO;
    int i = l-> dispo;
    TIPOCHAVE ch = reg.chave;
    while ((i != INVALIDO) && (l->A[i].reg.chave < ch))
    {
        ant = i;
        i = l->A[i].prox;
    }
    if(i != INVALIDO && l-> A[i].reg.chave == ch) return prox;

    i=obterNo(l);
    l->A[i].reg = reg;

    if(ant == INVALIDO) //  se ant nao tiver numero anterior, ele sera o primeiro
    {
        l->A[i].prox = l->inicio;   //  o proximo elemento inserido, sera o primeiro
        l->inicio = i;
    }
    else    //  se eu tiver um numero anterior
    {
        l->A[i].prox = l->A[ant].prox;  //  se eu tinha um elemento antes de mim, vou adicionar um elemento como proximo do meu antecessor
        l->A[ant].prox = i;
    }
    return true;    
}

// a exclusão funciona quase igual a inserção, a diferença é q faz a procura do elemento
// se não existir ,ao da para excluir(obviamente). se existir, exclui o elemento, e adiciona o elemento na lista de disponiveis
// e acertar o "ponteiro", quem apontava para o elemento que esta sendo excluido, vai apontar para o proximo

// função auxiliar para exclusão de um elemento
// a lista de disponiveis nao precisa ficar ordenada pela chave, ja que são elementos invalidos
// então é inserido na posição que é mais facil inserir: no inicio

void devolverNo(LISTA* l, int j)
{
    l->A[j].prox = l->dispo;
    l->dispo = j;
}

bool excluirElemLista(LISTA* l, TIPOCHAVE ch)
{
    int ant = INVALIDO;
    int i = l->inicio;
    while((i != INVALIDO) && (l->A[i].reg.chave < ch))
    {
        ant = i;
        i = l->A[i].prox;
    }
    if(i == INVALIDO || l->A[i].reg.chave != ch) return false;  //  se o elemento nao existe, nao da para excluir
    if(ant == INVALIDO) l->inicio = l->A[i].prox;   //  se o elemento excluido nao tem anterior, o inicio apontava para ele, e agora aponta para o proximo
    else l->A[ant].prox = l->A[i].prox;             // se eu tiver anterior, eu vou apontar para o anterior, e o anterior tem q apontar para o proximo dele
    devolverNo(l, i);   //  devolver o No que foi excluido para a lista de disponiveis
    return true;
}


// Reinicialização da lista

void reiniciarLista(LISTA* l)
{
    inicializarLista(l);
}
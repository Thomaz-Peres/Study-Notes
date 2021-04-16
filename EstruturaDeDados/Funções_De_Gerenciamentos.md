# Funções de Gerenciamento

- Implementaremos funções para:
    - Inicializar a Estrutura
    - Retornar a quantidade de elementos válidos
    - Exibir os elementos da estrutura
    - Buscar por um elemento na estrutura
    - Inserir elementos na estrutura
    - Excluir elementos da estrutura
    - Reinicializar a estrutura (quando terminamos de utiliza-la, mas queremos reutiliza-la para um novo conjunto de elementos)


## Inicialização

Para inicializar uma estrutura qualquer, precisamos pensar nos valores adequados para cada um dos campos de nossa estrutura.

```C
void inicializarLista(LISTA l)
{
    l.nroElem = 0;
}

Qual a diferença entre o codigo acima e o abaixo ?

void inicializarLista(LISTA* l)
{
    l->nroElem = 0;
}
```

## Retornar número de elementos

```C
int tamanho(LISTA* l)
{
    return l->nroElem = 0;
}
```

## Exibir/Impressão

```C
void exibirLista(LISTA* l)
{
    int i;
    printf("Lista: \" ");
    for(i=0; i< l->nroElem; i++)
        printf("%i", l->A[i].chave)

    printf("\"\n");
}
```
## Buscar por um elemento

A função de busca devera:
    - Receber uma chave do usuario
    - Retornar a posição em que este elemento se encontra na lista (caso seja encontrado)
    - Retornar -1 caso não haja um registro com essa chave na lista

```C
int buscaSequencial(LISTA* l, TIPOCHAVE ch)
{
    int i = 0;
    while (i < l->nroElem)
    {
        if(ch == l->A[i].chave) return i;
        else i++;
    }
    return -1;
}
```

## Inserção de um elemento

O usuario passa como parâmetro um registro a ser inserido na lista
Há diferentes possibilidades de inserção:
    - No inicio
    - No fim
    - Ordenada pela chave
    - Em uma posição indicada pel usuario

```C
bool inserirElemLista(LISTA* l, REGISTRO reg, int i)
{
    int j;
    if((l->nroElem == MAX) || (i < 0) || (i > l->nroElem))
        return false;

    for (j = l->nroElem; j> i; j--) l->A[j] = l->A[j -1];
    l-> A[i] = reg;
    l->nroElem++;
    return true;
}
```

## Exclusão de um elemento

O usuario passa a chave do elemento que ele deseja excluir, e ele fará uma busca para saber se o elemento existe na lista, para poder exclui-lo

```C
bool excluirElemLista(TIPOCHAVE ch, LISTA* l)
{
    int pos, j;
    pos = buscaSequencial(l, ch);
    if(pos == -1) return false;
    for( j= pos; j < l-> nroElem - 1; j++)
        l-> A[j] = l->A[j+1];
    l->nroelem--;
    return true;
}
```

## Reinicialização da Lista

Reinicializar a estrutura = deixar a estrutura pronta para ser utilizada novamente, sem conter nenhum elemento

```C
void reinicializarLista(LISTA* l)
{
    l->nroElem = 0;
}
```
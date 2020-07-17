## deixe o FOR padrão é bom para fazer atribuição ou inicialização

## o foreach serve para interar os elementos de uma coleçao, voce nao atribui valor aos elementos da coleção, ele lê os elementos da coleção

# O FOREACH é um nucleo proprio para interar e fazer leitura de elementos de uma coleção. Por isso ele é mais simples tanto na forma de utilização e de executação

## o FOREACH é recomendado quando for fazer leitura e interação dos elementos.

1. uma variavel que recebe um elemento da coleçao, e ela precisa ser do mesmo tipo da coleçao


# deixe para fazer a leitura dos elementos dentro da coleçao

#### int[] num = new int[3] {11, 22, 33};

foreach (int n in num)
    {
        Console.WriteLine(n);
    }

2. Acima o N é a variavel que recebe a coleção NUM.
    - ele le o N, passa para a segunda coleçao do num, e assim por diante.

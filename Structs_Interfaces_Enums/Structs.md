# Structs

Como as classes, as structs são estruturas de dados que podem conter membros de dados e membros de ação, mas, diferentemente das classes, as structs são tipos de valor e não requerem alocação de heap.

Uma variavel de um tipo de struct armazena diretamente os dados da estrutura, enquanto uma variavel de um tipo de classe armazena uma referencia a um objeto alocado na memoria.

Structs não aceitam herança determinada pelo desenvolvedor. (a ideia da struct é ter uma estrutura mais simples)

São uteis para pequenas estruturas de dados que possuem semântica de valor: números complexos, que pontos em um sistema de coordenadas ou pares de chave-valor em um dicionário são bons exemplos de utilização.

O uso de structs em vez de classes para pequenas estruturas de dados pode fazer uma grande diferença no número de alocações de memória.

## Exemplos de structs

```Csharp
public struct Ponto
{
    public int x, y;
    public Ponto(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
```

Construtores de structs são chamados com o operador *new*, semelhante a um contrutor de classe, mas em vez de alocar dinamicamente um objeto no *heap* gerenciado e retornar uma referência a ele, um contrutor struct simplesmente retorna o proprio valor struct (normalmente em um local temporario no stack), e esse valor é copiado conforme necessário.
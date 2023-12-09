# Enums ou enumerador

Um enum é um tipo de valor distinto com um conjunto de constantes nomeadas.

Você define enumerações quando precisa definir um tipo que pode ter um conjunto de valores discretos.
Eles usam um dos tipos de valor integral como armazenamento subjacente. Eles fornecem significado semântico aos valores discretos.

**Exemplos**:

```Csharp
enum Cor
{
    Vermelho,
    Verde,
    Azul
}

static void EscreverCor(Cor cor)
{
    switch (cor)
    {
        case Cor.Vermelho:
            Console.WriteLine("Vermelho);
            break;
        case Cor.Verde:
            Console.WriteLine("Vermelho);
            break;
    }
}
```

Cada tipo de enum possui um tipo integral correspondente chamado tipo subjacente do tipo de enum.

Um tipo de enumeração que não declara explicitamente um tipo subjacente tem um tipo subjacente int.

**Exemplo**: Se nao informar que é um *: sbyte*, é um int automaticamente.
```Csharp
enum Alinhamento : sbyte
{
    Esquerda = -1,
    Centro = 0,
    Direita = 1
}
```
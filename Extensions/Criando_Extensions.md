# Como funciona a criação de um extension methods, e algumas praticas

## Segue um codigo abaixo para ver como é uma extension.

```CSharp
namespace ExtensionMethods
{
    public static class MyExtension
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ','.', '?'},
            StringSplitOptions.RemoveEmptyEntries).Lenght;
        }
    }
}
```

## Explicando o codigo Acima

No codigo acima, em ```WordCount(this String str)```, utilizamos o ***this String str*** pois no método de extensão é obrigatorio para o compilador entender que, este metodo é uma extensão de string, ele faz parte dos objetos/métodos de string, sempre que eu chamar uma ```string.``` depois do ```ponto final``` essa extensão vai aparecer.
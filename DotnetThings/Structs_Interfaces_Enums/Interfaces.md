# Interfaces

Uma interface define um contrato que pode ser implementado por classes e structs

Uma interface pode conter métodos, propriedades, eventos e indexadores.

Uma interface não fornece implementações dos membros que define - apenas suas "assinaturas"

**Exemplo de assinatura**: explica qual o tipo do metodo, se ele é INT, VOID, vai receber tal nome, e tem que receber tais *parametros*. Quem herdar essa interface ou implementar, tera que obrigatoriamente tem que ter aquele metodo sendo implementado.

As interfaces podem empregar herança múltipla.

# Exemplos de interfaces

```Csharp
interface IControl
{
    void Paint();
}
interface IListBox
{
    void SetText(string text);
}
interface IComboBox : ITextBox, IListBox { }
//  A interface IComboBox herdara IListBox e ITextBox, sendo "forçada" a utilizar o void Paint() e o void SetText

interface IDataBound
{
    void Bind(Binder b);
}
public class EditBox : IComboBox, IDataBound
// ao herdar as duas interfaces, tera que ter todos os metodos
{
    public void Paint() { }
    public void SetText(string text) { }
    public void Bind(Binder b) { }
}
```
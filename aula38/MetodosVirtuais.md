## Metodo virtuais sao metodos que tem o mesmo nome, em classes diferentes, sao classes que herdam outras. e tem um metodo que tem exatamente o nome da mesma classe BASE. Porem ele executa uma ação diferente.

# resumidamente, virtual é um metodo para ser SOBREESCRITO e nao é necessario definições, apenas a assinatura.

### O metodo virtual diz que pode ser sobreescrito
### e para sobreescrever o metodo, é necessario utilizar a palavra OVERRIDE
## exemplo abaixo.

class Base
{
    virtual public void Info()
    {
        Console.WriteLine("Base");
    }
}
class Derivada1 : Base
{
    override public void Info()
    {
        Console.WriteLine("Derivada1");
    }
}
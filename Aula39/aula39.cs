using System;

abstract class Veiculo
{
    protected int velMaxima;
    protected int velAtual;
    protected bool ligado;

    public Veiculo()
    {
        ligado = false;
        velAtual = 0;
    }
    public void setLigado(bool ligado)
    {
        this.ligado = ligado;
    }

    public int getVelAtual()
    {
        return velAtual;
    }

    abstract public void Aceleracao(int multi);
}

class Carro : Veiculo
{
    public Carro()
    {
        velMaxima = 120;
    }
    override public void Aceleracao(int multi)
    {
        velAtual += 10 * multi;
    }
}


class Aula39
{
    static void Main()
    {
        Carro carro1 = new Carro();

        carro1.Aceleracao(5);

        Console.WriteLine(carro1.getVelAtual());
    }
}
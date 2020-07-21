using System;

class Veiculo
{
    public int velAtual;
    private int velMax;
    protected bool ligado;

    public Veiculo(int velMax)
    {
        velAtual = 0;
        this.velMax = velMax;
        ligado = false;
    }
    public bool getLigado() 
    {
        return ligado;
    }
    public int getVelMax()
    {
        return velMax;
    }
}

class Carro : Veiculo   //   derivada de veiculo
{
    public string nome;
    public Carro(string nome, int vm) : base(vm)
    {
        this.nome = nome;
        ligado = true;
    }
}

class Aula36
{
    static void Main()
    {
        Carro carro = new Carro("Bonitao", 120);

        Console.WriteLine("Nome: {0}", carro.nome);
        Console.WriteLine("Vel.Maxima: {0}", carro.getVelMax());
        Console.WriteLine("Vel.Maxima: {0}", carro.getLigado());
    }
}
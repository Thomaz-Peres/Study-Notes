using System;

class Veiculo   // Classe base
{
    private int rodas;
    //public int velMax;
    private bool ligado;

    public Veiculo(int rodas)
    {
        this.rodas = rodas;
    }
    public void Ligar()
    {
        ligado = true;
    }

    public void Desligar()
    {
        ligado = false;
    }

    public string GetLigado()
    {
        return (ligado? "sim":"não");
    }
    public int getRodas()
    {
        return rodas;
    }
}

class Carro : Veiculo    // classe derivada.
{
    public string nome;
    public string cor;
    public Carro(string nome, string cor): base(4)
    {
        Desligar();
        velMax = 120;
        this.nome = nome;
        this.cor = cor;
    }
}

class Aula35
{
    static void Main()
    {
        Carro c1 = new Carro("Rapidao", "Vermelho");

        Console.WriteLine("Cor: {0}", c1.cor);
        Console.WriteLine("Nome: {0}", c1.nome);
        Console.WriteLine("Rodas: {0}", c1.getRodas());
        Console.WriteLine("Vel.Maxima: {0}", c1.velMax);
        Console.WriteLine("Ligado: {0}", c1.GetLigado());
    }
}
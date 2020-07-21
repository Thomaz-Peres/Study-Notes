using System;

class Veiculo   // Classe base
{
    public int rodas;
    //public int velMax;
    private bool ligado;

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
        if (ligado)
        {
            return "sim";
        } else {
            return "nao";
        }
    }
}

class Carro: Veiculo    // classe derivada.
{
    public string nome;
    public string cor;
    public Carro(string nome, string cor)
    {
        Desligar();
        rodas = 4;
        velMax = 120;
        this.nome = nome;
        this.cor = cor;
    }
}

class Aula34
{
    static void Main()
    {
        Carro c1 = new Carro("Rapidao", "Vermelho");

        Console.WriteLine("Cor: {0}", c1.cor);
        Console.WriteLine("Nome: {0}", c1.nome);
        Console.WriteLine("Rodas: {0}", c1.rodas);
        Console.WriteLine("Vel.Maxima: {0}", c1.velMax);
        Console.WriteLine("Ligado: {0}", c1.GetLigado());
    }
}
using System;


public class Jogador
{
    public int energia;
    public bool vivo;
    public string nome;

    public Jogador(string n)
    {
        energia = 100;
        vivo = true;
        nome = n;
    }
    ~Jogador()
    {
        Console.WriteLine("Jogador foi destruido");
    }
}

class Aula29
{
    static void Main()
    {
        string nome1;
        Console.WriteLine("Digite o nome do jogaodor");
        nome1 = Console.ReadLine();
        Jogador j1 = new Jogador(nome1);
        Jogador j2 = new Jogador("Alice");
        j1.energia = 0;

        Console.WriteLine("Nome do jogador 1: {0} e ele esta {1}", j1.nome, j1.vivo);
        Console.WriteLine("Nome do jogador 2: {0} e ele esta {1}", j2.nome, j2.vivo);
    }
}
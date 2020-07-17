using System;

static public class Jogador
{
    static public int energia;
    static public bool vivo;
    static public string nome;
    static public void Iniciar(string n)
    {
        energia = 100;
        vivo = true;
        nome = n;
    }
    static public void info()
    {
        Console.WriteLine("nome jogador: {0}", nome);
        Console.WriteLine("Energia jogador: {0}", energia);
        Console.WriteLine("Estado do jogador: {0}\n", vivo);
    }
}

class Inimigo
{
    public bool alerta;
    static public string nome;
    public Inimigo(string n)
    {
        alerta = false;
        nome = n;
    }
    public void info()
    {
        Console.WriteLine(nome);
        Console.WriteLine(alerta);
        Console.WriteLine("-------------------------");
    }
}


class Aula31
{
    static void Main()
    {
        Jogador.Iniciar("Thomaz");
        Jogador.info();

        Inimigo i1 = new Inimigo("doido");
        Inimigo i2 = new Inimigo("Maluco");
        Inimigo i3 = new Inimigo("Pirado");

        Inimigo.nome= ("Pelé");

        i1.info();
        i2.info();
        i3.info();
    }
}
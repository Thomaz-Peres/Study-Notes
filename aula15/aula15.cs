using System;

class Aula15
{
    static void Main()
    {
        string SuaEscolha;
        char escolha;

        Console.WriteLine("Escolha S para pedra, T para tesoura ou P para papel");
        Console.WriteLine("Faça suas escolhas: [s]Pedra | [t]tesoura | [p]papel");

        escolha = char.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 's':
                SuaEscolha = "Pedra";
                break;
            case 't':
                SuaEscolha = "Tesoura";
                break;
            case 'p':
                SuaEscolha = "Papel";
                break;
            default:
                SuaEscolha = "Burro para caralho";
                break;
        }

        if (SuaEscolha == "Pedra")
        {
            Console.WriteLine("Sua escolha foi pedra");
        }
        else if (SuaEscolha == "Papel")
        {
            Console.WriteLine("Sua escolha foi papel");
        }
        else if (SuaEscolha == "Tesoura")
        {
            Console.WriteLine("Sua escolha foi tesoura");
        }
        else
        {
            Console.WriteLine("Para de ser burro irmao");
        }
    }
}


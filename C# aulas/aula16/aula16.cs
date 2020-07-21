using System;

class Aula16
{
    static void Main()
    {
        string SuaEscolha;
        char escolha;

        inicio:

        Console.Clear();

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
        } else 
        {
            Console.WriteLine("Para de ser burro irmao");
        }

        Console.Write("\nCalcular outro transporte? [s/n]");
        escolha = char.Parse(Console.ReadLine());

        if(escolha == 's' || escolha == 'S')
        {
            goto inicio;
        }
        if(escolha == 'n' || escolha == 'N')
        {
            Console.Clear();
            Console.WriteLine("Fim do programa");
        }
    }
}


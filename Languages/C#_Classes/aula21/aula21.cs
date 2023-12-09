using System;

class Aula21
{
    static void Main()
    {
        string senha = "123";
        string nome = "Thomaz";

        string senhaUser, nomeUser;

        int tentativas = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("Digite a senha");
            senhaUser = Console.ReadLine();
            Console.WriteLine("Digite o nome");
            nomeUser = Console.ReadLine();
            tentativas++;
        } while ((nome != nomeUser) & (senha != senhaUser));

        Console.Clear();
        Console.WriteLine("Senha correta e nome corretos, tentativas: {0}", tentativas);
    }
}
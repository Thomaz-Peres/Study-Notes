## sitaxe do Do While tambem é diferente

1. Começa com o DO e termina com o WHILE

## o for padrão é bom para fazer atribuição ou inicialização

## Com o do while eu garanto que pelomenos 1 vez os comandos serão executados.

2. O do ele executa o comando, e no final ele testa.

# sintaxe do DO WHILE
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
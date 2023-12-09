using System;

class Testes
{
    static void Main()
    {
        int[] numeroSorte = new int[5];
        int procurando;

        Console.WriteLine("Tente acertar o numero: \n\n");

        Random random = new Random();
        for (int i = 0; i < numeroSorte.Length; i++)
        {
            numeroSorte[i] = random.Next(100);
        }

        Console.WriteLine("Elementos do numero da sorte: ");
        foreach (int n in numeroSorte)
        {
            Console.WriteLine(n);
        }

        Console.Write("Digite o numero esperado: ");
        procurando = int.Parse(Console.ReadLine());

        int posicao = Array.BinarySearch(numeroSorte, procurando);
        Console.WriteLine("Valor {0} está na posição: {1}", procurando, posicao);

    }
}
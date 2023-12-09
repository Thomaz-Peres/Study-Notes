using System;

class Primo
{
    static void Main()
    {
        int numero;

        Console.WriteLine("Escreva um numero e lhe direi se é primo ou nao");
        numero = Convert.ToInt32(Console.ReadLine());

        if (numero % 2 == 0)
        {
            Console.WriteLine("Esse numero é primo");
        } else 
        {
            Console.WriteLine("Esse numero não é primo");
        }
    }
}
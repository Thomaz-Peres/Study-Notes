using System;

class _1010
{

    static void Main(string[] args)
    {

        string[] peca1 = Console.ReadLine().Split(' ');
        int codigo1 = int.Parse(peca1[0]);
        int numero1 = int.Parse(peca1[1]);
        double valor1 = double.Parse(peca1[2]);

        string[] peca2 = Console.ReadLine().Split(' ');
        int codigo2 = int.Parse(peca2[0]);
        int numero2 = int.Parse(peca2[1]);
        double valor2 = double.Parse(peca2[2]);

        double total = (numero1 * valor1) + (numero2 * valor2);


        Console.WriteLine("VALOR A PAGAR: R$ {0:0.00}", total);

    }

}
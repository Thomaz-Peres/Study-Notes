using System;

class _1018
{
    static void Main(string[] args)
    {
        int valor;
        int[] lista = { 100, 50, 20, 10, 5, 2, 1 };

        valor = int.Parse(Console.ReadLine());
        Console.WriteLine(valor);
        for (int i = 0; i < lista.Length; i++)
        {
            int cedulas = lista[i];
            int quantCedulas = valor / cedulas;
            valor %= cedulas;
            Console.WriteLine(quantCedulas + " nota(s) de R$ " + cedulas + ",00");
        }
    }
}
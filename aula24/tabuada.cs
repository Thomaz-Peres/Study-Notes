using System;

class Tabuada
{
    static void Main()
    {
        Multiplicador();
    }

    static void Multiplicador()
    {
        int numero;
        int contador = 0;
        Console.WriteLine("Escreva um numero e veja sua tabuada de 1..10");
        numero = Convert.ToInt32(Console.ReadLine());

        while (contador < 11)
        {
            Console.WriteLine(numero + " * " + contador + " = " + numero * contador);
            contador++;
        }
    }
}
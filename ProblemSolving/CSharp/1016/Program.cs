using System;

class _1016
{
    static void Main(string[] args)
    {
        int distancia = int.Parse(Console.ReadLine());
        int tempo = ((60 * distancia) / 30);

        Console.WriteLine($"{tempo} minutos");
    }
}
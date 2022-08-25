using System;

class _1019
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        
        var horas = N/3600;
        var minutos = N % 3600 / 60;
        var segundos = N % 60;
        
        Console.WriteLine(horas + ":" + minutos + ":" + segundos);
    }
}
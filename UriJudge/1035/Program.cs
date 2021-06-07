using System;

class _1035
{
    static void Main(string[] args)
    {
        string[] lista = Console.ReadLine().Split(' ');
        int A = int.Parse(lista[0]);
        int B = int.Parse(lista[1]);
        int C = int.Parse(lista[2]);
        int D = int.Parse(lista[3]);
        
        int somaDC = C + D;
        int somaAB = A + B;
        
        if(B > C && D > A && somaDC > somaAB && C > 0 && D > 0 && A % 2 == 0)
        {
            Console.WriteLine("Valores aceitos");
        }
        else
        {
            Console.WriteLine("Valores nao aceitos");
        }
    }
}
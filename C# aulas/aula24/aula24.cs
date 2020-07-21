using System;

class Aula24
{
    static void Main()
    {
        int v1, v2;
        var r;
        v1 = Convert.ToInt32(Console.ReadLine());
        v2 = Convert.ToInt32(Console.ReadLine());
        r = Soma(v1, v2);
        Console.WriteLine("A soma de {0} e {1} é: {2}",v1 ,v2,r);
    }

    static int Soma(int a, int b)
    {
        int resultado = a + b;
        return resultado;
    }
}
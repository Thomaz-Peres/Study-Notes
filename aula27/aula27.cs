using System;

class Aula27
{
    static void Main()
    {
        soma(10, 5, 2, 4, 7);
    }

    static void soma(params int[] n)  //    sem retorno de valor
    {
        int resultado = 0;

        if (n.Length < 1)
        {
            Console.WriteLine("nao existem valores a serem somados");
        }
        else if (n.Length < 2)
        {
            Console.WriteLine("VAlores insuficientes para soma : {0}", n[0]);
        }
        else
        {
            for (int i = 0; i < n.Length; i++)
            {
                resultado += n[i];
            }
            Console.WriteLine("A soma dos valores é: {0}", resultado);
        }
    }
}
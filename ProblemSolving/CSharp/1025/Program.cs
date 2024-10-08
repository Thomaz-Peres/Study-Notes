using System;
using System.Collections.Generic;
using System.Linq;

public class Marmore
{
    public static void Main(string[] args) 
    {
        int cont = 0;
        int n;
        int q;
        do
        {
            string?[] linha = Console.ReadLine().Split(' ');

            n = Convert.ToInt32(linha[0]);
            q = Convert.ToInt32(linha[1]);

            if (q == 0 && n == 0)
                return;

            int[] mables = new int[n];
            int[] searchsMeena = new int[q];

            for (int x = 0; x < (n + q); x++)
            {
                if (x < n)
                    mables[x] = int.Parse(Console.ReadLine());
                else
                    searchsMeena[x - n] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"CASE# {cont + 1}:");
            foreach (var item in searchsMeena)
            {
                var findPos = Array.BinarySearch(mables, item);

                if (findPos == -1)
                    Console.WriteLine($"{item} not found");
                else
                    Console.WriteLine($"{item} found at {findPos + 1}");
            }
            cont++;
        } while (cont < 65 || n == 0 && q == 0);
    }
}
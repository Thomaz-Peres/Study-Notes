using System;

class URI
{

    static void Main(string[] args)
    {

        string[] linha1 = Console.ReadLine().Split(' ');

        int a = int.Parse(linha1[0]);
        int b = int.Parse(linha1[1]);
        int c = int.Parse(linha1[2]);

        if (a < b && a < c && b < c)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
        else if (a < b && a < c && b > c)
        {
            Console.WriteLine(a);
            Console.WriteLine(c);
            Console.WriteLine(b);
        }
        else if (a > b && b < c && a < c)
        {
            Console.WriteLine(b);
            Console.WriteLine(a);
            Console.WriteLine(c);
        }
        else if (a > b && b < c && a > c)
        {
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(a);
        }
        else if (a < b && b > c && a > c)
        {
            Console.WriteLine(c);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
        else if (a > b && b > c && a > c)
        {
            Console.WriteLine(c);
            Console.WriteLine(b);
            Console.WriteLine(a);
        }
        else
        {
        }
        Console.WriteLine("");
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);

    }

}
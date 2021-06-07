using System;
using System.Globalization;

class URI
{
    static void Main(string[] args)
    {
        float positivos = 0;

        for(float i = 0; i < 6; i++)
        {
            var b = float.Parse(Console.ReadLine());
            if(b > 0)
                positivos++;
        }

        Console.WriteLine("{0} valores positivos", positivos);
    }
}
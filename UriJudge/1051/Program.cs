using System;
using System.Globalization;

class URI
{

    static void Main(string[] args)
    {

        double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture), imposto = 00.00f;

        if (salary > 0 && salary <= 2000.00)
        {
            Console.WriteLine("Isento");
        }
        else if (salary > 2000.01 && salary <= 3000.00)
        {
            imposto = ((salary - 2000.00) * 0.08);
            Console.WriteLine($"R$ {imposto.ToString("F2")}");
        }
        else if (salary > 3000.01 && salary <= 4500.00)
        {
            imposto = ((salary - 3000.00) * 0.18) + 80;
            Console.WriteLine($"R$ {imposto.ToString("F2")}");
        }
        else
        {
            imposto = ((salary - 4500) * 0.28) + 80 + 270;
            Console.WriteLine($"R$ {imposto.ToString("F2")}");
        }

    }

}
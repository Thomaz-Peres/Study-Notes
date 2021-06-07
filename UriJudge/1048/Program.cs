using System;
using System.Globalization;

class URI
{

    static void Main(string[] args)
    {

        double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture), novoSalario, reajuste;

        if (salario > 0 && salario <= 400.00)
        {
            reajuste = salario * 0.15;
            novoSalario = reajuste + salario;

            Console.WriteLine($"Novo salario: {novoSalario.ToString("F2")}");
            Console.WriteLine($"Reajuste ganho: {reajuste.ToString("F2")}");
            Console.WriteLine("Em percentual: 15 %");
        }
        else if (salario >= 400.01 && salario <= 800.00)
        {
            reajuste = salario * 0.12;
            novoSalario = reajuste + salario;

            Console.WriteLine($"Novo salario: {novoSalario.ToString("F2")}");
            Console.WriteLine($"Reajuste ganho: {reajuste.ToString("F2")}");
            Console.WriteLine("Em percentual: 12 %");
        }
        else if (salario >= 800.01 && salario <= 1200.00)
        {
            reajuste = salario * 0.10;
            novoSalario = reajuste + salario;

            Console.WriteLine($"Novo salario: {novoSalario.ToString("F2")}");
            Console.WriteLine($"Reajuste ganho: {reajuste.ToString("F2")}");
            Console.WriteLine("Em percentual: 10 %");
        }
        else if (salario >= 1200.01 && salario <= 2000.00)
        {
            reajuste = salario * 0.07;
            novoSalario = reajuste + salario;

            Console.WriteLine($"Novo salario: {novoSalario.ToString("F2")}");
            Console.WriteLine($"Reajuste ganho: {reajuste.ToString("F2")}");
            Console.WriteLine("Em percentual: 7 %");
        }
        else
        {
            reajuste = salario * 0.04;
            novoSalario = reajuste + salario;

            Console.WriteLine($"Novo salario: {novoSalario.ToString("F2")}");
            Console.WriteLine($"Reajuste ganho: {reajuste.ToString("F2")}");
            Console.WriteLine("Em percentual: 4 %");
        }

    }

}
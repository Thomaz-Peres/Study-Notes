using System; 
using System.Globalization;

class _1008
{
    static void Main(string[] args) 
    { 
        int number = int.Parse(Console.ReadLine());
        int horasTrab = int.Parse(Console.ReadLine());
        decimal ganhoHora = decimal.Parse(Console.ReadLine(),  CultureInfo.InvariantCulture);
        
        var salary = ganhoHora * horasTrab;
        
        Console.WriteLine($"NUMBER = {number}");
        Console.WriteLine($"SALARY = U$ {salary.ToString("f2")}", CultureInfo.InvariantCulture);
    }
}
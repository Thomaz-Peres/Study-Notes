using System; 
using System.Globalization;

class _1005 
{
    static void Main(string[] args) 
    { 
        double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        var media = (a*3.5 + b*7.5) / 11;

        Console.WriteLine($"MEDIA = {media.ToString("f5")}", CultureInfo.InvariantCulture);
    }
}
using System; 
using System.Globalization;

class _1006
{
    static void Main(string[] args) 
    {
        double A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        var media = ((A * 2d + B * 3d + C * 5d) / 10);

        Console.WriteLine($"MEDIA = {media.ToString("f1")}", CultureInfo.InvariantCulture);
    }
}
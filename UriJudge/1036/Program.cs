using System; 
using System.Globalization;

class URI {

    static void Main(string[] args) { 

        string[] linha = Console.ReadLine().Split(' ');

            double a = double.Parse(linha[0], CultureInfo.InvariantCulture);
            double b = double.Parse(linha[1], CultureInfo.InvariantCulture);
            double c = double.Parse(linha[2], CultureInfo.InvariantCulture);
            
            double delta = (Math.Pow(b, 2) - 4 * a * c);

            if(delta < 0.0 || a == 0)
            {
                Console.WriteLine("Impossivel calcular");
            }    
            else
            {
                var resposta1 = (-b + Math.Sqrt(delta)) / (2.0 * a);
                var resposta2 = (-b - Math.Sqrt(delta)) / (2.0 * a);

                Console.WriteLine($"R1 = {resposta1.ToString("f5")}", CultureInfo.InvariantCulture);
                Console.WriteLine($"R2 = {resposta2.ToString("f5")}", CultureInfo.InvariantCulture);
            }

    }

}
using System;
using System.Globalization;

public class JurosCompostos
{
    static void Main(string[] args)
    {
        double montanteFinal;
		double capitalInvestido = 1000d;
		double tempo = 10d;
		double taxaJuros = 0.10d;
		double juros;
		
		montanteFinal = capitalInvestido * Math.Pow(1 + taxaJuros, tempo);
		juros = montanteFinal - capitalInvestido;
		
		Console.WriteLine("Seu montante final vai ser de {0}, e o Juros aculado de {1}", montanteFinal.ToString("f2"), juros.ToString("f2"),
        CultureInfo.InvariantCulture);
    }
}
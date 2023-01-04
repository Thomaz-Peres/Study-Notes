using System; 
using System.Globalization;

int testCase = int.Parse(Console.ReadLine());

string[] linha = Console.ReadLine().Split(' ');

int a = int.Parse(linha[0], CultureInfo.InvariantCulture);
int b = int.Parse(linha[1], CultureInfo.InvariantCulture);

int saida = 0;

if(testCase >= 1 && testCase <= 3000)
{
    saida = (a / 4) - (b / 4);
}

Console.WriteLine(saida);
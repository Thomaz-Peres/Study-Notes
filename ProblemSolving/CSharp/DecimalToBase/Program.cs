int n = int.Parse(Console.ReadLine());
int Base = int.Parse(Console.ReadLine());

string nBase = string.Empty;
int r = 0;

while (n >= Base)
{
    r = n % Base;

    nBase = r > 9 ? (char)(r - 10 + 'A') + nBase : r + nBase;

    n = n / Base;
}
nBase = n > 9 ? (char)(n - 10 + 'A') + nBase : n + nBase;

Console.WriteLine(nBase);
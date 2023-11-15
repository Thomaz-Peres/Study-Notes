string n = Console.ReadLine();
int Base = int.Parse(Console.ReadLine());

int expoente= 0 ;
int nDecimal = 0;

for(int i = n.Length - 1; i >= 0; i--)
{
    int digitValue = 0;
    if (char.IsDigit(n[i]))
    {
        digitValue = n[i] - '0';
    } else {
        digitValue = char.ToUpper(n[i]) - 'A' + 10;
    }
    nDecimal = nDecimal + digitValue * (int)Math.Pow(Base, expoente);
    expoente++;
}

Console.WriteLine(nDecimal);
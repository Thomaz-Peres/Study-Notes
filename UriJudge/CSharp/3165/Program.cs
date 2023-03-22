// See https://aka.ms/new-console-template for more information

int x = int.Parse(Console.ReadLine());
int y = 0;

if (x >= 5 && x <= 1000)
{
    while (x % 3 == 0)
    {
        x--;
    }
    y = x - 2;
}


Console.WriteLine($"{y} {x}");
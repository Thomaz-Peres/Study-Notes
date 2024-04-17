public class Marmore
{
    public static void Main(string[] args)
    {
        int cont = 0;
        int n;
        int q;
        do
        {
            string? linha = Console.ReadLine();

            string[] linha2 = linha?.Split(' ');
            n = Convert.ToInt32(linha2?[0]);
            q = Convert.ToInt32(linha2?[1]);

            if (q == 0 && n == 0)
                return;

            int[] mables = new int[n];
            int[] searchsMeena = new int[q];

            for (int x = 0; x < (n + q); x++)
            {
                if (x < n)
                {
                    string? x1 = Console.ReadLine();
                    mables[x] = int.Parse(x1 ?? throw new ArgumentException("Value cannot be null"));
                }
                else
                {
                    string? meena = Console.ReadLine();
                    searchsMeena[x - n] = int.Parse(meena ?? throw new ArgumentException("Value cannot be null"));
                }
            }

            Console.WriteLine($"CASE# {cont + 1}:");
            Array.Sort(mables);
            foreach (var item in searchsMeena)
            {
                var findPos = Array.IndexOf(mables, item);

                if (findPos == -1)
                    Console.WriteLine($"{item} not found");
                else
                    Console.WriteLine($"{item} found at {findPos + 1}");
            }
            cont++;
        } while (cont < 65 || n == 0 && q == 0);
    }
}
class Marmore {

    public void Main(string[] args) 
    {
        int cont = 0;
        int n = 0;
        int q = 0;
        do
        {
            string[] linha = Console.ReadLine().Split(' ');

            n = Convert.ToInt32(linha[0]);
            q = Convert.ToInt32(linha[1]);

            if (q == 0 && n == 0)
                return;

            int[] mables = new int[n];
            int[] searchsMeena = new int[q];

            for (int x = 0; x < (n + q); x++)
            {
                if (x < n)
                    mables[x] = int.Parse(Console.ReadLine());
                else
                {
                    searchsMeena[x - n] = int.Parse(Console.ReadLine());
                }
            }

            // como os numeros estao ordenados, eu pego o numero que quero procurar, e verifico se existe antes ou depois.
            // dar uma olhada nas aulas de C que fiz sobre estrutura de dados e algoritmos
            Console.WriteLine($"CASE# {cont + 1}:");
            Array.Sort(mables);
            Array.Sort(searchsMeena);
            foreach (var item in searchsMeena)
            {
                var findPos = Array.BinarySearch(mables, item);

                if (findPos == -1)
                    Console.WriteLine($"{item} not found");
                else
                    Console.WriteLine($"{item} found at {findPos + 1}");
            }
            cont++;
        } while (cont < 65 || n == 0 && q == 0);
    }
}
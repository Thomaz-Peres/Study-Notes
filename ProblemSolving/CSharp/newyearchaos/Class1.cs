class Result
{

    /*
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */

    public static void minimumBribes(List<int> q)
    {
        int bribes = 0;
        for (int i = q.Count - 1; i >= 0; i--)
        {
            var x = i + 1;

            if (x == q[i])
                continue;

            if (x > q[i])
            {
                bribes++;
            }

            if (x > q[i] - 1)
            {
                bribes++;
            }

            if (bribes > 3)
            {
                Console.WriteLine("Too chaotic");
                return;
            }
        }

        Console.WriteLine(bribes);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

            Result.minimumBribes(q);
        }
    }
}

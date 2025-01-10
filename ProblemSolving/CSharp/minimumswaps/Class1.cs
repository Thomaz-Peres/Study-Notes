public class Solution
{
    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr)
    {
        int swaps = 0;
        var n = arr.Length;

        for (int i = 0; i < n; i++)
        {
            while (arr[i] != i + 1)
            {
                int correctIndex = arr[i] - 1;

                int temp = arr[i];
                arr[i] = arr[correctIndex];
                arr[correctIndex] = temp;

                swaps++;
            }
        }

        return swaps;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int res = minimumSwaps(arr);

        Console.WriteLine("Minimum: " + res);
    }
}

namespace DataStructure.Algorithms;

public static class BinarySearch
{
    public static int SearchOption(int[] ar, int t)
    {
        Array.Sort(ar);
        int i = 0;
        while (i <= ar.Length - 1)
        {
            int x = (ar.Length - i) / 2;
            if (t > ar[x]) {
                i = x + 1;
            } else if (t < ar[x]) {
                i = x - 1;
            }
        }

        return i;
    }
}

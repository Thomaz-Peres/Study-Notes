namespace DataStructure.Algorithms;

public static class ExponentialSearch
{
    public static int Es(int[] ar, int key, int size)
    {
        if (size == 0)
            return 0;

        int bound = 1;
        while (bound < size && ar[bound] < key) {
            bound *= 2;
        }

        return Array.BinarySearch(ar, key, bound/2, Math.Min(bound, size));
    }
}

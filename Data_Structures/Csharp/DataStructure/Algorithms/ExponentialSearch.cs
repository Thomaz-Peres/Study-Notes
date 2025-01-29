namespace DataStructure.Algorithms;

public static class ExponentialSearch
{
    public static int Es(int[] ar, int key)
    {
        if (ar.Length - 1 == 0)
            return -1;

        // Ensure the array is sorted (ideally, this should be done beforehand)
        Array.Sort(ar);

        // If the key is at the first position
        if (ar[0] == key)
            return 0;

        int bound = 1;
        while (bound < ar.Length - 1 && ar[bound] < key) {
            bound *= 2;
        }

        int start = bound / 2;
        int end = Math.Min(bound, ar.Length - 1);

        int[] subArray = new int[end - start + 1];
        Array.Copy(ar, start, subArray, 0, subArray.Length);

        return BinarySearch.SearchOption(subArray, key);
    }
}

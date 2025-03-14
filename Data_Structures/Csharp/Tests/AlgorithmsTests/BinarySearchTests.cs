using Bs = DataStructure.Algorithms.BinarySearch;
using Es = DataStructure.Algorithms.ExponentialSearch;

namespace Tests.AlgorithmsTests;

public static class BinarySearchTests
{
    [Theory]
    [InlineData(new int[] { 5, 8, 7, 9, 6, 3, 10, 25, 2 }, 3)]
    [InlineData(new int[] { 5, 8, 7, 3, 2, 10, 9, 1, 4, 6 }, 9)]
    public static void IntLinkedList(int[] arr, int t)
    {
        Assert.Equal(t, Bs.SearchOption(arr, t));
    }

    [Theory]
    [InlineData(new int[] { 5, 8, 7, 9, 6, 3, 10, 25, 2 }, 3)]
    [InlineData(new int[] { 5, 8, 7, 3, 2, 10, 9, 1, 4, 6 }, 9)]
    public static void ExponentialSearch(int[] arr, int key)
    {
        Assert.Equal(key, Es.Es(arr, key));
    }
}

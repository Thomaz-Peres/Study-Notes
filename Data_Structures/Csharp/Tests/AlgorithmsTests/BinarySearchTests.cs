using bs = DataStructure.Algorithms.BinarySearch;

namespace Tests.AlgorithmsTests;

public static class BinarySearchTests
{
    [Theory]
    [InlineData(new int[] {5, 8, 7, 9, 6, 3, 10, 25, 2}, 3)]
    public static void IntLinkedList(int[] arr, int t)
    {
        Assert.Equal(t, bs.SearchOption(arr, t));
    }
}

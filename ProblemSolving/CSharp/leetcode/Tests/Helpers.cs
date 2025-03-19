using leetcode;

public partial class UnitTest1
{
    public static IEnumerable<object[]> TwoSortedLists =>
        new List<object[]>
        {
            new object[] {
                new ListNode(1, new ListNode(2, new ListNode(4))),
                new ListNode(1, new ListNode(3, new ListNode(4)))
            },
            new object[] {
                new ListNode(1),
                null! // ??
            },
            new object[] {
                new ListNode(2),
                new ListNode(1),
            },
            new object[] {
                new ListNode(-10, new ListNode(-9, new ListNode(-6, new ListNode( -4, new ListNode(1, new ListNode(9, new ListNode(9))))))),
                new ListNode(-5, new ListNode(-3, new ListNode(0, new ListNode(7, new ListNode(8, new ListNode(8)))))),
            },
        };

    public static IEnumerable<object[]> MaxProfit =>
        new List<object[]>
        {
            new object[] {
                new int[] { 7,1,5,3,6,4 },
                5,
            },
        };

    public static IEnumerable<object[]> InvertTree =>
        new List<object[]>
        {
            new object[] {
                new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)),  new TreeNode(7, new TreeNode(6), new TreeNode(9))),
                new TreeNode(4, new TreeNode(7, new TreeNode(9), new TreeNode(6)),  new TreeNode(2, new TreeNode(3), new TreeNode(1)))
            },
            new object[] {
                new TreeNode(2, new TreeNode(1),  new TreeNode(3)),
                new TreeNode(2, new TreeNode(3),  new TreeNode(1))
            },
            new object[] {
                new TreeNode(1, new TreeNode(2), null),
                new TreeNode(1, null,  new TreeNode(2))
            },
        };

    public static IEnumerable<object[]> BinarySearch =>
        new List<object[]>
        {
            new object[] {
                new int[] { -1,0,3,5,9,12 },
                2,
                -1
            },
        };

    public static IEnumerable<object[]> FloodFill =>
        new List<object[]>
        {
            new object[] {
                new int[] [[1,1,1],[1,1,0],[1,0,1]],
                2,
                -1
            },
        };
}

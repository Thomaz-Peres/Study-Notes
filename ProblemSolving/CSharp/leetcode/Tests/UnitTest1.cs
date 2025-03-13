using leetcode;
using Newtonsoft.Json;

public partial class UnitTest1
{
    private readonly ListNode ReversedList = new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))));
    private readonly ListNode List = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

    [Fact]
    public void ReverseListRecursive()
    {
        var b = Solution206.ReverseListRecursive(List);

        Assert.Equal(JsonConvert.SerializeObject(ReversedList), JsonConvert.SerializeObject(b));
    }

    [Fact]
    public void ReverseListNonRecursive()
    {
        var b = Solution206.ReverseListNonRecursive(List);

        Assert.Equal(JsonConvert.SerializeObject(ReversedList), JsonConvert.SerializeObject(b));
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("(([))", false)]
    [InlineData("([)]", false)]
    [InlineData("(])", false)]
    [InlineData("[])", false)]
    public void ValidParentheses(string s, bool expected)
    {
        var b = Solution2.IsValid(s);

        Assert.Equal(expected, b);
    }

    [Theory]
    [MemberData(nameof(TwoSortedLists))]
    public static void ValidMergeTwoSortedLists(ListNode l1, ListNode l2)
    {
        var b = Solution21.MergeTwoLists(l1, l2);

        // Assert.Equal(expected, b);
    }

    [Theory]
    [MemberData(nameof(MaxProfit))]
    public void ValidMaxProfit(int[] s, int expected)
    {
        var b = Solution121.MaxProfit(s);

        Assert.Equal(expected, b);
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData(" ", true)]
    [InlineData("race a car", false)]
    public void ValidPalindrome(string s, bool expected)
    {
        var b = Solution125.IsPalindrome(s);

        Assert.Equal(expected, b);
    }

    [Theory]
    [MemberData(nameof(InvertTree))]
    public void ValidInvertTrete(TreeNode root, TreeNode expected)
    {
        var result = Solution226.InvertTree(root);

        var b = JsonConvert.SerializeObject(result);

        Assert.Equal(JsonConvert.SerializeObject(expected), b);
    }

    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    [InlineData("a", "a", true)]
    public void ValidAnagram(string s, string t, bool expected)
    {
        var b = Solution224.IsAnagram(s, t);

        Assert.Equal(expected, b);
    }

    [Theory]
    [MemberData(nameof(BinarySearch))]
    public void ValidBinarySearch(int[] nums, int t, int expected)
    {
        var b = Solution704.Search(nums, t);

        Assert.Equal(expected, b);
    }

    [Fact]
    public void ValidFloodFill()
    {
        int[][] imagem = [[1,1,1],[1,1,0],[1,0,1]];
        var b = Solution733.FloodFill(imagem, 1, 1, 2);

        // Assert.Equal(expected, b);
    }
}

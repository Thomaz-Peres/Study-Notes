using System.Diagnostics;
using leetcode;
using Newtonsoft.Json;

namespace tests;

public class UnitTest1
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

    public static IEnumerable<object[]> SplitCountData =>
        new List<object[]>
        {
            new object[] {
                new ListNode(1, new ListNode(2, new ListNode(4))),
                new ListNode(1, new ListNode(3, new ListNode(4)))
            },
        };

    [Theory]
    [MemberData(nameof(SplitCountData))]
    public static void ValidMergeTwoSortedLists(ListNode l1, ListNode l2)
    {
        var b = Solution21.MergeTwoLists(l1, l2);
        Debug.WriteLine(JsonConvert.SerializeObject(b));

        // Assert.Equal(expected, b);
    }
}

using leetcode;

namespace tests;

public class UnitTest1
{
    [Fact]
    public void ReverseListRecursive()
    {
        var x = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        var b = Solution206.ReverseListRecursive(x);
        var teste = new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))));

        Assert.Equal<ListNode>(teste, b);
    }

    [Fact]
    public void ReverseListNonRecursive()
    {
        var x = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        var b = Solution206.ReverseListNonRecursive(x);

        Assert.Equal(new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1))))), b);
    }
}

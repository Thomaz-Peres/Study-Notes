using leetcode;

namespace tests;

public class UnitTest1
{
    [Fact]
    public void ReverseListRecursive()
    {
        var x = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        var b = Solution206.ReverseListRecursive(x);

        Assert.Equal(new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1))))), b);
    }
}

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
}

namespace leetcode;

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public static class Solution206
{
    public static ListNode ReverseListRecursive(ListNode head)
    {
        if (head == null)
            return new ListNode();

        var x = new ListNode();
        if (head.next == null)
            x = head;

        if (head.next != null) {

            x = ReverseListRecursive(head.next);
            var oldValue = head;
            x.next = oldValue;
        }

        return x;
    }
}

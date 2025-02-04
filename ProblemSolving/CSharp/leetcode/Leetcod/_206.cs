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
            return head;

        if (head.next != null) {
            var oldValue = head;
            x = ReverseListRecursive(head.next);
            x.next = oldValue;
        }

        return x;
    }
}

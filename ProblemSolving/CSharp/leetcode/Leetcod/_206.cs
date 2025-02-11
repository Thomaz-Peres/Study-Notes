namespace leetcode;

public static class Solution206
{
    public static ListNode? ReverseListRecursive(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        var newValue = ReverseListRecursive(head.next);

        head.next.next = head;
        head.next = null;

        return newValue;
    }

    public static ListNode? ReverseListNonRecursive(ListNode head)
    {
        ListNode? prev = null;
        ListNode? curr = head;
        ListNode? next;
        while(curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}

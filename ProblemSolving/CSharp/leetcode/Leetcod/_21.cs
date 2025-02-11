
namespace leetcode;

public static class Solution21 {
    public static ListNode MergeTwoLists(ListNode? list1, ListNode? list2) {
        var newList = new ListNode();

        var curr1 = list1;
        var curr2 = list2;

        ListNode? prev1 = null;
        ListNode? prev2 = null;

        ListNode? next1;
        ListNode? next2;

        while (curr1 != null && curr2 != null) {
            if (curr1.val == curr2.val) {
                next1 = curr1.next;
                next2 = curr2.next;

                curr1.next = prev1;
                curr2.next = prev2;

                prev1 = curr1;
                prev2 = curr2;

                newList.val = prev1.val;
                newList.next = prev2;

                continue;
            }

            if (list1.val > list2.val) {
                newList.val = list2.val;
                list2 = list2.next;
                continue;
            }

            if (list1.val < list2.val) {
                newList.val = list1.val;
                list1 = list1.next;
                continue;
            }
        }

        return newList;
    }
}

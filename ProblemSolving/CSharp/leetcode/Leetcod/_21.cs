
namespace leetcode;

public static class Solution21 {
    public static ListNode MergeTwoLists(ListNode? list1, ListNode? list2) {
        var newList = new ListNode();

        var currNew = newList;

        var curr1 = list1;
        var curr2 = list2;

        while (curr1 != null && curr2 != null) {
            if (curr1.val == curr2.val) {
                currNew.val = curr1.val;
                currNew.next = new ListNode(curr2.val);

                curr1 = curr1.next;
                curr2 = curr2.next;


                currNew = currNew.next;
                currNew.next = null;

                continue;
            }

            if (curr1.val > curr2.val) {
                currNew.next = curr2;

                curr2 = curr2.next;

                currNew = currNew.next;
                currNew.next = null;

                continue;
            }

            if (curr1.val < curr2.val) {
                currNew.next = curr1;

                curr1 = curr1.next;

                currNew = currNew.next;
                currNew.next = null;

                continue;
            }
        }

        return newList;
    }
}

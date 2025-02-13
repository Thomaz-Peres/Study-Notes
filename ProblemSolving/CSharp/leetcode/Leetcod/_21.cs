
namespace leetcode;

public static class Solution21 {
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null && list2 == null)
            return null;

        var newList = new ListNode();

        var currNew = newList;

        var curr1 = list1;
        var curr2 = list2;

        // if (curr1 != null && curr1.next == null && curr2 == null)
        // {
        //     currNew.next = new ListNode(curr1.val);
        //     currNew = currNew.next;
        //     curr1 = curr1.next;
        // }

        // if (curr2 != null && curr2.next == null && curr1 == null)
        // {
        //     currNew.next = new ListNode(curr2.val);
        //     currNew = currNew.next;
        //     curr2 = curr2.next;
        // }

        while (curr1 != null && curr2 != null) {
            if (curr1.val == curr2.val) {
                currNew.next = new ListNode(curr1.val);
                currNew = currNew.next;


                currNew.next = curr2;
                currNew = currNew.next;

                curr1 = curr1.next;
                curr2 = curr2.next;

                // currNew.next = null;

                continue;
            }

            if (curr1.val > curr2.val) {
                currNew.next = curr2;

                curr2 = curr2.next;
                currNew = currNew.next;

                // currNew.next = null;

                continue;
            }

            if (curr1.val < curr2.val) {
                currNew.next = curr1;

                curr1 = curr1.next;
                currNew = currNew.next;

                // currNew.next = null;

                continue;
            }
        }

        if (curr1 == null) {
            currNew.next = curr2;
            // currNew = currNew.next;
        }

        if (curr2 == null) {
            currNew.next = curr1;
            // currNew = currNew.next;
        }

        if (newList.next != null) {
            return newList.next;
        }


        return newList;
    }
}

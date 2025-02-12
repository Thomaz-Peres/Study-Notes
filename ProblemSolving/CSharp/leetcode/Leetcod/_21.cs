
namespace leetcode;

public static class Solution21 {
    // public static ListNode MergeTwoLists(ListNode? list1, ListNode? list2) {
    //     var newList = new ListNode();


    //     var curr1 = list1;
    //     var curr2 = list2;

    //     ListNode? next1;
    //     ListNode? next2;

    //     while (curr1 != null && curr2 != null) {
    //         ListNode? curr;

    //         if (curr1.val == curr2.val) {
    //             next1 = curr1.next;

    //             newList.val = curr1.val;
    //             curr.next = newList;

    //             curr1 = next1;

    //             continue;
    //         }

    //         if (curr1.val > curr2.val) {
    //             next2 = curr2.next;

    //             curr = curr2;
    //             newList = curr.next;
    //             curr2 = next2;

    //             continue;
    //         }

    //         if (curr1.val < curr2.val) {
    //             next1 = curr1.next;

    //             curr = curr1;
    //             newList = newList.next;
    //             curr1 = next1;
    //             continue;
    //         }
    //     }

    //     return newList;
    // }

    public static ListNode MergeTwoLists(ListNode? list1, ListNode? list2) {
        var newList = new ListNode();

        var currNew = newList;
        ListNode? nextN;

        var curr1 = list1;
        var curr2 = list2;

        while (curr1 != null && curr2 != null) {

            if (curr1.val == curr2.val) {
                currNew.val = curr1.val;
                currNew.next = new ListNode(curr2.val);

                curr1 = curr1.next;
                curr2 = curr2.next;

                nextN = currNew.next;
                nextN.next = null;

                currNew = nextN;

                continue;
            }

            if (curr1.val > curr2.val) {
                currNew.next = curr2;

                curr2 = curr2.next;

                nextN = currNew.next;
                nextN.next = null;

                currNew = nextN;

                continue;
            }

            if (curr1.val < curr2.val) {
                currNew.next = curr1;

                curr1 = curr1.next;

                nextN = currNew.next;
                nextN.next = null;

                currNew = nextN;

                continue;
            }
        }

        return newList;
    }
}

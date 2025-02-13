
namespace leetcode;

public static class Solution21 {
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null && list2 == null)
            return null;

        var newList = new ListNode();

        var currNew = newList;

        while (list1 != null && list2 != null) {
            if (list1.val == list2.val) {
                currNew.next = new ListNode(list1.val);
                currNew = currNew.next;


                currNew.next = list2;
                currNew = currNew.next;

                list1 = list1.next;
                list2 = list2.next;

                currNew.next = null;

                continue;
            }

            if (list1.val > list2.val) {
                currNew.next = list2;

                list2 = list2.next;
                currNew = currNew.next;

                currNew.next = null;

                continue;
            }

            if (list1.val < list2.val) {
                currNew.next = list1;

                list1 = list1.next;
                currNew = currNew.next;

                currNew.next = null;

                continue;
            }
        }

        while (list1 != null) {
            currNew.next = list1;
            currNew = currNew.next;

            list1 = list1.next;
        }

        while (list2 != null) {
            currNew.next = list2;
            currNew = currNew.next;

            list2 = list2.next;
        }

        if (newList.next != null) {
            return newList.next;
        }


        return newList;
    }
}

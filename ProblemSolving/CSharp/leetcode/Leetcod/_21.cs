#nullable disable

namespace leetcode;

public static class Solution21 {
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null && list2 == null)
            return null;

        var newList = new ListNode();

        var currNew = newList;

        while (list1 != null && list2 != null) {
            if (list1.val > list2.val) {
                currNew.next = list2;
                list2 = list2.next;
            } else  {
                currNew.next = list1;
                list1 = list1.next;
            }

            currNew = currNew.next;
        }

        currNew.next = list1 != null ? list1 : list2;

        return newList.next;
    }
}

#nullable enable

public static class Solution704 {
    public static int Search(int[] nums, int target) {
        int r = nums.Length - 1;
        int l = 0;
        while (l <= r)
        {
            int x = (r + l) / 2;
            if (target > nums[x]) {
                l = x + 1;
            } else if (target < nums[x]) {
                r = x - 1;
            } else {
                return x;
            }
        }

        return -1;
    }
}

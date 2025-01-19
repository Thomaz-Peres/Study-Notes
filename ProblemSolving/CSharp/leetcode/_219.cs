namespace leetcode;

public static class Solution219 {
    public static bool ContainsNearbyDuplicate(int[] nums, int k) {
        for (var i = 0; i < nums.Length - 1; i++) {
            int j = i + 1;
            while (j <= i + k && j < nums.Length) {
                if (nums[i] == nums[j] && Math.Abs(i - j) <= k) {
                    return true;
                }
                j++;
            }
        }

        return false;
    }
}

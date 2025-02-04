namespace leetcode;

public static class Solution219 {
    public static bool ContainsNearbyDuplicate(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            if (map.Count != 0 && map.ContainsKey(nums[i]))
                if (i - map[nums[i]] <= k) {
                    return true;
                }

            map[nums[i]] = i;
        }

        return false;
    }
}

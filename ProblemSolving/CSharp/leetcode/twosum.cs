namespace leetcode;

public static class Solution {
    public static int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            var x = target - nums[i];
            if (map.ContainsKey(x))
                return new int[] { map[x], i };

            map[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}

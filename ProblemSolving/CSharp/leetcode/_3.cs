using System.Text;

namespace leetcode;

public static class Solution3 {
    public static int LengthOfLongestSubstring(string s) {
        if (s.Length == 0)
            return 0;

        if (s.Length == 1)
            return 1;

        HashSet<char> uniqueChar = new();

        int left = 0;
        int right = 0;

        int max = 0;
        while (right < s.Length) {

            while (uniqueChar.Contains(s[right])) {
                uniqueChar.Remove(s[left]);
                left++;
            }

            max = Math.Max(max, right - left + 1);
            uniqueChar.Add(s[right]);
            right++;

        }

        return max;
    }
}

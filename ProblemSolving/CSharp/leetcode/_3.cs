using System.Text;

namespace leetcode;

public static class Solution3 {
    public static int LengthOfLongestSubstring(string s) {
        int sum = 0;
        Dictionary<int, char> str = new Dictionary<int, char>();
        for (int i = 0; i < s.Length - 1; i++) {
            if (str.ContainsValue(s[i]))
                return sum;

            str.Add(i, s[i]);
            sum++;
        }
        return sum;
    }
}

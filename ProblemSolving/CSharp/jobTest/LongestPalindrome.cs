
public static class Solution {
    public static string LongestPalindromeSubstring(string s) {
        string pal = string.Empty;
        s = s.ToLower();

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j <= s.Length; j++)
            {
                var sub = s.Substring(i, j - i);
                if (sub.Length <= 2)
                    continue;

                char[] chars = sub.ToCharArray();
                Array.Reverse(chars);

                if (new string(chars).Equals(sub) && sub.Length > pal.Length)
                {
                    pal = sub;
                }
            }
        }

        if (string.IsNullOrEmpty(pal))
            pal = "none";

        return pal;
    }
}

namespace leetcode;

public static class Solution9 {
    public static bool IsPalindromeNumber(int x)
    {
        if (x < 0)
            return false;

        var s = x.ToString();
        int a = 0;
        int b = s.Length - 1;

        while (a < b)
        {
            if (s[a] != s[b])
                return false;

            a += 1;
            b -= 1;
        }

        return true;
    }
}

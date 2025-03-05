using System.Text.RegularExpressions;

public static class Solution125 {
    public static bool IsPalindrome(string s) {
        s = Regex.Replace(s, "[^A-Za-z0-9]", "");
        s = s.ToLower();

        char[] chars = s.ToCharArray();
        Array.Reverse(chars);

        if (new string(chars).Equals(s))
            return true;

        return false;
    }
}

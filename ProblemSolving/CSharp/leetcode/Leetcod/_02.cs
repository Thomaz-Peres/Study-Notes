namespace leetcode;

public static class Solution2 {
    public static bool IsValid(string s) {
        var parent = new HashSet<char>();
        var parent2 = new Stack<char>();


        for (int i = 0; i <= s.Length - 1; i++){
            if (s[i] == '(')
                parent2.Push(s[i]);

            if (parent2.Count > 1)
                return false;

            if (s[i] == ')')
                parent2.Pop();
        }

        if (parent2.Any())
            return false;

        return true;
    }
}

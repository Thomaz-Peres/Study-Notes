using System;

namespace leetcode;

public static class Solution2 {
    public static bool IsValid(string s) {
        var parent = new Stack<char>();

        if (s.Length == 0)
            return false;

        foreach (var item in s) {
            if (item == '(' || item == '[' || item == '{')
            {
                parent.Push(item);
                continue;
            }
            if (parent.Count == 0)
                return false;

            char x = parent.Pop();
            if (item == ')' && x != '(' ||
                item == ']' && x != '[' ||
                item == '}' && x != '{'
            )
            {
                return false;
            }
        }

        return parent.Count == 0;
    }
}

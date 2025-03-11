public static class Solution224 {
    public static bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;

        Dictionary<int, int> map = new();

        foreach (var item in s)
        {
            if (map.ContainsKey(item))
                map[item]++;
            else
                map[item] = 1;
        }

        foreach (var item in t)
        {
            if (!map.ContainsKey(item) || map[item] == 0)
            {
                return false;
            } else
                map[item]--;
        }

        return true;
    }
}

using System.Text;

public static class Solution557 {
    public static string ReverseWords(string s) {
        StringBuilder newStr = new StringBuilder();

        foreach (var item in s.Split(' '))
        {
            for (int i = item.Length - 1; i >= 0; i--) {
                newStr.Append(item[i]);
            }

            newStr.Append(" ");
        }

        if (newStr[newStr.Length - 1] == ' ')
            newStr.Length -= 1;

        return newStr.ToString();
    }
}

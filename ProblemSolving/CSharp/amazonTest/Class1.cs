using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Result
{

    /*
     * Complete the 'findMaxEfficiencyScore' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING kitParentheses
     *  3. INTEGER_ARRAY efficiencyRatings
     */

    public static long findMaxEfficiencyScore(string s, string kitParentheses, List<int> efficiencyRatings)
    {
        long sum = 0;
        var x = 0;
        var openB = 0;
        var closeB = 0;
        for (int j = 0; j < s.Length; j++)
        {
            if (s[j] == '(')
                openB++;

            if (s[j] == ')')
                closeB++;
        }

        for (int i = 0; i < kitParentheses.Length; i++)
        {
            if (kitParentheses[i] == '(' && openB > 0)
            {
                sum += efficiencyRatings[i];
                openB--;
            }

            if (kitParentheses[i] == ')' && closeB > 0)
            {
                sum = sum + (efficiencyRatings[i]);
                closeB--;
            }
        }
        return sum;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();

        string kitParentheses = Console.ReadLine();

        int efficiencyRatingsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> efficiencyRatings = new List<int>();

        for (int i = 0; i < efficiencyRatingsCount; i++)
        {
            int efficiencyRatingsItem = Convert.ToInt32(Console.ReadLine().Trim());
            efficiencyRatings.Add(efficiencyRatingsItem);
        }

        long result = Result.findMaxEfficiencyScore(s, kitParentheses, efficiencyRatings);

        Console.WriteLine(result);
    }
}

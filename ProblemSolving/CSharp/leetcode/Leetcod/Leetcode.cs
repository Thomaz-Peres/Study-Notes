#nullable disable

using Newtonsoft.Json;

namespace leetcode;

public class Leetcode
{
    static void Main(string[] args)
    {
        // int[] nums = Array.ConvertAll(Console.ReadLine().Split(','), arr => Convert.ToInt32(arr));
        // var target = Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine(string.Join(",", new Solution().TwoSum(nums, target)));

        Console.WriteLine(Solution3.LengthOfLongestSubstring(Console.ReadLine()));
    }
}





#nullable enable

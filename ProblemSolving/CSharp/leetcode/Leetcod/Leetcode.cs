#nullable disable
namespace leetcode;

public class Leetcode
{
    static void Main(string[] args)
    {
        // int[] nums = Array.ConvertAll(Console.ReadLine().Split(','), arr => Convert.ToInt32(arr));
        // var target = Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine(string.Join(",", new Solution().TwoSum(nums, target)));

        var x = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        // new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))));
        var b = Solution206.ReverseListRecursive(x);
        Console.WriteLine(b);

        // Console.WriteLine(Solution3.LengthOfLongestSubstring(Console.ReadLine()));
    }
}





#nullable enable

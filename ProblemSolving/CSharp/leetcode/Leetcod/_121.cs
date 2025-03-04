namespace leetcode;

public static class Solution121
{
    public static int MaxProfit(int[] prices) {
        var p = 0;
        Stack<int> arr = new();

        for (var i = 0; i <= prices.Length - 1; i++)
        {
            if (arr.Count == 0)
                arr.Push(prices[i]);

            if (arr.Count != 0 && arr.Peek() > prices[i])
            {
                arr.Pop();
                arr.Push(prices[i]);
            }
            else
                if (prices[i] - arr.Peek() > p)
                    p = prices[i] - arr.Peek();

        }

        return p;
    }
}

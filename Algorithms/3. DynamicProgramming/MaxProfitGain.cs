//https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

using System;
					
public class Program
{
	public static void Main()
	{
		int[] prices = {7, 1, 5, 3, 6, 4};
		Console.WriteLine(MaxProfit(prices));
	}
	
	// O(n)
    private static int MaxProfit(int[] prices) {
        if(prices == null || prices.Length < 2)
            return 0;
        
        int min = prices[0];
        int maxProfit = 0;
        
        foreach(int price in prices)
        {
            min = Math.Min(min, price);
            maxProfit = Math.Max(maxProfit, price - min);
        }
        
        return maxProfit;
    }
}

// Sunny Bhawsar
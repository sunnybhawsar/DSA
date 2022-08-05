// https://leetcode.com/problems/coin-change/

using System;
					
public class Program
{
	public static void Main()
	{
		int[] coins = {1,2,5};
		int amount = 11;
		
		int result = MinCoinsTab(coins, amount);
        
		Console.WriteLine(result != Int32.MaxValue ? result : -1);
	}
	
	// DP - Tabulation approach
	// Time: O(k * n) , Space: O(k)  where k is amount & n is total number of coins
    private static int MinCoinsTab(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, Int32.MaxValue);
        dp[0] = 0;
        
        for(int i = 1; i <= amount; i++)
        {
            for(int j = 0; j < coins.Length; j++)
            {
                if(i - coins[j] >= 0 && dp[i - coins[j]] != Int32.MaxValue)
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coins[j]]);
            }
        }
        
        return dp[amount];
    }
    
	
	// DP - Recursion + Memoization approach
	// Time: O(k * n) , Space: O(k)  where k is amount & n is total number of coins
    private static int MinCoinsMemoization(int[] coins, int amount, int[] dp)
    {
        if(amount == 0)
            return 0;
        
        if(amount < 0)
            return Int32.MaxValue;
        
        if(dp[amount] != Int32.MaxValue)
            return dp[amount];
        
        int minCoins = Int32.MaxValue, left = 0;
        
        for(int i = 0; i < coins.Length; i++)
        {
            left = MinCoinsMemoization(coins, amount - coins[i], dp);
            
            if(left != Int32.MaxValue)
                minCoins = Math.Min(minCoins, left + 1);
        }
        
        dp[amount] = minCoins;
        
        return minCoins;
    }
}

// Sunny Bhawsar
// https://leetcode.com/problems/min-cost-climbing-stairs/

using System;
					
public class Program
{
	public static void Main()
	{
		int[] cost = {1,100,1,1,1,100,1,1,100,1};
		
		// We can start from index 0/1
		// Need to reach on top i.e lenght of cost
		// Minimum cost using DP
		Console.WriteLine(MinCostClimbingStairs(cost));
	}
	
	// O(n)
	private static int MinCostClimbingStairs(int[] cost) {
        if(cost.Length == 2)
            return Math.Min(cost[0], cost[1]);
        
        int[] dp = new int[cost.Length];
        dp[0] = cost[0];
        dp[1] = cost[1];
        
        for(int i = 2; i < cost.Length; i++)
        {
            dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
        }
        
        return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
    }
}

// Sunny Bhawsar
// Keep adding current cost and min total cost of previous two steps
// Take Min of total cost of last or 2nd last step
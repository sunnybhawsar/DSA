using System;
					
public class Program
{
	public static void Main()
	{
		int n = 6;
		int[] dp = new int[n + 1];
		Array.Fill(dp, -1);
		
		Console.WriteLine(NthFibNumberDpTopDown(n, dp));
	}
	
	// DP (Top Down) - Recursion + Memoization 
	// Time: O(n) + O(n) and Space: O(n)
	private static int NthFibNumberDpTopDown(int n, int[] dp)
	{
		if(n <= 1)
			return n;
		
		if(dp[n] != -1)
			   return dp[n];
			   
		dp[n] = NthFibNumberDpTopDown(n-1, dp) + NthFibNumberDpTopDown(n-2, dp);
		return dp[n];
	}
	
	// DP (Bottom Up) - Memoization 
	// Time: O(n) and Space: O(n)
	private static int NthFibNumberDpBottomUp(int n)
	{
		int[] dp = new int[n+1];
		dp[0] = 0;
		dp[1] = 1;
		
		for(int i = 2; i <= n; i++)
		{
			dp[i] += dp[i-1] + dp[i-2];
		}
		
		return dp[n];
	}
	
	// DP - Memory optimized
	// Time: O(n) and Space: O(1)
	private static int NthFibNumberDpMemoryOptimized(int n)
	{
		int prev1 = 0, prev2 = 1, curr = 0;
		
		for(int i = 2; i <= n; i++)
		{
			curr = prev1 + prev2;
			prev1 = prev2;
			prev2 = curr;
		}
		
		return curr;
	}
	
	// Recursion O(n) + O(n)
	private static int NthFibNumberRecursive(int n)
	{
		if(n <= 1)
			return n;
		
		return NthFibNumberRecursive(n-1) + NthFibNumberRecursive(n-2);
	}
}

// Sunny Bhawsar
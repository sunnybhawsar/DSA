// https://leetcode.com/problems/unique-paths/submissions/

using System;
					
public class Program
{
	public static void Main()
	{
		// m * n grid
		int m = 4, n = 4;		
		
		Console.WriteLine("Total number of unique paths to reach bottom right corner: " + TotalPaths(m, n));
	}
	
	// DP Simple
	// Time: O(m * n)
	private static int TotalPaths(int m, int n)
	{
		int[][] dp = new int[m][];
		
		for(int i = 0; i < m; i++)
		{
			dp[i] = new int[n];
			for(int j = 0; j < n; j++)
			{
				if(i == 0 || j == 0)
					dp[i][j] = 1;
				else
					dp[i][j] += dp[i][j - 1] + dp[i - 1][j];
			}
		}
		
		return dp[m - 1][n - 1];
	}
	
	// DP Tabulation
	// Time: O(m*n), Space: O(n)
	private static int TotalPathsDPTabulation(int m, int n)
	{
		int[] dp = new int[n];
		dp[0] = 1;
		
		for(int i = 0; i < m; i++)
			for(int j = 1; j < n; j++)
				dp[j] += dp[j - 1];
		
		return dp[n-1];
	}
	
	// DP Memoization - TLE
	// Time: O(m*n), Space: O(m*n)
	private static int TotalPathsDP(int m, int n, int[,] dp)
	{
		if(m == 1 || n == 1)
			dp[m, n] = 1;
		
		if(dp[m, n] == 0)
			dp[m, n] = TotalPathsDP(m, n - 1, dp) + TotalPathsDP(m - 1, n, dp);
		
		return dp[m, n];
	}
	
	// Recursion - TLE
	// Time: O(2^n)
	private static int TotalPathsRecursive(int m, int n)
	{
		if(m == 1 || n == 1)
			return 1;
		
		return TotalPathsRecursive(m, n - 1) + TotalPathsRecursive(m - 1, n);
	}
}

// Sunny Bhawsar
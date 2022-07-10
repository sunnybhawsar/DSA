// https://leetcode.com/problems/climbing-stairs/

using System;
					
public class Program
{
	public static void Main()
	{
		// Each time you can either climb 1 or 2 steps. 
		// Ways can you climb to the nth stair?
		int ways = ClimbStairs(4);
		Console.WriteLine(ways);
	}
	
	private static int ClimbStairs(int n) 
	{
        int ways = 0;
		ways = NthFibonacciNumber(n + 1);
		return ways;
    }
	
	// O(n)
	private static int NthFibonacciNumber(int n)
	{
		if(n == 0)
			return 0;
		int a = 0, b = 1, c = 0;
		
		while(n-- > 1)
		{
			c = a + b;
			a = b;
			b = c;
		}
		
		return b;
	}
}

// Sunny Bhawsar
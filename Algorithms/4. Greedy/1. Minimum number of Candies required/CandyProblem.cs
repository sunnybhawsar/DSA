// https://leetcode.com/problems/candy/

using System;
					
public class Program
{
	public static void Main()
	{
		// Each child must get at least one candy.
		// Children with a higher rating get more candies than their neighbors.
		// Find minmum number of candies required.
		
		int[] ratings = {1, 0, 2};
		Console.WriteLine(MinNumberOfCandies(ratings));
	}
	
	// Time O(n) , Space O(n)
	private static int MinNumberOfCandies(int[] ratings) {
        if(ratings == null || ratings.Length <= 0)
            return 0;
        
        int n = ratings.Length, result = 0;
        if(n == 1)
            return 1;
        
        int[] leftToRight = new int[n];
        Array.Fill(leftToRight, 1);
        int[] rightToLeft = new int[n];
        Array.Fill(rightToLeft, 1);
        
        for(int i = 1; i < n; i++)
        {
            if(ratings[i] > ratings[i - 1])
                leftToRight[i] = leftToRight[i - 1] + 1;
        }
        
        for(int i = n - 2; i >= 0; i--)
        {
            if(ratings[i] > ratings[i + 1])
                rightToLeft[i] = rightToLeft[i + 1] + 1;
        }
        
        for(int i = 0; i < n; i++)
            result += Math.Max(leftToRight[i], rightToLeft[i]);
        
        return result;
    }
}

// Sunny Bhawsar
// Assign 1 candy to all and then divide problem into 2 sub-problems
	// LeftToRight compare with left and assign left + 1 candies if higher rating
	// RightToLeft compare with right and assign right + 1 candies if higher rating
	// Then consider Max of LeftToRight & RightToLeft to satisfy neibhor condition
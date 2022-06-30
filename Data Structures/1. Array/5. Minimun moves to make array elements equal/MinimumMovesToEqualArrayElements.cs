// https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/
// Moves can be +1 or -1

using System;
					
public class Program
{
	public static void Main()
	{
		int[] nums = {1, 10, 2, 9};
		// After making moves {9, 9, 9, 9}
		Console.WriteLine(MinMovesOptimized(nums));
	}
	
	// O(n log n)
	private static int MinMovesOptimized(int[] nums) 
	{
        int minMoves = 0;
		if(nums == null || nums.Length <= 1)
			return minMoves;		
		
		Array.Sort(nums);
		int mid = nums[nums.Length / 2];
		
		for(int i = 0; i < nums.Length; i++)
			minMoves += Math.Abs(mid - nums[i]);
		
		return minMoves;
    }
	
	// O(n^2)
	private static int MinMovesBruteForce(int[] nums) 
	{
        int minMoves = Int32.MaxValue, moves = 0;
		if(nums == null || nums.Length <= 1)
			return minMoves;
		
		for(int i = 0; i < nums.Length; i++)
		{
			for(int j = 0; j < nums.Length; j++)
			{
				if(i != j)
				{
					moves += Math.Abs(nums[j] - nums[i]);
				}
			}
			
			minMoves = (moves < minMoves) ? moves : minMoves;
			moves = 0;
		}
		
		return minMoves;
    }
}

// Sunny Bhawsar
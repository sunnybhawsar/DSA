// https://leetcode.com/problems/longest-consecutive-sequence/

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		int[] nums = {0,3,7,2,5,8,4,6,0,1,1,2,2};
        
		Console.WriteLine(LongestConsecutive(nums));
	}
	
	// O(n)
	private static int LongestConsecutive(int[] nums) 
	{
        int result = 0, sequence = 0;
		
		// Fill unique elements in Hash
		HashSet<int> hash = new HashSet<int>();
		foreach(var num in nums)
			hash.Add(num);
		nums = hash.ToArray();
		
		for(int i = 0; i < nums.Length; i++)
		{
			// With the 1st element of longest subsequence
			if(!hash.Contains(nums[i] - 1))
			{
				sequence = nums[i];
				while(hash.Contains(sequence))
					sequence++;
				
				// Sequence will reach to the last element of longest subsequence
				result = Math.Max(result, sequence - nums[i]);
			}
		}
		
		return result;
    }
	
	// O(n log n)
	private static int LongestConsecutiveWithSorting(int[] nums) 
	{
        int result = 0, count = 0;
		
		// Remove duplicates from the Array
		HashSet<int> hash = new HashSet<int>();
		foreach(var num in nums)
			hash.Add(num);		
		nums = hash.ToArray();
		
		// Sort the array
		Array.Sort(nums);
		
		for(int i = 0; i < nums.Length; i++)
		{
            // Increase the count if diff is 1
			if(i > 0 && nums[i] == nums[i - 1] + 1)
				count++;
			else
				count = 1;
			
			result = Math.Max(result, count);
		}
		
		return result;
    }
}

// Sunny Bhawsar
// Approach 1:
	// O(n log n)
	// Remove duplicates & sort the array then iterate and increase counter if diff is 1
// Aoproach 2:
	// O(n)
	// Using hashing, with 1st element of longest subsequence reach to the last element then take max difference
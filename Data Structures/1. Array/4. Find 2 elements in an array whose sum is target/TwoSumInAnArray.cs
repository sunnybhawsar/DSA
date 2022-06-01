// Find indies of 2 elements in the array whose sum is target.
// https://leetcode.com/problems/two-sum/
using System;
using System.Collections.Generic;
					
public class Solution 
{
	public static void Main(string[] args)
	{
		int[] nums = new int[] {2, 3, 3, 3, 9, 1, 4, 7, 0, 4};
		int target = 9;
		
		var result = TwoSum(nums, target);
		foreach(var num in result)
		{
			Console.WriteLine($"{num} ");
		}
	}
	
    public static int[] TwoSum(int[] nums, int target) 
    {
        IDictionary<int, int> differ = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(differ.ContainsKey(nums[i]))
                return new int[] {differ[nums[i]], i};
            
            if(!differ.ContainsKey(target - nums[i]))
                differ.Add(target - nums[i], i);
        }
        
        return new int[] {0};
    }
}

// Sunny Bhawsar
// Approach:
    // Store difference of target and 1st element in a dictionary
    // Complexity: O(n)
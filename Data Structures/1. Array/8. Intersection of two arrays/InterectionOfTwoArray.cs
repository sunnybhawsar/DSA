// https://leetcode.com/problems/intersection-of-two-arrays/

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		int[] nums1 = {4,9,5};
		int[] nums2 = {9,4,9,8,4};
		
		int[] intersection = Intersection(nums1, nums2);
		foreach(var num in intersection)
			Console.Write(num + " ");
	}
	
	// O(n log n) - Sorting
	private static int[] Intersection(int[] nums1, int[] nums2) {
        IList<int> result = new List<int>();
        HashSet<int> hash = new HashSet<int>();
        
        // Removing duplicate elements using hash
        foreach(var num in nums1)
            hash.Add(num);
        nums1 = hash.ToArray();
        
        hash.Clear();
        foreach(var num in nums2)
            hash.Add(num);
        nums2 = hash.ToArray();
        
        // Sort the arrays
        Array.Sort(nums1);
        Array.Sort(nums2);
        
        AddIntersectElements(ref result, nums1, nums2, nums1.Length, nums2.Length);
        
        return result.ToArray();
    }
    
	// O(n1 + n2) - Two Pointers
    private static void AddIntersectElements(ref IList<int> result, int[] nums1, int[] nums2, int n1, int n2)
    {
        int i = 0, j = 0;
        
        while(i < n1 && j < n2)
        {
            if(nums1[i] == nums2[j])
            {
                result.Add(nums1[i]);
                i++;
                j++;
            }
            else if(nums1[i] < nums2[j])
                i++;
            else if(nums2[j] < nums1[i])
                j++;
        }
    }
}

// Sunny Bhawsar
// If both arrays are already sorted then O(n1 + n2) else O(n log n)
// #Sorting, #Hashing, #2 Pointers
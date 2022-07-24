/*
    Given two arrays of int, output elements that is unique to one of them
    Input : [3 4 2 3 4] [3 6 3 2 1 1]
    
    Output: [4 6 1]

    2, 3, 4
    1, 2, 3, 6
*/

using System;
using System.Collections.Generic;
using System.Linq;
class Solution 
{	
    static void Main(String[] args) 
	{
        int[] arr = {3, 4, 2, 3, 4};
        int[] brr = {3, 6, 3, 2, 1, 1};
        IList<int> result = new List<int>();
        
		// Remove duplicates elements
        HashSet<int> hash = new HashSet<int>();
        foreach(var a in arr)
            hash.Add(a);            
        arr = hash.ToArray();
        
        hash.Clear();
        foreach(var b in brr)
            hash.Add(b);            
        brr = hash.ToArray();        
        
		// Sort both the arrays
        Array.Sort(arr);
        Array.Sort(brr);
        
		// Approach #1 - Binary search each element of an array into another, add to result if not found
		// O (n log n) where n is length of big array
        foreach(var a in arr)
        {
            if(!IsFound(a, brr))
                result.Add(a);
        }        
        foreach(var b in brr)
        {
            if(!IsFound(b, arr))
                result.Add(b);
        }             
		Console.WriteLine("Using Binary Search:");
        Print(result);   	
		
		result.Clear();
		
		// Approach #2 - As arrays are sorted so we can compare elements using 2 pointers, add small one skip same
		// O(n1 + n2)
		AddUnCommonElements(ref result, arr, brr, arr.Length, brr.Length);
		Console.WriteLine("\nUsing 2 Pointers:");
		Print(result);
    }
    
	// Time: O(n1 + n2) & Space: O(1)
	private static void AddUnCommonElements(ref IList<int> result, int[] arr, int[] brr, int n1, int n2)
	{
		int i = 0, j = 0;
		
		while(i < n1 && j < n2)
		{
			if(arr[i] < brr[j])
				result.Add(arr[i++]);
			else if(brr[j] < arr[i])
				result.Add(brr[j++]);
			else
			{
				// Skipping common elements
				i++;
				j++;
			}
		}
		
		// Adding remaining elements of both arrays if left
		while(i < n1)
			result.Add(arr[i++]);
		
		while(j < n2)
			result.Add(brr[j++]);
	}
	
	// Binary Search O(log n)
    private static bool IsFound(int num, int[] crr)
    {
        int start = 0, end = crr.Length - 1;
        while(start <= end)
        {
			int mid = start + (end - start) / 2;
			
			if(crr[mid] == num)
				return true;
			
            if(crr[mid] < num)
				start = mid + 1;
			else
				end = mid - 1;				
        }
        
        return false;
    }
    
    private static void Print(IList<int> result)
    {
        foreach(var res in result)
            Console.Write(res + " ");
    }
}    

// Sunny Bhawsar #Qualcomm
// If Arrays are sorted then O(n1 + n2) else O(n log n)
	// Approach #1 - Binary search each element of an array into another, add to result if not found
	// O (n log n) where n is length of big array
	
	// Approach #2 - As arrays are sorted so we can compare elements using 2 pointers, add small one skip same
	// O(n1 + n2)
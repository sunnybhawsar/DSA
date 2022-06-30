// Number of elements that can be removed to make Array size at least half or less

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		int[] arr = {3,3,3,3,5,5,5,2,2,7};
		Console.WriteLine(MinSetSize(arr));
	}
	
	// O(n log n) to sort the Dictionary
	private static int MinSetSize(int[] arr) {
        if(arr == null || arr.Length <= 0)
            return 0;
        
        IDictionary<int, int> numCounts = new Dictionary<int, int>();
        int setSize = 0, minSetSize = 0;
        
        foreach(var num in arr)
        {
            if(numCounts.ContainsKey(num))
                numCounts[num]++;
            else
                numCounts.Add(num, 1);
        }
        
        var orderedCounts = numCounts.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                
        foreach(var num in orderedCounts.Keys)
        {
            setSize += orderedCounts[num];
            minSetSize++;
            
            if(setSize >= arr.Length / 2)
                break;
        }
        
        return minSetSize;   
    }
}

// Sunny Bhawsar
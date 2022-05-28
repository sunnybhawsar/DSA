// Problem - https://leetcode.com/problems/find-all-anagrams-in-a-string/

using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		var results = FindAnagrams("cbaebabacd", "abc");
		
		foreach(var result in results)
		{
			Console.Write(result + " ");
		}		
	}
	
    private static IList<int> FindAnagrams(string s, string p) {
        List<int> result = new List<int>();
        int[] freq1 = new int[28], freq2 = new int[28];
        
        if(s == p)
        {
            result.Add(0);
            return result;
        }
        
        int index;
        for (index = 0; index < p.Length; index++)
        {
            freq1[p[index] - 'a']++;
        }
        
        for(index = 0; index < s.Length; index++)
        {
            freq2[s[index] - 'a']++;
            
            if(index - p.Length >= 0)
                freq2[s[index - p.Length] - 'a']--;
            
            if(index >= p.Length - 1 &&  IsAnagram(freq1, freq2))
                result.Add(index - p.Length + 1);
        }        
        
        return result;        
    }
    
    private static bool IsAnagram(int[] freq1, int[] freq2)
    {
        for(int i = 0; i < freq1.Length; i++)
        {
            if(freq1[i] != freq2[i])
                return false;
        }
        
        return true;
    }
}

// Sunny Bhawsar

// Approach 1:
	// Using Dictionary - O(n^2)
	
// Approach 2:
	// Using Sliding Window Technique - O(n)
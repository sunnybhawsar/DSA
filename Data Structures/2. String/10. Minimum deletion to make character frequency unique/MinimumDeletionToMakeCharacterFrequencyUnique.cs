// https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		string s = "aaabbbcc";
		// After deletion string should become "aaabbc"
		Console.WriteLine(MinDeletions(s));
	}
	
	// O(n)
	private static int MinDeletions(string s) {
        int[] freq = new int[26];
        HashSet<int> hash = new HashSet<int>();
        int minDeletion = 0;
        
        foreach(var c in s)
            freq[c - 'a']++;
        
        freq = freq.OrderByDescending(x => x).ToArray();
        
        for(int i = 0; i < freq.Length; i++)
        {
			while(hash.Contains(freq[i]) && freq[i] > 0)
			{                        
				freq[i]--;
				minDeletion++;
			}

			hash.Add(freq[i]);
        }
        
        return minDeletion;
    }
}

// Sunny Bhawsar
// Probelm - https://leetcode.com/problems/permutation-in-string/

using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(CheckInclusion("ab", "dbcab"));
	}

    public static bool CheckInclusion(string s1, string s2) {
        int[] freq1 = new int[26];
        int[] freq2 = new int[26];
        int windowStart = 0;
        for(int i=0;i<s1.Length;i++)
        {
            freq1[s1[i]-'a']++;
        }
        
        for(int i=0;i<s2.Length;i++)
        {
            freq2[s2[i]-'a']++;
            if(i-windowStart+1 > s1.Length) 
            {
                freq2[s2[windowStart++]-'a']--;
            }
            
            if(i-windowStart+1==s1.Length && IsAnagram(freq1,freq2)) return true;
        }
        
        return false;
    }
    
    private static bool IsAnagram(int[] arr1, int[] arr2)
    {
        for(int i=0;i<arr1.Length;i++)
        {
            if(arr1[i] != arr2[i]) return false;
        }
        return true;
    }
}

// Sunny Bhawsar

// Approach 1:
    // Store all permutations of string in list and check contains
    // Complexity: O(n * n!)

// Approach 2:
    // Sliding Window
    // Complexity: O(n)
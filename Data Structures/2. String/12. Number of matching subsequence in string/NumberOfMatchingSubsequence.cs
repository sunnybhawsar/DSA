// https://leetcode.com/problems/number-of-matching-subsequences/

using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		string s = "abcde";
		string[] words = {"a","bb","acd","ace"};
			
		Console.WriteLine(NumMatchingSubseq(s, words));
	}
	
	// O(m*n) where m is length of s & n is length of word
	private static int NumMatchingSubseq(string s, string[] words) {
        int count = 0;
        IDictionary<string, int> wordCount = new Dictionary<string, int>();
        
        foreach(var word in words)
        {
            if(wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount.Add(word, 1);
        }
        
        foreach(var word in wordCount.Keys)
        {
            if(IsSubsequence(s, word))
                count += wordCount[word];
        }
        
        return count;
    }    
    private static bool IsSubsequence(string s1, string s2)
    {
        if(s2.Length > s1.Length)
            return false;
        else if(s2.Length == 0)
            return true;
        
        int i = 0, j = 0;
        
        while(true)
        {
            if(j == s2.Length)
                return true;
            
            if(i == s1.Length)
                return false;
            
            if(s1[i] == s2[j])
            {
                i++;
                j++;
                continue;
            }
            
            i++;
        }
        
        return false;
    }
	
	// Time limit exceeded
	private static int NumMatchingSubseqAll(string s, string[] words) {
        int count = 0;
        
        foreach(var word in words)
            if(IsSubsequenceAll(s, word))
                count++;
        
        return count;
    }    
    private static bool IsSubsequenceAll(string s1, string s2)
    {
        int i = 0, j = 0;
        
        while(i < s1.Length && j < s2.Length)
            if(s1[i++] == s2[j])
                j++;
        
        return j == s2.Length;
    }
}

// Sunny Bhawsar
// #2 Pointers
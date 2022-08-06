// https://leetcode.com/problems/concatenated-words/

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		string[] words = {"cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"};
		
		IList<string> result = FindAllConcatenatedWordsInADict(words);		
		Print(result);
	}
	
	// Time: O(n log n + n * m^2), Space: O(n)  where n is the length of words array and m is length of the word
	private static IList<string> FindAllConcatenatedWordsInADict(string[] words) 
	{        
        List<string> result = new List<string>();
        if(words == null || words.Length == 0)
            return result;
      
        HashSet<string> wordSet = new HashSet<string>();
        //Array.Sort(words, (a,b) => a.Length - b.Length);
		words = words.OrderBy(x => x.Length).ToArray();
		
        foreach(var word in words)
        {
            if(IsConcatenated(word, wordSet))
                result.Add(word);
            
            wordSet.Add(word);
        }
        
        return result;
    }
    
	// Time: O(m^2), Space: O(m)  where m is the length of the word
    private static bool IsConcatenated(string word, HashSet<string> wordSet)
    {
        if(wordSet.Count == 0)
            return false;
        
        bool[] dp = new bool[word.Length + 1];
        dp[0] = true;
        
        // check substrings starting with length 1 for current word
        for(int i = 1; i <= word.Length; i++)
        {
            // check if the substring is concatenated
            // divide the substring into 2 parts, the 1st part has length j
            for(int j = 0; j < i; j++)
            {                
                if(dp[j] && wordSet.Contains(word.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        
        return dp[word.Length];
    }
	
	private static void Print(IList<string> result)
	{
		foreach(var res in result)
			Console.Write(res + " ");
	}
}

// Sunny Bhawsar #Amazon
// #DP #Hashing #Substring
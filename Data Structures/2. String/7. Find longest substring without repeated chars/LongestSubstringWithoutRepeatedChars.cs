using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		string str = "abcabcdde";
		Console.WriteLine(LongestSubstringBruitForce(str));
		
		Console.WriteLine(LengthOfLongestSubstring(str));
	}
	
	// O(n^2)
	private static string LongestSubstringBruitForce(string s)
	{
		string result = string.Empty;
		char[] arr = s.ToCharArray();
		IList<string> list = new List<string>();
		
		for(int i = 0; i < arr.Length; i++)
		{
			result = $"{arr[i]}";
			for(int j = i + 1; j < arr.Length; j++)
			{							
				if(result.Contains(arr[j]))
				{
					list.Add(result);
					break;
				}
				else if(!result.Contains(arr[j]))
				{
					result += $"{arr[j]}";
				}	
			}
		}
		
		result = list.OrderBy(x => x.Length).ToList().LastOrDefault();		
		return result;
	}
	
	// O(n)
    private static int LengthOfLongestSubstring(string s) {
        if(string.IsNullOrEmpty(s))
            return 0;
        
        int result = 0, start = 0;
        IDictionary<char, int> visited = new Dictionary<char, int>();
        
        for(int end = 0; end < s.Length; end++)
        {
            if(visited.ContainsKey(s[end]))
            {
                start = Math.Max(start, visited[s[end]] + 1);
            }
            
            visited[s[end]] = end;
            result = Math.Max(result, end-start + 1);
        }
        
        return result;
    }
}
using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		string str = "mystiflyconsulting";
		
		Console.WriteLine(GetOrderedString(str));
	}
	
	private static string GetOrderedString(string str)
	{
		string result = string.Empty;
		IDictionary<char, int> chars = new Dictionary<char, int>(28);
		
		foreach(var c in str)
		{
			if(chars.ContainsKey(c))
				chars[c] += 1;
			else
				chars.Add(c, 1);
		}
		
		foreach (var key in chars.Keys)
		{
			for(int i = 0; i < chars[key]; i++)
				result += key;
		}
		
		return result;
	}
}

// Sunny Bhawsar

// Approach
    // Using Dictionary of alphabets
    // Complexity: O(n) where n is length of given string
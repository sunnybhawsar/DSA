using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		string str = "sunnybunny";
		Console.WriteLine($"Removed repeated chars: {RemoveRepeatedChars(str)}");
		Console.WriteLine($"Consider repeated chars only once: {ConsiderRepeatedCharsOnlyOnce(str)}");
	}
	
	//O(n)
	private static string RemoveRepeatedChars(string str)
	{
		string result = string.Empty;
		IDictionary<char, int> visited = new Dictionary<char, int>();
		
		for(int i = 0; i < str.Length; i++)
		{
			if(!visited.ContainsKey(str[i]))
				visited.Add(str[i], 1);
			else
				visited[str[i]]++;
		}
		
		foreach(var key in visited.Keys)
		{
			if(visited[key] > 0 && visited[key] <= 1)
				result += key;
		}
		
		return result;
	}
	
	// O(n)
	private static string ConsiderRepeatedCharsOnlyOnce(string str)
	{
		string result = string.Empty;
		IDictionary<char, int> visited = new Dictionary<char, int>();
		
		for(int i = 0; i < str.Length; i++)
		{
			if(!visited.ContainsKey(str[i]))
			{
				visited.Add(str[i], 1);
				result += str[i];
			}
		}
		
		return result;
	}
}
using System;
					
public class Program
{
	public static void Main()
	{
		string str = "aabbebbaa";
		bool result = true;
		
		int start = 0;
		int end = str.Length - 1;
		
		while(start < end)
		{
			if(str[start] != str[end])
				result = false;
			
			start++;
			end--;
		}
		
		Console.WriteLine(result);
	}
}

// Sunny Bhawsar

// Approach:
    // 2 pointer
    // Complexity: n/2 i.e O(n) where n is length of string
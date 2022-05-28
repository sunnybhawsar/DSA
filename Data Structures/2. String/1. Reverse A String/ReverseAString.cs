//Problem - https://leetcode.com/problems/reverse-string/

using System;
					
public class Program
{
	public static void Main()
	{
		string str = "SunnyBhawsar";
		char[] crr = str.ToCharArray();
		
		int start = 0;
		int end = str.Length - 1;
		
		while(start < end)
		{
			char temp = crr[start];
			crr[start] = crr[end];
			crr[end] = temp;
			start++;
			end--;
		}
		
		Console.WriteLine(new String(crr));
	}
}

// Sunny Bhawsar

// Approach:
    // 2 Pointer 
    // Complexity: n/2 i.e O(n) where n is length of string.
using System;
					
public class Program
{
	public static void Main()
	{
		string str = "ABC";
		PrintAnagramsUsingRecursion(str, 0, str.Length - 1);
		//PrintAnagramsUsingBackTracking(str, "");
	}
    
	// Using Recurstion Algorithm:
	private static void PrintAnagramsUsingRecursion(string str, int start, int end)
	{
		if(start == end)
		{
			Console.WriteLine($"{str} ");
			return;
		}
		
		for(int i = start; i <= end; i++)
		{
			str = Swap(str, start, i);
			PrintAnagramsUsingRecursion(str, start + 1, end);
		}
	}
	
	private static string Swap(string str, int start, int end)
	{
		char[] crr = str.ToCharArray();
		var temp = str[start];
		crr[start] = crr[end];
		crr[end] = temp;
	
		return new String(crr);		
	}

    // Using Backtracking Algorithm:
	private static void PrintAnagramsUsingBackTracking(string str, string answer)
	{
		if(str.Length == 0)
		{
			Console.WriteLine(answer);
			return;
		}
		
		for(int i = 0; i < str.Length; i++)
		{
			char ch = str[i];
			string left = str.Substring(0, i);
			string right = str.Substring(i + 1);
			string combine = left + right;
			//Console.WriteLine($"{i}- Left:{left} Right:{right} Combine:{combine} Answer: {answer + ch}");
			PrintAnagramsUsingBackTracking(combine, answer + ch);
		}
	}		
}

// Sunny Bhawsar

// Approach 1:
    // Using Recursion
    // Complexity: O(n * n!) where n is length of given string

// Approach 2:
    // Using Backtracking
    // Complexity: O(n * n!) where n is length of given string
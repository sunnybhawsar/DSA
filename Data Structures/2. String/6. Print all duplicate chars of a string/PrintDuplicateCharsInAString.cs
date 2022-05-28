using System;
					
public class Program
{
	public static void Main()
	{
		string str = "isunnybhawsar";
		PrintDuplicates(str);		
	}
	
	private static void PrintDuplicates(string str)
	{
		int[] arr = new int[256];
		
		foreach(var c in str)
		{
			arr[c]++;
		}
		
		for(int i = 0; i < arr.Length; i++)
		{
			if(arr[i] > 1)
				Console.WriteLine((char) i);
		}
	}
}

// Sunny Bhawsar

// Approach;
    // Storing char count in array of alphabet char size
    // Complexity: O(n) where n is length of given string
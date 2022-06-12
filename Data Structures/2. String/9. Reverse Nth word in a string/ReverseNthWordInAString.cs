using System;
					
public class Program
{
	public static void Main()
	{
		string str = "This is Sunny Bhawsar";
		Console.WriteLine(ReverseNthWord(str, 3));
	}
	
    // O(n) where n is the length of nth word
	private static string ReverseNthWord(string str, int pos)
	{		
		var parts = str.Split(" ");
		if(pos >= parts.Length)
			return str;
		
		var toReverse = parts[pos - 1];
		char[] crr = toReverse.ToCharArray();
		int start = 0, end = crr.Length - 1;
		
		while(start < end)
		{
			char temp = crr[start];
			crr[start] = crr[end];
			crr[end] = temp;
			start++;
			end--;
		}
		
		toReverse = new String(crr);
		
		str = str.Replace(parts[pos - 1], toReverse);
		return str;
	}
}
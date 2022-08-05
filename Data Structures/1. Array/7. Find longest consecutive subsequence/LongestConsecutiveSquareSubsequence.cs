// https://leetcode.com/discuss/interview-question/2370795/Amazon-Interview-Question

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		List<int> riceBags = new List<int>() {3,9,4,2,16};
		Console.WriteLine(MaxSetSize(riceBags));
	}
	
	// O(n)
	private static int MaxSetSize(List<int> riceBags)
	{
		int result = -1, square = 0, counter = 0;
		
		for(int i = 0; i < riceBags.Count; i++)
		{
			if(!riceBags.Contains(riceBags[i] / 2))
			{
				counter = 0;
				square = riceBags[i];
				while(riceBags.Contains(square))
				{
					square *= square;
					counter++;
				}				
			}
			
			if(counter > 1)
				result = Math.Max(result, counter);
		}
		
		return result;
	}
}

// Sunny Bhawsar #Amazon
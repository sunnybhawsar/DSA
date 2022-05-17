// Problem:
    // Find Mininum and Maximum element in Array with/without sorting the array

using System;

public class Program
{
	private class MinAndMax
	{
		public int min {get; set;}
		public int max {get; set;}
	}
	
	private static MinAndMax _minAndMax;
	static Program()
	{
		_minAndMax = new MinAndMax();
	}
	
	public static void Main(string[] args)
	{
		int[] arr = new int[] {3, 55, 601, -4, 79, 99, 105, -7, 999, -8, 1, 10};
		
		MinAndMaxThruCompareInPairs(arr);
		
		Console.WriteLine("Min: "+ _minAndMax.min + ", Max: "+ _minAndMax.max);
	}
	
	private static void MinAndMaxThruCompareInPairs(int[] arr)
	{
		int i = 0;
		
		if(arr.Length % 2 == 0)
		{
			if(arr[0] < arr[1])
			{
				_minAndMax.min = arr[0];
				_minAndMax.max = arr[1];
			}
			else
			{
				_minAndMax.min = arr[1];
				_minAndMax.max = arr[2];
			}
			
			i = 2;
		}
		else
		{
			_minAndMax.min = arr[0];
			_minAndMax.max = arr[0];
			
			i = 1;
		}
		
		while(i < arr.Length)
		{
			if(arr[i] > arr[i+1])
			{
				if(arr[i] > _minAndMax.max)
				{
					_minAndMax.max = arr[i];
				}
				if(arr[i+1] < _minAndMax.min)
				{
					_minAndMax.min = arr[i+1];
				}
			}
			else
			{
				if(arr[i+1] > _minAndMax.max)
				{
					_minAndMax.max = arr[i+1];
				}
				if(arr[i] < _minAndMax.min)
				{
					_minAndMax.min = arr[i];
				}
			}
			
			i += 2;
		}
	}
}

// Sunny Bhawsar
// Logic 1:
    // Linear Search - O(n)
// Logic 2:
    // Divide & Conquer - O(n)
// Logic 3:
    // Compare in pairs - O(n)
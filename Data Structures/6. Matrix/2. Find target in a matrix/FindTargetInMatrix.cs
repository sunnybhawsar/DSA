using System;
					
public class Program
{
	public static void Main(string[] args)
	{
		// Given m x n matrix whose rows & columns are sorted in ascending order
		int[][] matrix = { new int[] { 1, 4, 7, 11, 15 }, new int[] { 2, 5, 8, 12, 19 }, new int[] { 3, 6, 9, 16, 22 },
						  new int[] { 10, 13, 14, 17, 24 }, new int[] { 18, 21, 23, 26, 30 } };
		int target = 20;

		Console.WriteLine(IsFound(matrix, target));
	}

	// O(m log n) for m x n matrix
	private static bool IsFound(int[][] matrix, int target)
	{
		bool isFound = false;

		for(int i = 0; i < matrix.GetLength(0); i++)
		{
			if (isFound || matrix[i][0] == target)
				return true;
			else if (matrix[i][0] < target)
				isFound = BinarySearch(matrix[i], target);
			else
				break;
		}

		return isFound;
	}

	// O(log n) where n is the length of the array (arr)
	private static bool BinarySearch(int[] arr, int target)
	{
		int start = 0, end = arr.Length - 1;
		while (start < end)
		{
			int mid = start + (end - start)/2 + 1;

			if (target == arr[mid])
				return true;

			if(target > arr[mid])
				start = mid + 1;                    
			else
				end = mid - 1;                
		}

		return false;
	}
}

// Sunny Bhawsar #Qapita
// Problem:
    // Sort the given array

using System;

class Solution
{
    public static void Main(string[] args)
    {
        int[] arr = new int[] {2, 4, 1, 7, 9, 3, 5};

        Array.Sort(arr);

        PrintArray(arr);
    }

    private static void PrintArray(int[] arr)
    {
        Array.ForEach<int>(arr, a => Console.Write(a + " "));
    }
}

// Sunny Bhawsar

// Using Sort function of Array class
// Complexity: O(n log n)

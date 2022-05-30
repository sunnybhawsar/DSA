// Problem:
    // Reverse the given array
	// https://www.geeksforgeeks.org/write-a-program-to-reverse-an-array-or-string/

using System;
class Solution
{
    public static void Main(string[] args)
    {
        int [] arr = {1, 2, 3, 4, 5, 6, 7};

        ReverseAnArray(arr);
        PrintArray(arr);
    }

    private static void ReverseAnArray(int[] arr)
    {
        int start = 0;
        int end = arr.Length - 1;
        int temp = 0;

        while(start < end)
        {
            temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }        
    }

    private static void ReverseAnArrayWithRecursion(int[] arr, int start, int end)
    {
        if(start >= end)
        return;

        int temp = 0;
        temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;
        ReverseAnArrayWithRecursion(arr, start+1, end-1);
    }

    private static void PrintArray(int[] arr)
    {
        foreach(var a in arr)
        {
            Console.Write(a + " ");
        }
    }
}

// Sunny Bhawsar
// Logic:
    // 2 Pointer
// Complexity: 
    // If length of array is odd then  O(n-1/2)
    // If length of array is even then O(n/2)
    // To Print - O(n)

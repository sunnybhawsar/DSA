using System;

public class Solution
{
    public static void Main(string[] args)
    {
        string s = "abcdef";
        int leftShifts = 10, rightShifts = 8;

        string result = GetShiftedString(s, leftShifts, rightShifts);
		Console.WriteLine(result);
    }
	
	// O(n)
	public static string GetShiftedString(string s, int leftShifts, int rightShifts)
    {
        if(leftShifts == rightShifts)
            return s;
        
        int diff = leftShifts - rightShifts;
        bool isLeft = diff > 0;
		diff = Math.Abs(diff);
		
		if(diff % s.Length == 0)
			return s;
		else
			diff = diff % s.Length;
		       
        return isLeft ? LeftShift(s, diff) : LeftShift(s, s.Length - diff);          
    }
    
	// Can do both left and right shifts
	// (n) left shifts = (s.Length - n) right shifts
    private static string LeftShift(string s, int diff)
    {
        string part1 = s.Substring(0, diff);
        string part2 = s.Substring(diff);
        
        return part2 + part1;
    }
}

// Sunny Bhawsar #Qualcomm
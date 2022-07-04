// https://leetcode.com/problems/spiral-matrix/

using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		int[][] matrix = {new int[] {1,2,3,4}, new int[] {5,6,7,8}, new int[] {9,10,11,12}};
		var result = SpiralTraversal(matrix);
		
		foreach(var res in result)
			Console.Write($"{res} ");
	}
	
	// O(m * n)
	private static IList<int> SpiralTraversal(int[][] matrix) {
        IList<int> result = new List<int>();
        
        if(matrix == null || matrix.Length == 0)
            return result;
        
        int maxRow = matrix.Length;
        int maxCol = matrix[0].Length;
        
        int i = 0, row = 0, col = 0;
        
        while(row < maxRow && col < maxCol)
        {
            // #Move Left to Right and #Remove row from Top
            for(i = col; i < maxCol; i++)
                result.Add(matrix[row][i]);
            row++;
            
            // #Move Top to Down and #Remove col from Right
            for(i = row; i < maxRow; i++)
                result.Add(matrix[i][maxCol - 1]);
            maxCol--;
            
            // #Move Right to Left and #Remove row from Bottom
			if(row < maxRow)
			{
				for(i = maxCol - 1; i >= col; i--)
					result.Add(matrix[maxRow - 1][i]);
				maxRow--;
			}
            
            // #Move Down to Top and #Remove col from Left
			if(col < maxCol)
			{
				for(i = maxRow - 1; i >= row; i--)
					result.Add(matrix[i][col]);
				col++;         
			}
        }
        
        return result;
    }
}

// Sunny Bhawsar
// 4 Pointers, Loops (LeftToRight, TopToDown, RightToLeft, DownToTop)
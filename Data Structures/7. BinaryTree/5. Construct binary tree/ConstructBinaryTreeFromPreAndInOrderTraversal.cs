// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

using System;
using System.Collections.Generic;
					
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	
	public TreeNode(int val = 0)
	{
		this.val = val;
	}
}

public class Program
{
	public static void Main()
	{
		int[] preorder = {3,9,20,15,7};
		int[] inorder = {9,3,15,20,7};
		TreeNode root = BuildTree(preorder, inorder);
		
		LevelOrderTraversalWithSeparator(root);
	}
	
	public static TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = preorder.Length, pre = 0;
        return Build(preorder, inorder, ref pre, 0, n-1, n);
    }
    
    private static TreeNode Build(int[] preorder, int[] inorder, ref int pre, int inStart, int inEnd, int n)
    {
        // Base case
        if(pre >= n || inStart > inEnd)
            return null;
        
        // Creating node
        int element = preorder[pre++];
        TreeNode root = new TreeNode(element);
        int position = GetPositionOfElement(inorder, element, n);
        
        // Recursive calls
        root.left = Build(preorder, inorder, ref pre, inStart, position - 1, n);        
        root.right = Build(preorder, inorder, ref pre, position + 1, inEnd, n);
        
        return root;
    }
    
    // Can be optimized with the help of Dictionary of inorder nums and their postions (O(1))
    private static int GetPositionOfElement(int[] inorder, int element, int n)
    {
        for(int i = 0; i < n; i++)
            if(inorder[i] == element)
                return i;
        
        return -1;
    }
	
	// Insert null into quque as separator to move it to next line
    private static void LevelOrderTraversalWithSeparator(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        while(queue.Count > 0)
        {
            TreeNode temp = queue.Dequeue();

            if(temp == null)
            {
                if(queue.Count > 0)
                {
                    Console.WriteLine();
                    queue.Enqueue(null);
                }
            }
            else
            {
                Console.Write(temp.val + " ");                

                if(temp.left != null)
                    queue.Enqueue(temp.left);
                
                if(temp.right != null)
                    queue.Enqueue(temp.right);
            }
        }
    }
}

// Sunny Bhawsar
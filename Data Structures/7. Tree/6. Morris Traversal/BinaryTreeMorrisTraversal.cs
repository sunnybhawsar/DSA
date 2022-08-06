using System;
using System.Collections.Generic;
using System.Linq;
			
public class Node
{
	public int data;
	public Node left;
	public Node right;
	
	public Node(int data, Node left = null, Node right = null)
	{
		this.data = data;
		this.left = left;
		this.right = right;
	}
}

public class Program
{
	public static void Main()
	{
		Node root = BuildBinaryTree(null);		
		IList<int> result;
		
		result = MorrisTraversalInOrder(root);
		Console.WriteLine("Morris Traversal - In Order:");
		Print(result);
		
		result = MorrisTraversalPreOrder(root);
		Console.WriteLine("\n\nMorris Traversal - Pre Order:");
		Print(result);
		
		result = MorrisTraversalPostOrder(root);
		Console.WriteLine("\n\nMorris Traversal - Post Order:");
		Print(result);
	}
	
	// In-Order Traversal without recursion and without stack/queue
	// Time: O(n), Space: O(1)
	private static IList<int> MorrisTraversalInOrder(Node root)
	{
		IList<int> result = new List<int>();
		
		Node curr = root;
		Node pred = null;
		
		while(curr != null)
		{
			if(curr.left == null)
			{
				result.Add(curr.data);
				curr = curr.right;
			}
			else
			{
				pred = curr.left;
				while(pred.right != null && pred.right != curr)
					pred = pred.right;
				
				if(pred.right == null)
				{
					pred.right = curr;
					curr = curr.left;
				}
				else
				{
					pred.right = null;
					result.Add(curr.data);
					curr = curr.right;
				}
			}			
		}		
		
		return result;
	}
	
	// Pre-Order Traversal without recursion and without stack/queue
	// Time: O(n), Space: O(1)
	private static IList<int> MorrisTraversalPreOrder(Node root)
	{
		IList<int> result = new List<int>();
		
		Node curr = root;
		Node pred = null;
		
		while(curr != null)
		{
			if(curr.left == null)
			{
				result.Add(curr.data);
				curr = curr.right;
			}
			else
			{
				pred = curr.left;
				while(pred.right != null && pred.right != curr)
					pred = pred.right;
				
				if(pred.right == null)
				{
					result.Add(curr.data);
					pred.right = curr;
					curr = curr.left;
				}
				else
				{
					pred.right = null;
					curr = curr.right;
				}
			}			
		}		
		
		return result;
	}
	
	// Post-Order Traversal without recursion and without stack/queue
	// Time: O(n), Space: O(1)
	private static IList<int> MorrisTraversalPostOrder(Node root)
	{
		IList<int> result = new List<int>();
		
		Node curr = root;
		Node pred = null;
		
		while(curr != null)
		{
			if(curr.right == null)
			{
				result.Add(curr.data);
				curr = curr.left;
			}
			else
			{
				pred = curr.right;
				while(pred.left != null && pred.left != curr)
					pred = pred.left;
				
				if(pred.left == null)
				{
					result.Add(curr.data);
					pred.left = curr;
					curr = curr.right;
				}
				else
				{					
					pred.left = null;
					curr = curr.left;
				}
			}			
		}		
		
		// Adds the result in reverse order
		return result.Reverse().ToList();
	}
	
	// Build Binary Tree Manually
	private static Node BuildBinaryTree(Node root)
	{
		root = new Node(1);
        root.left = new Node(3);
        root.left.left = new Node(7);
        root.left.right = new Node(11);
        root.left.right.right = new Node(8);
        root.right = new Node(5);
        root.right.left = new Node(17);
        root.right.right = new Node(21);

        return root;
	}
	
	// Print
	private static void Print(IList<int> result)
	{
		foreach(var res in result)
			Console.Write(res + " ");
	}
}

// Sunny Bhawsar
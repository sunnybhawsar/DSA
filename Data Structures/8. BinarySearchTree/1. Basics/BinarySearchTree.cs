using System;
using System.Collections.Generic;

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
    public static void Main(string[] args)
    {
        int[] arr = {10, 7, 0, 11, 15, 9, 5, 1, 20, 13, 33, 2, 12};
        Node root = BuildBinarySearchTree(null, arr);

        Console.WriteLine("\nLevel Order Traversal: ");
        LevelOrderTraversalWithSeparator(root);

        Console.WriteLine("\nMin Value in BST: " + MinValue(root));
        Console.WriteLine("\nMax Value in BST: " + MaxValue(root));
    }

    #region Build BST

    // Input from console
    private static Node BuildBinarySearchTree(Node root)
    {
        int val = Convert.ToInt32(Console.ReadLine());
        while(val != -1)
        {
            root = InsertIntoBST(root, val);
            val = Convert.ToInt32(Console.ReadLine());
        }

        return root;
    }

    // Input from array
    private static Node BuildBinarySearchTree(Node root, int[] arr)
    {
        foreach(var val in arr)
            root = InsertIntoBST(root, val);

        return root;
    }

    // Insertion to Binary Search Tree
    // Time: O(log n)
    private static Node InsertIntoBST(Node root, int val)
    {
        if(root == null)
        {
            root = new Node(val);
            return root;
        }

        if(val > root.data)
        {
            // Right
            root.right = InsertIntoBST(root.right, val);
        }
        else
        {
            // Left
            root.left = InsertIntoBST(root.left, val);
        }

        return root;
    }

    #endregion Build BST

    #region Find Min & Max

    // O(h) where h is height of the tree
    private static int MinValue(Node root)
    {
        Node temp = root;
        while(temp.left != null)
            temp = temp.left;
        
        return temp.data;
    }

    // O(h) where h is height of the tree
    private static int MaxValue(Node root)
    {
        Node temp = root;
        while(temp.right != null)
            temp = temp.right;
        
        return temp.data;
    }

    #endregion Find Min & Max

    #region Traversal

    // O(n)
    private static void LevelOrderTraversalWithSeparator(Node root)
    {
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        q.Enqueue(null);

        Node curr = root;

        while(q.Count > 0)
        {
            curr = q.Dequeue();

            if(curr != null)
            {
                Console.Write(curr.data + " ");
                
                if(curr.left != null)
                    q.Enqueue(curr.left);
                
                if(curr.right != null)
                    q.Enqueue(curr.right);
            }
            else
            {
                if(q.Count > 0)
                {
                    Console.WriteLine();
                    q.Enqueue(null);
                }
            }
        }
    }

    #endregion Traversal
}

// Sunny Bhawsar
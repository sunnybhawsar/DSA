// Recursive Inplementation:

using System;
using System.Collections.Generic;

public class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int data)
    {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        Node root = null;

        root = BuildBinaryTree(root);

        Console.WriteLine("\n\nIn-Order Traversal:-");
        InOrderTraversal(root);

        Console.WriteLine("\n\nPre-Order Traversal:-");
        PreOrderTraversal(root);

        Console.WriteLine("\n\nPost-Order Traversal:-");
        PostOrderTraversal(root);
    }

    #region Build

    // Build the binary tree thru Console recusrively
    private static Node BuildBinaryTree(Node root)
    {
        Console.WriteLine("Enter data: ");
        int data = Convert.ToInt32(Console.ReadLine());
        root = new Node(data);

        if(data == -1)
            return null;
        
        Console.WriteLine("\n#Enter data to insert in left of " + data + ": ");
        root.left = BuildBinaryTree(root.left);

        Console.WriteLine("\n#Enter data to insert in right of " + data + ": ");
        root.right = BuildBinaryTree(root.right);

        return root;
    }
    
    #endregion Build

    #region In, Pre, Post - Order

    // Left Node Right (LNR)
    private static void InOrderTraversal(Node root)
    {
        if(root == null)
            return;

        InOrderTraversal(root.left);
        Console.Write(root.data + " ");
        InOrderTraversal(root.right);
    }

    // Node Left Right (NLR)
    private static void PreOrderTraversal(Node root)
    {
        if(root == null)
            return;

        Console.Write(root.data + " ");
        PreOrderTraversal(root.left);        
        PreOrderTraversal(root.right);
    }

    // Left Right Node (LRN)
    private static void PostOrderTraversal(Node root)
    {
        if(root == null)
            return;

        PostOrderTraversal(root.left);        
        PostOrderTraversal(root.right);
        Console.Write(root.data + " ");
    }

    #endregion In, Pre, Post - Order
}


// Sunny Bhawsar

// Console Input:
/*
1
3
7
-1
-1
11
-1
-1
5
17
-1
-1
-1

*/
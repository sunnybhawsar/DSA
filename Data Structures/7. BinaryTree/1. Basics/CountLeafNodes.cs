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
        
        int count = 0;
        CountLeafNodes(root, ref count);
        Console.WriteLine("\n\nNumber of leaf nodes: " + count);
    }

    private static void CountLeafNodes(Node root, ref int count)
    {
        if(root == null)
            return;

        else if(root.left == null && root.right == null)
            count++;
        
        CountLeafNodes(root.left, ref count);
        CountLeafNodes(root.right, ref count);
    }

    // Build the binary tree manually
    private static Node BuildBinaryTree(Node root)
    {
        /*
        1
        3 5
        7 11 17
        8
        */
        root = new Node(1);
        root.left = new Node(3);
        root.left.left = new Node(7);
        root.left.right = new Node(11);
        root.left.right.right = new Node(8);
        root.right = new Node(5);
        root.right.left = new Node(17);
        
        return root;
    }
}

// Sunny Bhawsar
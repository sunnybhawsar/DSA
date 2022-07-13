// https://leetcode.com/problems/balanced-binary-tree/

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
    public static void Main(string[] g)
    {
        Node root= BuildBinaryTree(null);

        Console.WriteLine(IsHeightBalanced(root) ? "Tree is Balanced" : "Tree is not Balanced");
    }

    // If height difference of all left node & right node is not more than 1 then only Binary tree is height balanced
    private static bool IsHeightBalanced(Node node)
    {
        if(node == null)
            return true;

        int difference = Math.Abs(HeightOfTree(node.left) - HeightOfTree(node.right));
        if(difference <= 1 && IsHeightBalanced(node.left) && IsHeightBalanced(node.right))
            return true;

        return false;        
    }

    // Returns height of the tree at any node
    private static int HeightOfTree(Node node)
    {
        if(node == null)
            return 0;

        return Math.Max(HeightOfTree(node.left), HeightOfTree(node.right)) + 1;
    }

    // Build Binary Tree Manually
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
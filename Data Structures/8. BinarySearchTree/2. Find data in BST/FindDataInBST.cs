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
        int target = 9;

        Console.WriteLine(IsFoundInBSTRecursively(root, target) ? "Found" : "Not Found");

        Console.WriteLine(IsFoundInBSTIteratively(root, target) ? "Found" : "Not Found");
    }

    #region Search Target

    private static bool IsFoundInBSTRecursively(Node root, int target)
    {
        if(root == null)
            return false;
        
        if(root.data == target)
            return true;
        
        if(target > root.data)
        {
            // Check in right subtree
            return IsFoundInBSTRecursively(root.right, target);
        }
        else
        {
            // Check in left subtree
            return IsFoundInBSTRecursively(root.left, target);
        }
    }

    private static bool IsFoundInBSTIteratively(Node root, int target)
    {
        Node temp = root;

        while(temp != null)
        {
            if(temp.data == target)
                return true;

            if(target > temp.data)
                temp = temp.right;
            else
                temp = temp.left;            
        }

        return false;
    }

    #endregion Search Target

    #region Build BST

    // Build from array elements
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

}

// Sunny Bhawsar
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
        int target = 10;

        Console.WriteLine("\nBefore: ");
        LevelOrderTraversalWithSeparator(root);

        root = DeleteNode(root, target);

        Console.WriteLine("\n\nAfter: ");
        LevelOrderTraversalWithSeparator(root);
    }

    #region Deletion

    // Time: O(n) where is number of nodes
    private static Node DeleteNode(Node root, int target)
    {
        if(root == null)
            return root;
        
        if(target < root.data)
            root.left = DeleteNode(root.left, target);
        else if(target > root.data)
            root.right = DeleteNode(root.right, target);
        else
        {
            // 0 Child
            if(root.left == null && root.right == null)
            {
                root = null;
                return null;
            }

            // 1 Child
            else if(root.left != null && root.right == null)
            {
                Node temp = root.left;
                root = null;
                return temp;
            }
            else if(root.left == null && root.right != null)
            {
                Node temp = root.right;
                root = null;
                return temp;
            }

            // 2 Child
            else
            {
                // Make root either max of left subtree or min of right subtree then delete that node
                int min = MinValueInBST(root.right);
                root.data = min;
                root.right = DeleteNode(root.right, min);

                return root;
            }
        }

        return root;
    }

    #endregion Deletion

    #region Min

    private static int MinValueInBST(Node root)
    {
        Node temp = root;
        while(temp.left != null)
            temp = temp.left;

        return temp.data;
    }

    #endregion Min
    
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
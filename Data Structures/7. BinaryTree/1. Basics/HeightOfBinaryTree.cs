using System;

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
        Node root = null;
        root = BuildBinaryTree(root);

        Console.WriteLine("Height of tree : " + GetHeightOfBinaryTree(root));
    }

    // Height of tree at any node (Longest path till leaf)
    private static int GetHeightOfBinaryTree(Node node)
    {
        if(node == null)
            return 0;
        
        int lHeight = GetHeightOfBinaryTree(node.left);
        int rHeight = GetHeightOfBinaryTree(node.right);

        if(lHeight > rHeight)
            return lHeight + 1;
        else
            return rHeight + 1;
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
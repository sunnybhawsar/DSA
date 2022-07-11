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
        this.left = this.right = null;
    }
}

public class Solution
{
    public static void Main(string[] g)
    {
        Node root = BuildBinaryTree(null);
        
        Console.WriteLine("Diameter of tree: " + GetDiameterOfBinaryTree(root));
    }

    // Max number of nodes at any level - Use level order traversal
    private static int GetDiameterOfBinaryTree(Node root)
    {        
        Queue<Node> queue = new Queue<Node>();
        int diameter = 0, counter = 0;
        Node current = root;

        queue.Enqueue(root);
        queue.Enqueue(null);        

        while(queue.Count > 0)
        {
            current = queue.Dequeue();

            if(current == null)
            {
                counter = 0;
                if(queue.Count > 0)
                    queue.Enqueue(null);
            }                
            else
            {
                if(current.left != null)
                    queue.Enqueue(current.left);
                
                if(current.right != null)
                    queue.Enqueue(current.right);

                counter++;
            }

            diameter = Math.Max(diameter, counter);
        }

        return diameter;
    }

    // Build the binary tree manually
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
}
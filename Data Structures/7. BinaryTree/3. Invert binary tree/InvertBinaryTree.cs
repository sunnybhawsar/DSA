// https://leetcode.com/problems/invert-binary-tree/

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

        Console.WriteLine("\nBefore: ");
        PrintLevelOrder(root);

        InvertIteratively(root);

        //InvertRecursively(root);

        Console.WriteLine("\n\nAfter: ");
        PrintLevelOrder(root);

    }

    // O(n)
    // Level-order traversal with queue, swap left child with right for current node
    private static Node InvertIteratively(Node root)
    {
        if(root == null)
            return root;

        Queue<Node> q = new Queue<Node>();
        Node current = root, temp = null;
        q.Enqueue(root);

        while(q.Count > 0)
        {
            current = q.Dequeue();

            temp = current.left;
            current.left = current.right;
            current.right = temp;

            if(current.left != null)
                q.Enqueue(current.left);

            if(current.right != null)
                q.Enqueue(current.right);
        }

        return root;
    }

    // O(n)
    private static Node InvertRecursively(Node root)
    {
        if(root == null)
            return root;

        Node left = InvertRecursively(root.left);
        Node right = InvertRecursively(root.right);

        root.left = right;
        root.right = left;

        return root;
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

    // Insert null into quque as separator to move it to next line
    private static void PrintLevelOrder(Node root)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        while(queue.Count > 0)
        {
            Node temp = queue.Dequeue();

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
                Console.Write(temp.data + " ");                

                if(temp.left != null)
                    queue.Enqueue(temp.left);
                
                if(temp.right != null)
                    queue.Enqueue(temp.right);
            }
        }
    }
}

// Sunny Bhawsar
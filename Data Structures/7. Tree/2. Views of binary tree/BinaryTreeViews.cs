// https://leetcode.com/problems/binary-tree-right-side-view/

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
        IList<int> result = new List<int>();

        Console.WriteLine("Right side view: ");
        RightSideView(root, ref result);
        Print(result);
        result.Clear();
        
        Console.WriteLine("Left side view: ");
        LeftSideView(root, ref result);
        Print(result);
        result.Clear();
    }

    // O(n)
    // Using Level-order traversal with Stack & Queue
    // Add the node to the result which is just before separator
    private static IList<int> RightSideView(Node root, ref IList<int> result) 
    {               
        if(root == null)
            return result;
        
        Queue<Node> q = new Queue<Node>();
        Stack<Node> s = new Stack<Node>();
        Node current = root, temp = null;
        
        q.Enqueue(root);
        q.Enqueue(null);        
        
        while(q.Count > 0)
        {
            current = q.Dequeue();
            
            if(current != null)
            {
                s.Push(current);
                
                if(current.left != null)
                    q.Enqueue(current.left);
                
                if(current.right != null)
                    q.Enqueue(current.right);
            }
            else
            {
                temp = (Node) s.Pop();
                result.Add(temp.data);
                
                if(q.Count > 0)
                {
                    q.Enqueue(null);
                }
            }
        }
        
        return result;
    }

    // O(n)
    // Using Level-order traversal with Queue
    // Add the node to the result which is just after the separator
    private static IList<int> LeftSideView(Node root, ref IList<int> result)
    {
        if(root == null)
            return result;

        Queue<Node> q = new Queue<Node>();
        Node current = root, previous = null;
        
        q.Enqueue(null);
        q.Enqueue(root);

        while(q.Count > 0)
        {
            previous = current;
            current = q.Dequeue();

            if(current != null)
            {
                if(previous == null)
                {
                    result.Add(current.data);
                }

                if(current.left != null)
                    q.Enqueue(current.left);
                
                if(current.right != null)
                    q.Enqueue(current.right);
            }
            else
            {
                if(q.Count > 0)
                    q.Enqueue(null);
            }
        }

        return result;
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

    // Print
    private static void Print(IList<int> result)
    {
        foreach(var res in result)
            Console.Write(res + " ");
    }
}

// Sunny Bhawsar
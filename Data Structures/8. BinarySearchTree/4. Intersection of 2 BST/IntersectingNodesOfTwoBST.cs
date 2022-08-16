// Print common elements of two Binary Search Trees

using System;
using System.Collections.Generic;
using System.Linq;

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
        IList<int> result = new List<int>();

        Node root1 = null;
        Insert(ref root1, 5);
        Insert(ref root1, 1);
        Insert(ref root1, 10);
        Insert(ref root1, 0);
        Insert(ref root1, 4);
        Insert(ref root1, 7);
        Insert(ref root1, 9);

        Node root2 = null;
        Insert(ref root2, 10);
        Insert(ref root2, 7);
        Insert(ref root2, 20);
        Insert(ref root2, 4);
        Insert(ref root2, 9);

        IList<int> inOrder1 = new List<int>();
        InOrderTraversal(root1, ref inOrder1);
        Console.WriteLine("\n1st BST - InOrder: ");
        Print(inOrder1);

        IList<int> inOrder2 = new List<int>();
        InOrderTraversal(root2, ref inOrder2);
        Console.WriteLine("\n2nd BST - InOrder: ");
        Print(inOrder2);

        Console.WriteLine("\nCommon Elements: ");
        Intersection(inOrder1, inOrder2, ref result);
        Print(result);
    }

    // Approach: 1
    // Intersection of two in-order list/array
    // O(n + m)
    private static void Intersection(IList<int> inOrder1, IList<int> inOrder2, ref IList<int> result)
    {
        int ptr1 = 0, ptr2 = 0;

        while(ptr1 < inOrder1.Count && ptr2 < inOrder2.Count)
        {
            if(inOrder1[ptr1] == inOrder2[ptr2])
            {
                result.Add(inOrder1[ptr1]);
                ptr1++;
                ptr2++;
            }
            
            else if(inOrder1[ptr1] < inOrder2[ptr2])
                ptr1++;

            else
                ptr2++;
        }
    }

    private static void InOrderTraversal(Node root, ref IList<int> inOrder)
    {
        if(root == null)
            return;

        InOrderTraversal(root.left, ref inOrder);
        inOrder.Add(root.data);
        InOrderTraversal(root.right, ref inOrder);
    }
    
    private static Node Insert(ref Node root, int val)
    {
        if(root == null)
        {
            root = new Node(val);
            return root;
        }

        if(val > root.data)
            root.right = Insert(ref root.right, val);
        else
            root.left = Insert(ref root.left, val);

        return root;
    }

    private static void Print(IList<int> list)
    {
        foreach(var l in list)
            Console.Write(l + " ");
    }
}

// Sunny Bhawsar
// Approach: 1
    // In-order of BST is always sorted so 2 pointers can be used
    // Need to get Intersecting elements of two in-order list/array
    // O(n + m)
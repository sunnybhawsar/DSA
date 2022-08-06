// Iterative Implementation

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
        Node root = null;
        root = BuildBinaryTree(root);

        Console.WriteLine("\nLevel-Order Traversal:-");
        LevelOrderTraversalWithSeparator(root);

        Console.WriteLine("\n\nReverse-Level-Order Traversal:-");
        ReverseLevelOrderTraversalWithSeparator(root);

        Console.WriteLine("\n\nIn-Order Traversal:");
        InOrderTraversal(root);

        Console.WriteLine("\n\nPre-Order Traversal:");
        PreOrderTraversal(root);

        Console.WriteLine("\n\nPost-Order Traversal:");
        PostOrderTraversal(root);
    }

    #region Level Order

    // Insert node (left 1st then right) into queue then print when removed from queue
    private static void LevelOrderTraversal(Node root)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            Node temp = queue.Peek();
            Console.Write(temp.data + " ");
            queue.Dequeue();

            if(temp.left != null)
                queue.Enqueue(temp.left);
            
            if(temp.right != null)
                queue.Enqueue(temp.right);
        }
    }

    // Insert null into quque as separator to move it to next line
    private static void LevelOrderTraversalWithSeparator(Node root)
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

    // Insert node (right 1st then left) into queue and then push to stack when removed from queue
    private static void ReverseLevelOrderTraversal(Node root)
    {
        Queue<Node> queue = new Queue<Node>();
        Stack<Node> stack = new Stack<Node>();
        
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var temp = queue.Dequeue();
            if(temp != null)
                stack.Push(temp);

            if(temp.right != null)
                queue.Enqueue(temp.right);

            if(temp.left != null)
                queue.Enqueue(temp.left);
        }

        while(stack.Count > 0)
            Console.Write(((Node) stack.Pop()).data + " ");

    }
    
    // Insert null into quque as separator to move it to next line
    private static void ReverseLevelOrderTraversalWithSeparator(Node root)
    {
        Queue<Node> queue = new Queue<Node>();
        Stack<Node> stack = new Stack<Node>();
        
        queue.Enqueue(root);
        queue.Enqueue(null);

        while(queue.Count > 0)
        {
            var temp = queue.Dequeue();
            stack.Push(temp);

            if(temp != null)
            {
                if(temp.right != null)
                    queue.Enqueue(temp.right);

                if(temp.left != null)
                    queue.Enqueue(temp.left);
            }
            else
            {
                if(queue.Count > 0)
                    queue.Enqueue(null);
            }
        }

        stack.Pop();
        while(stack.Count > 0)
        {
            Node node = stack.Pop();

            if(node != null)
                Console.Write(node.data + " ");
            else
                Console.WriteLine();
        }
    }

    #endregion Level Order

    #region In, Pre, Post - Order

    // Left Node Right (Iterative) - Use Stack
    private static void InOrderTraversal(Node root)
    {
        Stack<Node> stack = new Stack<Node>();
        Node current = root;

        while(true)
        {
            if(current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            else
            {
                if(stack.Count > 0)
                {
                    current = stack.Pop();
                    Console.Write(current.data + " ");
                    current = current.right;
                }
                else
                    break;
            }
        }
    }

    // Node Left Right (Iterative) - Use Stack
    private static void PreOrderTraversal(Node root)
    {
        Stack<Node> stack = new Stack<Node>();
        stack.Push(root);
        Node current = root;

        while(stack.Count > 0)
        {
            current = stack.Pop();
            Console.Write(current.data + " ");

            if(current.right != null)
                    stack.Push(current.right);

            if(current.left != null)
                    stack.Push(current.left);
        }
    }

    // Left Right Node (Iterative) - Use Stack
    private static void PostOrderTraversal(Node root)
    {
        Stack<Node> stack = new Stack<Node>();
        while(true)
        {
            while(root != null)
            {
                stack.Push(root);
                stack.Push(root);
                root = root.left;
            }
        
            // Check for empty stack
            if(stack.Count == 0) 
                return;
            root = stack.Pop();     

            if(stack.Count != 0 && stack.Peek() == root) 
            {
                root = root.right;         
            }  
            else
            {              
                Console.Write(root.data + " "); root = null;
            }
        }
    }

    #endregion In, Pre, Post - Order

    #region Build

    // Build the binary tree manually
    private static Node BuildBinaryTree(Node root)
    {
        /*
        1
        3 5
        7 11 17
        */
        root = new Node(1);
        root.left = new Node(3);
        root.left.left = new Node(7);
        root.left.right = new Node(11);
        root.right = new Node(5);
        root.right.left = new Node(17);
        
        return root;
    }

    #endregion Build
}

// Sunny Bhawsar
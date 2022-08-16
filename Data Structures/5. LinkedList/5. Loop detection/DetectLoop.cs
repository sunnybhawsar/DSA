// Is loop present or not in the linkedlist

using System;
using System.Collections.Generic;

public class Node
{
    public int data;
    public Node next;

    public Node(int data, Node next = null)
    {
        this.data = data;
        this.next = next;
    }
}

public class Solution
{
    public static void Main(string[] g)
    {
        Node head = Build(null);

        Console.WriteLine(IsLoopPresent(head) ? "Loop Present" : "Loop Absent");
    }

    // Floyd Loop Detection Algorithm - Slow & Fast pointer
    // Time: O(n), Space: O(1)
    private static bool IsLoopPresent(Node head)
    {
        Node slow = head, fast = head;

        while(slow != null && fast != null)
        {
            fast = fast.next;
            if(fast != null)
                fast = fast.next;
            
            slow = slow.next;

            if(slow == fast)
                return true;
        }

        return false;
    }

    // Using Collection
    // Time: O(n), Space: O(n)
    private static bool IsLoopPresentUsingCollection(Node head)
    {
        Node temp = head;
        IList<Node> visited = new List<Node>();

        while(temp != null)
        {
            if(visited.Contains(temp))
                return true;
            else
                visited.Add(temp);
            
            temp = temp.next;
        }

        return false;
    }

    private static Node Build(Node head)
    {
        // 1 -> 3 -> 4 -> 8 -> 2 -> 3
        head = new Node(1);
        head.next = new Node(3);
        head.next.next = new Node(4);
        head.next.next.next = new Node(8);
        head.next.next.next.next = new Node(2);
        head.next.next.next.next.next = head.next;

        return head;
    }
}

// Sunny Bhawsar
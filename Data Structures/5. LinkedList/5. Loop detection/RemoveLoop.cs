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

        Node temp = RemoveLoop(head);
        if(temp != null)
            PrintLinkedList(temp);
        else
            PrintLinkedList(head);
    }

    private static Node RemoveLoop(Node head)
    {
        Node startNode = GetStartingNodeOfLoop(head);
        if(startNode == null)
            return null;
        
        Node temp = startNode;

        while(temp.next != startNode)
            temp = temp.next;

        temp.next = null;

        return head;
    }

    // A + B = KC
    private static Node GetStartingNodeOfLoop(Node head)
    {
        Node fast = IntersectingNode(head);
        if(fast == null)
            return null;
        
        Node slow = head;

        while(slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }

    // Floyd Loop Detection Algorithm - Slow & Fast pointer
    // Time: O(n), Space: O(1)
    private static Node IntersectingNode(Node head)
    {
        Node slow = head, fast = head;

        while(slow != null && fast != null)
        {
            fast = fast.next;
            if(fast != null)
                fast = fast.next;
            
            slow = slow.next;

            if(slow == fast)
                return fast;
        }

        return null;
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

    private static void PrintLinkedList(Node head)
    {
        Node temp = head;
        while(temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
    }
}

// Sunny Bhawsar
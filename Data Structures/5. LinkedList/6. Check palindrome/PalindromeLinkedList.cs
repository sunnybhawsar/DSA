// Is a linkedlist palindrome or not

using System;
using System.Collections.Generic;

public class Node
{
    public int val;
    public Node next;

    public Node(int val, Node next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static void Main(string[] g)
    {
        Node head = Build(null);

        Console.WriteLine(IsPalindromeOptimized(head) ? "Palindrome" : "Not Palindrome");
    }

    // Time: O(n), Space: O(1)
    private static bool IsPalindromeOptimized(Node head)
    {
        Node slow = head, fast = head;

        while(fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        
        if(fast != null)
            slow = slow.next;
        
        slow = Reverse(slow);
        fast = head;

        while(slow != null)
        {
            if(slow.val != fast.val)
                return false;

            slow = slow.next;
            fast = fast.next;
        }

        return true;
    }
    private static Node Reverse(Node node)
    {
        Node prv = null, nxt = null, cur = node;

        while(cur != null)
        {
            nxt = cur.next;
            cur.next = prv;
            prv = cur;
            cur = nxt;
        }

        return prv;
    }

    // Time: O(n), Space: O(n)
    private static bool IsPalindrome(Node head)
    {
        IList<int> list = new List<int>();
        
        while(head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        
        int start = 0, end = list.Count - 1;
        
        while(start < end)
        {
            if(list[start] != list[end])
                return false;
            
            start++;
            end--;
        }
        
        return true;
    }

    private static Node Build(Node head)
    {
        // 1 -> 0 -> 0 -> 0 -> 1 -> null
        head = new Node(1);
        head.next = new Node(0);
        head.next.next = new Node(0);
        head.next.next.next = new Node(0);
        head.next.next.next.next = new Node(1);
        head.next.next.next.next.next = null;

        return head;
    }
}

// Sunny Bhawsar
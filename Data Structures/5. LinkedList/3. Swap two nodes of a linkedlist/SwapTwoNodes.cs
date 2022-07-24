/*
Given a linked list and two keys, swap nodes for the given keys

10 -> 15 -> 12 -> 13 -> 20 -> 14

Swap 12 and 20

10 -> 15 -> 20 -> 13 -> 12 -> 14
*/

using System;

class Node
{
    public int val;
    public Node next;
    
    public Node(int val, Node next = null)
    {
        this.val = val;
        this.next = next;
    }
}

class Solution 
{
    static void Main(String[] args) 
	{
        Node node = null;
		BuildLinkedList(ref node);
		Console.WriteLine("Before:");
		Print(node);
        
        int a = 12, b = 20;        
       	SwapNodes(ref node, a, b);		
		Console.WriteLine("\nAfter:");
      	Print(node);
    }	
	
	// Time: O(n) & Space: O(1)
    private static void SwapNodes(ref Node head, int a, int b)
    {
		if(a == b)
			return;
				
		Node aPrev = null, aCurr = head;
		while(aCurr != null && aCurr.val != a)
		{
			aPrev = aCurr;
			aCurr = aCurr.next;
		}
		
		Node bPrev = null, bCurr = head;
		while(bCurr != null && bCurr.val != b)
		{
			bPrev = bCurr;
			bCurr = bCurr.next;
		}
		
		if(aCurr == null || bCurr == null)
			return;
		
		if(aPrev != null)
			aPrev.next = bCurr;
		else
			head = bCurr;
		
		if(bPrev != null)
			bPrev.next = aCurr;
		else
			head = aCurr;
		
		Node temp = aCurr.next;
		aCurr.next = bCurr.next;
		bCurr.next = temp;       
    }	
        
	private static void BuildLinkedList(ref Node node)
	{
		node = new Node(10);
		node.next = new Node(15);
        node.next.next = new Node(12);
        node.next.next.next = new Node(13);
        node.next.next.next.next = new Node(20);
        node.next.next.next.next.next = new Node(14);
	}
	
    private static void Print(Node node)
    {
		Node n = node;
        while(n != null)
        {
            Console.Write(n.val + " ");
            n = n.next;
        }
    } 
}      

// Sunny Bhawsar #Qualcomm
// Approach:
	// Find prev & current nodes for both values
	// Re-Point to one another
	// Swap the nodes
	// Node: No need to do any thing if any of the val not found in the linkedlist
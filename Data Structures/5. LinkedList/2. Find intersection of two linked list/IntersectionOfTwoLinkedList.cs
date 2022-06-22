using System;
using System.Collections.Generic;
			
public class Node {
	public int val;
	public Node next;
	public Node(int x) { val = x; }
}

public class Solution 
{
	public static void Main(string[] args)
	{
		// list 1
        Node n1 = new Node(1);
        n1.next = new Node(2);
        n1.next.next = new Node(3);
        n1.next.next.next = new Node(4);
        n1.next.next.next.next = new Node(5);
        n1.next.next.next.next.next = new Node(6);
        n1.next.next.next.next.next.next = new Node(7);
		
        // list 2
        Node n2 = new Node(10);
        n2.next = new Node(9);
        n2.next.next = new Node(8);
        n2.next.next.next = n1.next.next.next;
		
		Console.WriteLine(GetIntersectionNodeUsingTwoPointers(n1, n2).val);
	}
	
	// O(n) Time, O(n) Space
	public static Node GetIntersectionNodeUsingHashing(Node n1, Node n2)
    {
        HashSet<Node> hs = new HashSet<Node>();
        while (n1 != null)
        {
            hs.Add(n1);
            n1 = n1.next;
        }
        while (n2 != null)
        {
            if (hs.Contains(n2))
            {
                return n2;
            }
            n2 = n2.next;
        }
		
        return null;
    }
	
	// O(n+m) Time, O(1) Space
	public static Node GetIntersectionNodeUsingTwoPointers(Node headA, Node headB) 
    {
        if(headA == null || headB == null)
           return null;
           
        Node ptr1 = headA;
        Node ptr2 = headB;
              
        while(ptr1 != ptr2)
        {
            ptr1 = ptr1.next;
            ptr2 = ptr2.next;
            
            if(ptr1 == ptr2)
                return ptr1;
            
            if(ptr1 == null)
                ptr1 = headB;
            
            if(ptr2 == null)
                ptr2= headA;           
            
        }
        
        return ptr1;
    }
}

// Sunny Bhawsar
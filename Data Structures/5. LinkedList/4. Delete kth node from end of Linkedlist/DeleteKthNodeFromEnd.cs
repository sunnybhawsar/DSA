using System;

public class Node {
	public int val;
	public Node next;
	public Node(int val = 0, Node next = null) 
	{
		this.val = val;
		this.next = next;
	}
}

public class Program
{
	public static void Main()
	{
		Node head = new Node(1);
		head.next = new Node(2);
		head.next.next = new Node(3);
		head.next.next.next = new Node(4);
		head.next.next.next.next = new Node(5);
        head.next.next.next.next.next = new Node(6);
        head.next.next.next.next.next.next = new Node(7);
        head.next.next.next.next.next.next.next = new Node(8);
        head.next.next.next.next.next.next.next.next = new Node(9);
		
		DeleteKthElementFromEnd(ref head, 4);
		
		while(head != null)
		{
			Console.Write(head.val + " ");
			head = head.next;
		}	
	}

    // O(n)
    private static void DeleteKthElementFromEnd(ref Node head, int k)
    {
        Node ptr1 = head, ptr2 = head;

        for(int i = 0; i < k; i++)
        {
            if(ptr2.next == null)
            {
                if(i == k - 1)
                {
                    head = head.next;
                    return;
                }
            }
            
            ptr2 = ptr2.next;
        }

        while(ptr2.next != null)
        {
            ptr1 = ptr1.next;
            ptr2 = ptr2.next;
        }

        ptr1.next = ptr1.next.next;
    }
}

// Sunny Bhawsar #Amazon
// Approach:
    // Start 1st pointer from head and 2nd one from kth potion then keep increamenting both by 1 
    // untill 2nd pointer reaches null
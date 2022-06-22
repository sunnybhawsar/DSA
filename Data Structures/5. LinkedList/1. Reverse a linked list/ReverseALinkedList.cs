using System;

public class ListNode {
	public int val;
	public ListNode next;
	public ListNode(int val=0, ListNode next=null) 
	{
		this.val = val;
		this.next = next;
	}
}

public class Program
{
	public static void Main()
	{
		ListNode head = new ListNode(1);
		head.next = new ListNode(2);
		head.next.next = new ListNode(3);
		head.next.next.next = new ListNode(4);
		head.next.next.next.next = new ListNode(5);
		
		var result = ReverseList(head);
		
		while(result != null)
		{
			Console.WriteLine(result.val + " ");
			result = result.next;
		}	
	}
	
	// O(n)
	private static ListNode ReverseList(ListNode head) {
        if(head == null || head.next == null)
            return head;
        
        ListNode result = null;
        
        while(head != null)
        {
            var temp = head.next;
            head.next = result;
            result = head;
            head = temp;
        }
        
        return result;
    }
}

// Sunny Bhawsar
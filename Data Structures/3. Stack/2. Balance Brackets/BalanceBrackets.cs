using System;
using System.Collections.Generic;	

public class Program
{
	private static Stack<char> _stack;
	
	static Program()
	{
		 _stack = new Stack<char>();
	}
	
	public static void Main()
	{
		IList<string> expressions = new List<string>() {"[()]{}{[()()]()}", "[(])", "]]][[[", "(){}[]", "]()(){}[]"};
		
		foreach(var exp in expressions)
			Console.WriteLine(IsBalanced(exp) ? "Balanced" : "Not Balanced");
	}
	
    // O(n)
	private static bool IsBalanced(string exp)
	{
		bool isBalanced = false;
		_stack.Clear();
				
		foreach(var ch in exp)
		{
			if(ch == '[' || ch == '{' || ch == '(')
				_stack.Push(ch);
			
			else
			{
				if(_stack.Count > 0)
				{
					if(ch == ']' && _stack.Peek() == '[')
						_stack.Pop();
					else if(ch == '}' && _stack.Peek() == '{')
						_stack.Pop();
					else if(ch == ')' && _stack.Peek() == '(')
						_stack.Pop();
					else
						_stack.Push(ch);
				}
				else
					_stack.Push(ch);
			}				
		}
		
		if(_stack.Count == 0)
			isBalanced = true;		
		   
		return isBalanced;
	}
}

// Sunny Bhawsar
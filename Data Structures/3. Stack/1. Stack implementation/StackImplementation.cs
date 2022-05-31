using System;
		
public class Stack<T> 
{
	private int _size;
	private int _top;
	private T[] _arr;
	
	public Stack(int size)
	{
		_size = size;
		_arr = new T[_size];
		_top = -1;
	}
	
	public void Push(T element)
	{
		if(!IsFull())
			_arr[++_top] = element;
	}
	
	public T Pop()
	{
		if(!IsEmpty())
			return _arr[_top--];
		
		return default(T);
	}
	
	public T Top()
	{
		if(!IsEmpty())
			return _arr[_top];
		
		return default(T);		
	}
	
	public bool IsEmpty()
	{
		return _top == -1;
	}
	
	public bool IsFull()
	{
		return _top == _size - 1;
	}
}

public class Program
{
	public static void Main()
	{
		Stack<int?> stack = new Stack<int?>(4);
		
		stack.Push(1);
		stack.Push(2);
		stack.Push(3);
		stack.Push(4);
		stack.Push(5);
        
        Console.WriteLine($"Top: {stack.Top()}");
		Console.WriteLine($"Pop: {stack.Pop()}");
		Console.WriteLine($"Pop: {stack.Pop()}");
		Console.WriteLine($"Pop: {stack.Pop()}");
		Console.WriteLine($"Pop: {stack.Pop()}");
		Console.WriteLine($"Pop: {stack.Pop()}");
		Console.WriteLine($"Top: {stack.Top()}");
	}
}
using System;

public class Queue<T>
{
	private int _size;
	private int _front;
	private int _rear;
	private T[] _arr;
	
	public Queue(int size)
	{
		_size = size;
		_arr = new T[_size];
		_front = 0;
		_rear = -1;
	}
	
	public void Enqueue(T element)
	{
		if(!IsFull())
		{
			_arr[++_rear] = element;
		}
	}
	
	public T Dequeue()
	{
		if(!IsEmpty())
			return _arr[_front++];
		
		return default(T);
	}
	
	public T Peek()
	{
		if(!IsEmpty())
			return _arr[_front];
		
		return default(T);		
	}
	
	public bool IsEmpty()
	{
		return  _front == _rear + 1;
	}
	
	public bool IsFull()
	{
		return _rear >= _size - 1;
	}
}
					
public class Program
{
	public static void Main()
	{
		Queue<int?> queue = new Queue<int?>(4);
		
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);
		queue.Enqueue(5);
		
		Console.WriteLine($"Peek: {queue.Peek()}");
		Console.WriteLine($"Dequeue: {queue.Dequeue()}");
		Console.WriteLine($"Dequeue: {queue.Dequeue()}");
		Console.WriteLine($"Dequeue: {queue.Dequeue()}");
		Console.WriteLine($"Dequeue: {queue.Dequeue()}");
		Console.WriteLine($"Dequeue: {queue.Dequeue()}");
		Console.WriteLine($"Peek: {queue.Peek()}");
	}
}
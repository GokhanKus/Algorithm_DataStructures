using DataStructuresLibrary.LinkedList.SinglyLinkedList;

namespace DataStructuresLibrary.Stack
{
	public class LinkedListStack<T> : IStack<T>
	{
		private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
		public int Count { get; private set; }
		public void Clear()
		{
			list.Head = null;
		}
		public T Peek()
		{
			if (list.Head is null || Count == 0)
				throw new ArgumentNullException("no element was found in the list");

			return list.Head.Value;
		}
		public T Pop()
		{
			if (Count == 0)
				throw new Exception("empty stack");

			Count--;
			return list.RemoveFirst();
		}
		public void Push(T value)
		{
			if (value == null)
				throw new ArgumentNullException();
			list.AddFirst(value);
			Count++;
		}
	}
}
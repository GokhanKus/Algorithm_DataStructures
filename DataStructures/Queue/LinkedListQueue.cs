using DataStructuresLibrary.LinkedList.DoublyLinkedList;
using System.Runtime.CompilerServices;

namespace DataStructuresLibrary.Queue
{
	public class LinkedListQueue<T> : IQueue<T>
	{
		private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
		public int Count { get; private set; }

		public T DeQueue()
		{
			if (Count == 0) throw new Exception("empty queue");
			Count--;
			return list.RemoveFirst();
		}

		public void Enqueue(T value)
		{
			if (value == null) throw new ArgumentNullException();
			list.AddLast(value);
			Count++;
		}

		public T Peek() => Count == 0 ? throw new Exception("empty queue") : list.Head.Value; //3lü kosul ifadesi
																							  //{
																							  //	if (Count == 0) throw new Exception("empty queue");
																							  //	return list.Head.Value;
																							  //}

		public T Front()
		{
			throw new NotImplementedException();
		}

		public T Rear()
		{
			throw new NotImplementedException();
		}

		public int Size()
		{
			int count = 0;
			foreach (var item in list)
			{
				count++;
			}
			return count;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Queue
{
	public class CustomQueue<T>
	{
		private readonly IQueue<T> queue;
		public CustomQueue(QueueType type = QueueType.Array)
		{
			switch (type)
			{
				case QueueType.Array:
					queue = new ArrayQueue<T>();
					break;

				default: //QueueType.LinkedList:
					queue = new LinkedListQueue<T>();
					break;
			}
		}
		public void EnQueue(T value)
		{
			queue.Enqueue(value);
		}
		public T DeQueue()
		{
			return queue.DeQueue();
		}
		public T Peek()
		{
			return queue.Peek();
		}
		public T Front()
		{
			return queue.Front();
		}
		public T Rear()
		{
			return queue.Rear();
		}
		public int Size()
		{
			return queue.Size();
		}
	}
}

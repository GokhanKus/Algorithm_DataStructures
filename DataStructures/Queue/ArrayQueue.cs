namespace DataStructuresLibrary.Queue
{
	public class ArrayQueue<T> : IQueue<T>
	{
		private readonly List<T> list = new List<T>();
		public int Count { get; private set; }

		public T DeQueue()
		{
			if (Count == 0) throw new Exception("empty queue");
			var temp = list[0];
			list.RemoveAt(0);
			Count--;
			return temp;
		}

		public void Enqueue(T value)
		{
			if (value == null) throw new ArgumentNullException();
			list.Add(value);
			Count++;
		}
		public T Peek()
		{
			if (Count == 0) throw new Exception("empty queue");
			var temp = list[0];
			return temp;
		}

		public T Front()
		{
			return Peek();
		}


		public T Rear()
		{
			if (list.Count == 0)
				throw new InvalidOperationException("Queue is empty");
			return list[Count - 1]; // ^1 sonuncu öğeyi temsil eder
		}

		public int Size()
		{
			return list.Count;
		}
	}
}
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
			throw new NotImplementedException();
		}


		public T Rear()
		{
			throw new NotImplementedException();
		}

		public int Size()
		{
			return list.Count;
		}
	}
}
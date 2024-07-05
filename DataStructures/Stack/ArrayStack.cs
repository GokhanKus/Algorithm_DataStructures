namespace DataStructuresLibrary.Stack
{
	public class ArrayStack<T> : IStack<T>
	{
		public int Count { get; private set; }
		private readonly List<T> list = new List<T>();
		public void Clear()
		{
			list.Clear();
		}

		public T Peek()
		{
			if (Count == 0)
				throw new Exception("no element was found");
			var temp = list[list.Count - 1];
			return temp;
		}

		public T Pop()
		{
			if (Count == 0)//eger count 0 ise silinecek eleman yok demektir 
				throw new Exception("no element was found");

			var temp = list[list.Count - 1];
			list.RemoveAt(list.Count - 1); //stackten son elemani cikarir
			Count--;
			return temp;
		}

		public void Push(T value)
		{
			if (value is null)
				throw new ArgumentNullException();

			list.Add(value);
			Count++;
		}
	}
}
namespace DataStructuresLibrary.Queue
{
	public interface IQueue<T>
	{
		int Count { get; }
		void Enqueue(T value);
		T DeQueue();
		T Peek();
		T Front();
		T Rear();
		int Size();
	}
}

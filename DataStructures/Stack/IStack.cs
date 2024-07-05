namespace DataStructuresLibrary.Stack
{
	public interface IStack<T>
	{
		int Count { get; }
		void Clear();
		void Push(T value); //eklenecek eleman
		T Peek();       //stackten cikarilacak elemani gosterir 
		T Pop();        //stackten son elemani cikarir 
	}
}

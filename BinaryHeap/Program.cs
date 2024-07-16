using DataStructuresLibrary.Heap;

namespace BinaryHeap
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] nodes = { 4, 1, 10, 8, 7, 5, 9, 3,2};
			var heap = new MinHeap<int>(nodes);
			//heap.Add(2);
			Console.WriteLine(heap.DeleteMinMax() + " has been removed");
			foreach (var item in heap)
			{
				Console.WriteLine(item);
			}
		}
	}
}

using DataStructuresLibrary.Heap;
using DataStructuresLibrary.Shared;
using System.Reflection.Metadata.Ecma335;
namespace BinaryHeap
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//BinaryHeapApp1();
			//BinaryHeapApp2();
			BinaryHeapApp3();
		}

		private static void BinaryHeapApp3()
		{
			var minHeap = new BinaryHeap<int>(SortDirection.Ascending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });
            Console.WriteLine("Min heap:");
            foreach (var item in minHeap)
			{
				Console.Write($"{item,-3}");
			}
            Console.WriteLine();
            Console.WriteLine("Max heap:");
			var maxHeap = new BinaryHeap<int>(SortDirection.Descending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });
			foreach (var item in maxHeap)
			{
				Console.Write($"{item,-3}");
			}
		}

		private static void BinaryHeapApp2()
		{
			List<int> values = new List<int> { 6, 9, 24, 64, 36, 8, 16, 95 };
			var heap = new MaxHeap<int>(); //default 128 size..
			heap.AddRange(values);
			var maxValue = heap.DeleteMinMax();
			Console.WriteLine(maxValue + " has been removed");
			foreach (var value in heap)
			{
				Console.WriteLine(value);
			}
			var root = heap.Peek();
		}

		private static void BinaryHeapApp1()
		{
			int[] values = { 4, 1, 10, 8, 7, 5, 9, 3, 2 };
			var heap = new MinHeap<int>(values);
			//heap.Add(2);
			Console.WriteLine(heap.DeleteMinMax() + " has been removed");
			foreach (var item in heap)
			{
				Console.WriteLine(item);
			}
			var root = heap.Peek();
		}
	}
}

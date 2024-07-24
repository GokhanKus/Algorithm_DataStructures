using DataStructuresLibrary.Shared;
using DataStructuresLibrary.SortingAlgorithm;

namespace SortingAlgorithm
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] arr = { 10, 5, 15, 25, 0, 15, 75, 20 };
			SelectionSort.Sort(arr, SortDirection.Descending);
			foreach (int i in arr)
			{
				Console.Write(i + "  ");
			}

			Console.WriteLine();

			SelectionSort.Sort(arr, SortDirection.Ascending);
			foreach (int i in arr)
			{
				Console.Write(i + "  ");
			}
			Console.ReadLine();
		}
	}
}

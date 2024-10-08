﻿using DataStructuresLibrary.Heap;
using DataStructuresLibrary.Shared;
using DataStructuresLibrary.SortingAlgorithm;

namespace SortingAlgorithm
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//SelectionSortApp();
			//BubbleSortApp();
			//InsertionApp();
			//QuickSortApp();
			//MergeSortApp();
			HeapSortApp();
		}

		private static void HeapSortApp()
		{
			byte[] arr = { 10, 5, 15, 25, 0, 15, 75, 20 };

			Console.WriteLine("sorting by maxheap");
            var maxHeap = new BinaryHeap<byte>(SortDirection.Descending, arr);
			foreach (var item in maxHeap)
			{
				Console.Write($"{maxHeap.DeleteMinMax(),-5}");
			}

			Console.WriteLine("\nsorting by minheap");
			var minHeap = new BinaryHeap<byte>(SortDirection.Ascending, arr);
			foreach (var item in minHeap)
			{
				Console.Write($"{minHeap.DeleteMinMax(),-5}");
			}
		}

		private static void MergeSortApp()
		{
			byte[] arr = { 10, 5, 15, 25, 0, 15, 75, 20 };

			MergeSort.Sort(arr);
			foreach (int i in arr)
			{
				Console.Write(i + "  ");
			}
			Console.WriteLine();
		}

		private static void QuickSortApp()
		{
			int[] arr = { 10, 5, 15, 25, 0, 15, 75, 20 };

			QuickSort.Sort(arr);
			foreach (int i in arr)
			{
				Console.Write(i + "  ");
			}
			Console.WriteLine();
		}

		private static void InsertionApp()
		{
			int[] arr = { 10, 5, 15, 25, 0, 15, 75, 20 };
			var sortedList = InsertionSort.Sort(arr, SortDirection.Ascending);
			foreach (int i in sortedList)
			{
				Console.Write(i + "  ");
			}
		}

		private static void BubbleSortApp()
		{
			int[] arr = { 10, 5, 15, 25, 0, 15, 75, 20 };
			BubbleSort.Sort(arr, SortDirection.Descending);
			foreach (int i in arr)
			{
				Console.Write(i + "  ");
			}
		}

		private static void SelectionSortApp()
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

using DataStructuresLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.SortingAlgorithm
{
	// 10, 5, 15, 25, 0, 15, 75, 20
	public class BubbleSort
	{
		//ascending sıralar
		public static void Sort<T>(T[] array) where T : IComparable
		{
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length - i - 1; j++)
				{
					if (array[j].CompareTo(array[j + 1]) > 0)
						Sorting.Swap(array, j, j + 1);
				}
			}
		}
		//verdigin parametreye bagli olarak ascending veya descending
		public static void Sort<T>(T[] array, SortDirection sortDirection = SortDirection.Ascending) where T : IComparable
		{
			var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);

			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length - i - 1; j++)
				{
					if (comparer.Compare(array[j], array[j + 1]) > 0)
						Sorting.Swap(array, j, j + 1);
				}
			}
		}
	}
}

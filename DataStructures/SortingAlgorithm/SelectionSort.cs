using DataStructuresLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.SortingAlgorithm
{
	public class SelectionSort
	{
		public static void Sort<T>(T[] array) where T : IComparable
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				var minIndex = i;
				T minValue = array[i];
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[j].CompareTo(minValue) < 0)
					{
						minIndex = j;
						minValue = array[minIndex];
					}
				}
				Sorting.Swap<T>(array, i, minIndex);
			}
		}

		public static void Sort<T>(T[] array, SortDirection sortDirection = SortDirection.Ascending) where T : IComparable
		{
			var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (comparer.Compare(array[j], array[i]) < 0)
						Sorting.Swap<T>(array, i, j);
				}
			}
		}
	}
}

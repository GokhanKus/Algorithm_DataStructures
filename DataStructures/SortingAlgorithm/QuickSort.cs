using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.SortingAlgorithm
{
	public static class QuickSort
	{
		public static void Sort<T>(T[] array) where T : IComparable
		{
			Sort(array, 0, array.Length - 1);
		}
		private static void Sort<T>(T[] array, int lower, int upper) where T : IComparable
		{
			if (lower < upper)
			{
				int pi = Partition(array, lower, upper);
				Sort(array, lower, pi - 1);
				Sort(array, pi + 1, upper);
			}
		}
		private static int Partition<T>(T[] array, int lower, int upper) where T : IComparable
		{
			T pivot = array[lower];
			int i = lower;
			int j = upper;

			while (i < j)
			{
				while (i <= upper && array[i].CompareTo(pivot) <= 0)
					i++;
				while (j >= lower && array[j].CompareTo(pivot) > 0)
					j--;

				if (i < j)
				{
					Sorting.Swap(array, i, j);
				}
			}

			Sorting.Swap(array, lower, j);
			return j;
		}
	}
}

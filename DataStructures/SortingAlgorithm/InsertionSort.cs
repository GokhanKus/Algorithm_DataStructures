using DataStructuresLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.SortingAlgorithm
{
	// 10, 5, 15, 25, 0, 15, 75, 20
	public class InsertionSort
	{
		//verdigin parametreye bagli olarak ascending veya descending
		public static T[] Sort<T>(T[] array, SortDirection sortDirection = SortDirection.Ascending) where T : IComparable
		{
			var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);

			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j > 0; j--)
				{
					if (comparer.Compare(array[j], array[j - 1]) < 0)
						Sorting.Swap(array, j - 1, j);

					else break;
				}
			}
			return array;
		}
	}
}

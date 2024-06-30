using System.Collections;
using System.Linq;
using System.Net.WebSockets;
using DataStructures.Array;

namespace Apps
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var p1 = new Array<int>(1, 2, 3, 4, 5);
			var p2 = new int[] { 5, 10, 15, 20 };
			var p3 = new List<int> { 10, 20, 30, 40, 50 };
			var p4 = new ArrayList { 2, 5, 8, 11 };


			var arr = new Array<int>(1, 2, 3, 4, 5); //using DataStructures.Array; bizim olusturdugumuz generic liste ==> list<int> gibi
			var arr2 = new Array<int>(p1);
			var arr3 = new Array<int>(p2);
			var arr4 = new Array<int>(p3);
			//var arr5 = new Array<int>(p4); array list tip guvenli degil object boxing unboxing vs hata gverir

			//arr.Add(5);
			//arr.RemoveLast(); // 8 count 8 capacity

			foreach (var item in arr3)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("-----");

			arr.Where(x => x % 2 == 0).ToList().ForEach(x => Console.WriteLine(x));

			Console.WriteLine($"array count: {arr.Count} - array capacity: {arr.Capacity}");
		}
	}
}

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
			var arr = new Array<int>(); //using DataStructures.Array; bizim olusturdugumuz generic liste ==> list<int> gibi
			arr.Add(5);
			arr.Add(25);
			arr.Add(45);
			arr.Add(25);
			arr.Add(18);
			arr.Add(18);
			arr.Add(12);
			arr.Add(65);
			arr.Add(15);
			arr.Add(62);
			arr.Add(65); //9 count 16 capacity
			arr.RemoveLast(); // 8 count 8 capacity

			foreach (var item in arr)
			{
                Console.WriteLine(item);
            }

            Console.WriteLine("-----");

			arr.Where(x => x % 2 == 0).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine($"array count: {arr.Count} - array capacity: {arr.Capacity}");
        }
	}
}

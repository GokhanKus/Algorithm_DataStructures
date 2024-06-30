using System.Collections;
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
			arr.Add(65);
			arr.Add(65);
			arr.Add(65);
			arr.Add(65);
			arr.Add(65); //9 count 16 capacity
			arr.RemoveLast(); // 8 count 8 capacity
			
			Console.WriteLine($"{arr.Count} - {arr.Capacity}");
        }
	}
}

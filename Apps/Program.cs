using System.Collections;
using System.Net.WebSockets;
using DataStructures.Array;

namespace Apps
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var arr = new Array<int>(); //using DataStructures.Array;
			arr.Add(5);
			arr.Add(25);
            Console.WriteLine($"{arr.Count} - {arr.Capacity}");
        }
	}
}

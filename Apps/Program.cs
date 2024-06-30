using System.Collections;
using System.Net.WebSockets;

namespace Apps
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Array
			var arrChar = new char[] { 'a', 'b', 'c' };
			var arrInt = Array.CreateInstance(typeof(int), 5); // ==> int[] arrInt = new int[5]
			arrInt.SetValue(10,0); //arrInt[0] = 10;
			arrInt.GetValue(0); //10;

			//ArrayList - Tip guvenli degil
			var arrObj = new ArrayList();
			arrObj.Add(10); //boxing -> to object
			var a = arrObj[0]; // bu objecttir inte donusturursek unboxing yapariz 
			arrObj.Add('b');
			arrObj.Add(true);

			//List<T>
			var listInt = new List<int>();
			listInt.Add(10);
			listInt.AddRange(new int[] { 1, 5, 6 });
			listInt.RemoveAt(1);

		}
	}
}

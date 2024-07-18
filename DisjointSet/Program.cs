using DataStructuresLibrary.DisJointSet;

namespace DisjointSet
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] values = { 1,2,3,4,5,6,7 };
			DisjointSet<int> disjointSet = new DisjointSet<int>(values);

			//fordan sonra her bir node ayrik set oldu, simdi birlestirelim union ile;
			disjointSet.Union(6, 7); //6 5'e baglandi yani artik 6'nin temsilcisi (root) 5
			disjointSet.Union(1,3);
			disjointSet.Union(2,3);
			disjointSet.Union(2,6);
			for (int i = 1; i <= disjointSet.Count; i++)
			{
				Console.WriteLine($"Find({i}) = {disjointSet.FindSet(i)}");
			}
			Console.ReadKey();
		}
	}
}

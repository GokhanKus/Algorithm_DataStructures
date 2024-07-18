using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.DisJointSet
{
	public class DisjointSet<T> : IEnumerable<T>
	{
		private Dictionary<T, DisjointSetNode<T>> set = new Dictionary<T, DisjointSetNode<T>>();
		public int Count { get; private set; }
		public void MakeSet(T value) //ayrik set olusturma
		{
			if (set.ContainsKey(value))
				throw new Exception("the value has already been defined");
			var newSet = new DisjointSetNode<T>(value); //rank default 0 
			newSet.Parent = newSet; //ayrik set olarak kendini isaret ediyor ve kök eleman
			set.Add(value, newSet); //setimize yeni olusturulan kok degerimizi ekleyelim
			Count++;
		}
		public T FindSet(T value)
		{
			if (!set.ContainsKey(value))
				throw new Exception("the value is not in the set");

			var root = findset(set[value]).Value;
			return root;
		}
		private DisjointSetNode<T> findset(DisjointSetNode<T> node)
		{
			var parent = node.Parent;
			if (node != parent) //kok degilse koke kadar gidecegiz, yani kendisine esit olana kadar.. 
			{
				//path compression
				node.Parent = findset(node.Parent);
				return node.Parent;
			}
			return parent;
		}
		public void Union(T valueA, T valueB) //ayrik 2 seti birlestirme union by rank(height)
		{
			//a'nin ve b'nin temsilcileri birbirinden farkliysa birlestirme islemi yapilabilir
			var rootA = FindSet(valueA);
			var rootB = FindSet(valueB);

			if (rootA.Equals(rootB)) //2 node ayniysa zaten ayni set icerisindedir birlestirilecek bir sey yoktur
				return;

			var nodeA = set[rootA];  // rootA'nın node'unu al
			var nodeB = set[rootB];  // rootB'nın node'unu al

			if (nodeA.Rank == nodeB.Rank)
			{
				nodeB.Parent = nodeA;
				nodeA.Rank++;
			}
			else
			{
				if (nodeA.Rank > nodeB.Rank)
					nodeA.Parent = nodeB;

				else
					nodeB.Parent = nodeA;
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			return set.Values.Select(x => x.Value).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

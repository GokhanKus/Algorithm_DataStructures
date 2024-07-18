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
			return value;
		}
		public void Union(T valueA, T valueB) //ayrik 2 seti birlestirme union by rank(height)
		{
			//a'nin ve b'nin temsilcileri birbirinden farkliysa birlestirme islemi yapilabilir
			var rootA = FindSet(valueA);
			var rootB = FindSet(valueB);

			if (rootA.Equals(rootB)) //2 node ayniysa zaten ayni set icerisindedir birlestirilecek bir sey yoktur
				return;

			var nodeA = set[rootA];
			var nodeB = set[rootB];

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
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}

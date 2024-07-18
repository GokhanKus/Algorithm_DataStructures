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
		public void Union(T valueA, T valueB) //ayrik 2 seti birlestirme
		{

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

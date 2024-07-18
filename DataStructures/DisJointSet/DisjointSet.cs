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
		private Dictionary<T, DisjointSet<T>> set = new Dictionary<T, DisjointSet<T>>();
		public int Count { get; private set; }
		public void MakeSet() //ayrik set olusturma
		{

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

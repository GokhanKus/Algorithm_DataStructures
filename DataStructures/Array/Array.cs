using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
	public class Array<T> : IEnumerable<T>, ICloneable
	{
		private T[] InnerList;
		public int Count { get; private set; }
		public int Capacity => InnerList.Length;
		public Array()
		{
			InnerList = new T[2];
			Count = 0;
		}
		public object Clone()
		{
			throw new NotImplementedException();
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

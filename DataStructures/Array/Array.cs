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
		public void Add(T item)
		{
			if (InnerList.Length == Count) //eger listenin uzunlugu capacity'i asarsa dizi boyutunu ikiye katlayalim
				DoubleArray();

			InnerList[Count] = item;
			Count++;
		}
		public T RemoveLast()
		{
			if (Count == 0)
				throw new Exception("there is no more item to be removed from the array");

			var temp = InnerList[Count - 1];

			if (InnerList.Length / 2 == Count-1)
				HalfOfArray();

			if (Count > 0)
				Count--;
			return temp;
		}

		private void HalfOfArray()
		{
			if (InnerList.Length > 2)
			{
				var temp = new T[InnerList.Length / 2];
				System.Array.Copy(InnerList, temp, InnerList.Length / 2);
				InnerList = temp;
			}
		}

		private void DoubleArray()
		{
			var temp = new T[InnerList.Length * 2]; //t tipinde gecici array.
			System.Array.Copy(InnerList, temp, InnerList.Length);//kaynaktan, hedefe, uzunluk
			InnerList = temp; //Innerlist boyutu ikiye katlandi
		}

		public object Clone()
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			//classımıza IEnumerable interfacesini kazandırmazsak foreach ile listemizi donemeyiz hata aliriz ve linq sorgular calistiramayiz
			return InnerList.Take(Count).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator(); //generic ifadelerle calistigimiz icin IEnumerator<T> GetEnumerator() metoduna yonlendirelim
		}
	}
}

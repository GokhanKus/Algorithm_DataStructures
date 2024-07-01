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
		public Array(params T[] initial)
		{
			InnerList = new T[initial.Length];
			Count = 0;
			foreach (var item in initial)
				Add(item);
		}
		public Array(IEnumerable<T> collection)
		{
			//InnerList = new T[collection.ToArray().Length];
			InnerList = new T[collection.Count()];
			Count = 0;
			foreach (var item in collection)
			{
				Add(item);
			}
		}
		public void Add(T item)
		{
			if (InnerList.Length == Count) //eger listenin uzunlugu capacity'i asarsa dizi boyutunu ikiye katlayalim
				DoubleArray();

			InnerList[Count] = item;
			Count++;
		}
		public void AddRange(IEnumerable<T> collection)
		{
			throw new NotImplementedException();
		}
		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		public T RemoveLast()
		{
			if (Count == 0)
				throw new Exception("there is no more item to be removed from the array");

			var temp = InnerList[Count - 1];

			if (InnerList.Length / 2 == Count - 1)
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
			//return this.MemberwiseClone(); //bu nesnenin butun ozelliklerinin yeni olusturulan, clonlanan ogeye gecmesini saglar
			var arr = new Array<T>();
			foreach (var item in this)
			{
				arr.Add(item);
			}
			return arr;
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

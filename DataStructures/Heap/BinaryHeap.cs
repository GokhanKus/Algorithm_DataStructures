using DataStructuresLibrary.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Heap
{
	public class BinaryHeap<T> : IEnumerable<T> where T : IComparable
	{
		public T[] HeapArray { get; private set; }
		public int Count { get; private set; }
		private int position;

		private readonly IComparer<T>? _comparer;
		private readonly bool isMax;
		public BinaryHeap(SortDirection sortDirection = SortDirection.Ascending) :
			this(sortDirection, null, null) // user hic parametre vermediyse main ctora yonlendirelim
		{

		}
		public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial) :
			this(sortDirection, initial, null)//user ilk 2 parametreyi verdiyse main ctora yonlendirelim
		{

		}
		public BinaryHeap(SortDirection sortDirection, IComparer<T> comparer) :
			this(sortDirection, null, comparer)//user 1 ve 3.parametreyi verdiyse main ctora yonlendirelim
		{

		}

		public BinaryHeap(SortDirection sortDirection, IEnumerable<T>? initial, IComparer<T>? comparer)
		{
			position = 0;
			Count = 0;
			isMax = sortDirection == SortDirection.Descending;
			if (comparer != null)
				comparer = new CustomComparer<T>(sortDirection, comparer);
			else
				comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
			if (initial != null)
			{
				var items = initial as T[] ?? initial.ToArray();
				HeapArray = new T[items.Count()];
				foreach (var item in items)
				{
					Add(item);
				}
			}
			else HeapArray = new T[128];
		}
		public BinaryHeap()
		{
			HeapArray = new T[128];
			position = 0;
			Count = 0;
		}
		public BinaryHeap(int _size)
		{
			HeapArray = new T[_size];
			position = 0;
			Count = 0;
		}
		public BinaryHeap(IEnumerable<T> collection)
		{
			HeapArray = new T[collection.Count()]; //boyle oldugu zaman statik olarak sabit sayida veri ekleniyor ve add fonksiyonu calismiyor o yuzden 128 yapildi
												   //HeapArray = new T[128];
			position = 0;
			Count = 0;
			foreach (var item in collection)
			{
				Add(item);
			}
		}
		public void AddRange(IEnumerable<T> collection)
		{
			foreach (var item in collection)
			{
				Add(item);
			}
		}
		//0 based index, for tree; (lever ordered)
		private int GetLeftChildIndex(int i) => i * 2 + 1;
		private int GetRightChildIndex(int i) => i * 2 + 2;
		private int GetParentIndex(int i) => (i - 1) / 2;
		private bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
		private bool HasRightChild(int i) => GetRightChildIndex(i) < position;
		private bool IsRoot(int i) => i == 0; //i = 0 ise ilk elemandır yani koktur 
		private T GetLeftChild(int i) => HeapArray[GetLeftChildIndex(i)];
		private T GetRightChild(int i) => HeapArray[GetRightChildIndex(i)];
		private T GetParent(int i) => HeapArray[GetParentIndex(i)];
		public bool IsEmpty() => position == 0;
		public T Peek() => IsEmpty() ? throw new Exception("Empty Heap!") : HeapArray[0];
		private void Swap(int first, int second)
		{
			var temp = HeapArray[first];
			HeapArray[first] = HeapArray[second];
			HeapArray[second] = temp;
		}
		public void Add(T value)
		{
			if (position == HeapArray.Length) throw new IndexOutOfRangeException("overflow!");
			HeapArray[position] = value;
			position++;
			Count++;
			HeapifyUp(); //yeni eklenen degerin son indexe eklendikten sonra min heap veya max heap yapisina uymuyorsa yukari dogru parentlerle yer degistiririz..
		}
		public T DeleteMinMax()
		{
			if (position == 0) throw new Exception("Empty Heap!");
			var temp = HeapArray[0];
			HeapArray[0] = HeapArray[position - 1]; //son elemani koke yerlestiriyoruz
			position--;
			Count--;
			HeapifyDown(); //min heap ve max heapte farklı calisacak (indisteki degerlerin yerlerini degistirerek min heap veya max heape gore duzenleyecegiz)
			return temp;
		}
		protected void HeapifyUp() { }
		protected void HeapifyDown() { }
		public IEnumerator<T> GetEnumerator() => HeapArray.Take(position).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}

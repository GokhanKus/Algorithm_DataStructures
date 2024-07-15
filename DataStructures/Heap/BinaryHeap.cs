using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Heap
{
	public abstract class BinaryHeap<T> : IEnumerable<T> where T : IComparable //foreach ile kullanmak istedigimiz icin IEnumerable ..
	{
		public T[] HeapArray { get; private set; }
		public int Count { get; private set; }
		protected int position;
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
			HeapArray = new T[collection.Count()];
			position = 0;
			Count = 0;
			foreach (var item in collection)
			{
				Add(item);
			}
		}
		//0 based index, for tree; (lever ordered)
		protected int GetLeftChildIndex(int i) => i * 2 + 1;
		protected int GetRightChildIndex(int i) => i * 2 + 2;
		protected int GetParentIndex(int i) => (i - 1) / 2;
		protected bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
		protected bool HasRightChild(int i) => GetRightChildIndex(i) < position;
		protected bool IsRoot(int i) => i == 0; //i = 0 ise ilk elemandır yani koktur 
		protected T GetLeftChild(int i) => HeapArray[GetLeftChildIndex(i)];
		protected T GetRightChild(int i) => HeapArray[GetRightChildIndex(i)];
		protected T GetParent(int i) => HeapArray[GetParentIndex(i)];
		public bool IsEmpty() => position == 0;
		public T Peek() => IsEmpty() ? throw new Exception("Empty Heap!") : HeapArray[0];
		public void Swap(int first, int second)
		{
			var temp = HeapArray[first];
			HeapArray[first] = HeapArray[second];
			HeapArray[second] = temp;
		}
		public void Add(T value)
		{
			if (position == HeapArray.Length) throw new IndexOutOfRangeException("overflow!");
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
		protected abstract void HeapifyUp();
		protected abstract void HeapifyDown();
		public IEnumerator<T> GetEnumerator() => HeapArray.Take(position).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}

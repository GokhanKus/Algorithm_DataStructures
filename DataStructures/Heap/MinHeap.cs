namespace DataStructuresLibrary.Heap
{
	public class MinHeap<T> : BHeap<T> where T : IComparable //no need to add IEnumerable<T> 'cause it's already added for BinaryHeap<T> class
	{
		public MinHeap() : base()
		{

		}
		public MinHeap(int _size) : base(_size)
		{

		}
		public MinHeap(IEnumerable<T> collection) : base(collection)
		{

		}
		protected override void HeapifyDown() //min heap agac yapisinda en kucuk deger(root) silindiginde..
		{
			int index = 0;
			while (HasLeftChild(index))
			{
				var smallerIndex = GetLeftChildIndex(index);
				if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) < 0) //childların value'ları karsilastirilir
				{
					smallerIndex = GetRightChildIndex(index);//buraya girerse sag child ile girmezse sol child ile swaplenir alttaki swap() metodunda..
				}
				if (HeapArray[smallerIndex].CompareTo(HeapArray[index]) >= 0)
					break;

				Swap(smallerIndex, index);
				index = smallerIndex;
			}
		}

		protected override void HeapifyUp() //min heap agac yapisinda son indise eklenen deger ve bu deger min heap yapisini bozabilir o yuzden yukarı yonlu swap (HeapifyUp)
		{
			int index = position - 1; //son eklenen elemani temsil eder
			while (!IsRoot(index) && HeapArray[index].CompareTo(GetParent(index)) < 0) //son eklenen deger parent'dan kucukse ve kok degilse..
			{
				var parentIndex = GetParentIndex(index);
				Swap(parentIndex, index);
				index = parentIndex;
			}
		}
	}
}

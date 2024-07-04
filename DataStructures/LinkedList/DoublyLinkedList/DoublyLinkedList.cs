using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.LinkedList.DoublyLinkedList
{
	public class DoublyLinkedList<T>
	{
		public DoublyLinkedListNode<T> Head { get; set; }
		public DoublyLinkedListNode<T> Tail { get; set; }

		//linked list basina eleman ekleme big O(1)
		public void AddFirst(T value)
		{
			var newNode = new DoublyLinkedListNode<T>(value);
			if (Head != null)
				Head.Prev = newNode;

			newNode.Next = Head;
			newNode.Prev = null; //yeni eklendigi icn previ null olacak, yine de null atayalim
			Head = newNode;
			if (Tail is null)
				Tail = Head;
		}
	}
}

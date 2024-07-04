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

		public void AddLast(T value)
		{
			if (Tail is null)
			{
				AddFirst(value);
				return;
			}
			var newNode = new DoublyLinkedListNode<T>(value);
			Tail.Next = newNode;
			newNode.Prev = Tail;
			newNode.Next = null;
			Tail = newNode;
		}
		public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
		{
			if (refNode == null)
				throw new ArgumentNullException();
			if (refNode == Head && refNode == Tail) // listede sadece 1 dugum oldugu durum
			{
				refNode.Next = newNode;
				refNode.Prev = null;

				newNode.Next = null;
				newNode.Prev = refNode;

				Tail = newNode;
				Head = refNode;

				return;
			}
			if (refNode != Tail) //yani eklenecek olan eleman listenin arasındaysa
			{
				newNode.Prev = refNode;
				newNode.Next = refNode.Next;

				refNode.Next.Prev = newNode;
				refNode.Next = newNode;
			}
			else //eklenecek eleman tail ise yani son elemandan sonra eklenecekse;
			{
				refNode.Next = newNode;
				newNode.Prev = refNode;
				newNode.Next = null;
				Tail = newNode;
			}
		}
		public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
		{
			if (refNode == null)
				throw new ArgumentNullException();
			if (refNode == Head && refNode == Tail)// listede sadece 1 dugum oldugu durum
			{
				newNode.Next = refNode;
				newNode.Prev = null;

				refNode.Prev = newNode;
				refNode.Next = null;

				Tail = refNode;
				Head = newNode;
				return;
			}
			if (refNode != Head) //yani eklenecek olan eleman listenin arasındaysa
			{
				newNode.Prev = refNode.Prev;
				newNode.Next = refNode;

				refNode.Prev.Next = newNode;
				refNode.Prev = newNode;
			}
			else //eklenecek olan eleman head ise yani ilk elemandan once eklenecekse
			{
				refNode.Prev = newNode;
				newNode.Next = refNode;
				newNode.Prev = null;
				Head = newNode;
			}
		}
	}
}

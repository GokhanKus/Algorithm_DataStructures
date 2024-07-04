using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.LinkedList.DoublyLinkedList
{
	public class DoublyLinkedList<T> : IEnumerable //IEnumerable<T> olarak yapmadigimiz icin program.cs'te linq metotlari gelmedi
	{
		public DoublyLinkedListNode<T>? Head { get; set; }
		public DoublyLinkedListNode<T>? Tail { get; set; }
		private bool isHeadNull => Head == null;
		private bool isTailNull => Tail == null;
		//linked list basina eleman ekleme big O(1)
		public DoublyLinkedList()
		{

		}
		public DoublyLinkedList(params T[] values)
		{
			foreach (var item in values)
			{
				AddLast(item);
			}
		}
		public DoublyLinkedList(IEnumerable<T> collection)
		{
			foreach (var item in collection)
			{
				AddLast(item);
			}
		}
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
		public T RemoveFirst()
		{
			if (isHeadNull)
				throw new Exception();

			var temp = Head.Value;
			if (Head == Tail) //1 eleman varsa onu silecegiz bu if kısmında ve head ile tail null olmalı
			{
				Head = null;
				Tail = null;
			}
			else
			{
				Head = Head.Next;
				Head.Prev = null;
			}
			return temp;
		}
		public T RemoveLast()
		{
			if (isTailNull)
				throw new Exception();
			var temp = Tail.Value;

			if (Head == Tail)
			{
				Head = null;
				Tail = null;
			}
			else
			{
				Tail = Tail.Prev;
				Tail.Next = null;

				//Tail.Prev.Next = null;
				//Tail = Tail.Prev;
			}
			return temp;
		}
		public void Remove(T value)
		{
			if (isHeadNull || isTailNull)
				throw new Exception("empty list");

			if (Head == Tail) // tek eleman var demektir
			{
				if (Head.Value.Equals(value))
					RemoveFirst();
				return;
			}
			var current = Head;
			while (current != null)
			{
				if (current.Value.Equals(value))
				{
					if (current.Prev == null) //ilk eleman silinecek demektir
					{
						Head = current.Next;
						current.Next.Prev = null;
						return;
					}

					else if (current.Next == null) //son eleman silinecek demektir
					{
						Tail = current.Prev;
						current.Prev.Next = null;
						return;
					}
					else //silinecek eleman arada bir yerde..
					{
						current.Prev.Next = current.Next;
						current.Next.Prev = current.Prev;
						return;
					}
				}
				current = current.Next;
			}
			throw new Exception("the value could not be found in the list!");
		}
		private List<DoublyLinkedListNode<T>> GetAllNodes()
		{
			var list = new List<DoublyLinkedListNode<T>>();
			var current = Head;
			while (current != null)
			{
				list.Add(current);
				current = current.Next;
			}
			return list;
		}

		public IEnumerator GetEnumerator()
		{
			return GetAllNodes().GetEnumerator();
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.LinkedList.SinglyLinkedList
{
	public class SinglyLinkedList<T> : IEnumerable<T>
	{
		public SinglyLinkedList()
		{

		}
		public SinglyLinkedList(IEnumerable<T> collection)
		{
			foreach (var item in collection)
			{
				AddLast(item);
			}
		}
		public SinglyLinkedList(params T[] values)
		{
			foreach (var value in values)
			{
				AddLast(value);
			}
		}
		public SinglyLinkedListNode<T>? Head { get; set; } //ilk node'umuz, ilk degerimiz
		private bool isHeadNull => Head == null;

		//Big O(1)
		public T RemoveFirst()
		{
			if (isHeadNull)
				throw new Exception("nothing to remove");
			var firstValue = Head.Value;
			Head = Head.Next;
			return firstValue;
		}
		//big O(n)
		public T RemoveLast()
		{
			var current = Head;
			SinglyLinkedListNode<T> prev = null; // current'dan bir onceki dugum
			while (current.Next != null)
			{
				prev = current;
				current = current.Next;
			}
			var lastValue = prev.Next.Value;
			prev.Next = null;
			return lastValue;
		}
		public void Remove(T value)
		{
			if (isHeadNull)
				throw new Exception("nothing to remove");
			if (value == null)
				throw new ArgumentNullException();

			var current = Head;
			SinglyLinkedListNode<T>? prev = null;
			do
			{
				if (current.Value.Equals(value))//current.Value == value yazamazsın T'Den T'ye olmaz generic prog, o yuzden equals()
				{
					if (current.Next == null)//son eleman mı? 
					{
						if (prev == null) //head ve tek eleman vardir, silinmek istenen deger head olabilir
						{
							Head = null;
							return;
						}

						else //son eleman, silinmek istenen deger son dugum olabilir
						{
							prev.Next = null;
							return;
						}
					}
					else
					{
						if (prev == null) //head
						{
							Head = Head.Next;
							return;
						}

						else //esas ifade burasi
						{
							prev.Next = current.Next;
							return;
						}
					}
				}
				prev = current;
				current = current.Next;
			} while (current != null);
			throw new Exception("the value could not be found in the list!");
		}
		//veri eklerken ilk dugume ekleme metodu Head kısmı degisir big O(1)
		//bu metot her zaman listenin basina ekleme yapar
		public void AddFirst(T value)
		{
			var newNode = new SinglyLinkedListNode<T>(value); //parametre olarak gelen deger ile yeni node olusturuluyor ve next propu(pointer) null oluyor
			newNode.Next = Head; //bu satirda yeni eklenen dugume (newNode) headi isaret etmesini soyluyoruz
			Head = newNode; //bu satirda yeni headimiz yani ilk node'umuz newNode oluyor
		}
		//head'den baslayip son elemana kadar gider sona ekler big O(n)
		public void AddLast(T value)
		{
			var newNode = new SinglyLinkedListNode<T>(value);
			if (isHeadNull) //listede hic eleman olmayabilir
			{
				Head = newNode;
				return;
			}
			var current = Head;
			while (current.Next != null) //bastan baslayip listenin son elemanına kadar gider
			{
				current = current.Next;
			}
			current.Next = newNode;
			LinkedList<int> asd = new LinkedList<int>();
		}
		//hangi dugumden sonra bir dugum eklemek istiyoruz? big O(n) araya ekleme yapar AddLast ile benzer ozellikte
		public void AddAfter(SinglyLinkedListNode<T> refNode, T value)
		{
			if (refNode == null)
				throw new ArgumentException("node cannot be null");

			if (isHeadNull)
			{
				AddFirst(value);
				return;
			}

			var newNode = new SinglyLinkedListNode<T>(value);
			var current = Head;
			while (current != null)
			{
				if (current == refNode)
				{
					newNode.Next = current.Next; //ekledigimiz node'un next'i kendisinden sonra gelen node'u gosterecek
					current.Next = newNode; //burasi current'in, yani hangi node'dan sonra eklemek istiyorsak o node'un nexti, eklemek istedigimiz degeri gosterecek
					return;
				}
				current = current.Next;
			}
			throw new ArgumentException("the reference node is not in this list");
		}

		public void AddBefore(SinglyLinkedListNode<T> refNode, T value)
		{
			if (refNode == null)
				throw new ArgumentException("node cannot be null");

			if (isHeadNull)
			{
				AddFirst(value);
				return;
			}
			var newNode = new SinglyLinkedListNode<T>(value);
			var current = Head;
			while (current.Next != null)
			{
				if (current.Next == refNode)
				{
					newNode.Next = current.Next;
					current.Next = newNode;
					return;
				}
				current = current.Next;
			}
			throw new ArgumentException("the reference node is not in this list");
		}
		public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
		{
			throw new NotImplementedException();
		}
		public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new SinglyLinkedListEnumerator<T>(Head);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

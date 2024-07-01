using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.LinkedList.SinglyLinkedList
{
	public class SinglyLinkedList<T>
	{
		public SinglyLinkedListNode<T>? Head { get; set; } //ilk node'umuz, ilk degerimiz
        private bool isHeadNull => Head == null;

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
	}
}

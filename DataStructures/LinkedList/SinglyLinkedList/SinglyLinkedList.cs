using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.LinkedList.SinglyLinkedList
{
	public class SinglyLinkedList<T>
	{
		public SinglyLinkedListNode<T> Head { get; set; } //ilk node'umuz, ilk degerimiz

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
			if (Head == null) //listede hic eleman olmayabilir
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
		}
	}
}

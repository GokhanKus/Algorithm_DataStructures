using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.LinkedList.SinglyLinkedList
{
	public class SinglyLinkedListNode<T>
	{
		public SinglyLinkedListNode<T>? Next { get; set; } //pointer bir sonraki degeri isaret eden propumuz.
        public T Value { get; set; } // node
		public SinglyLinkedListNode(T value)
		{
			Value = value;
		}
		public override string ToString() => $"{Value}";
	}
}

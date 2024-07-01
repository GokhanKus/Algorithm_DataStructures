using DataStructuresLibrary.LinkedList.SinglyLinkedList;

namespace LinkedList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var linkedList = new SinglyLinkedList<int>();
			linkedList.AddFirst(1);
			linkedList.AddFirst(2);
			linkedList.AddFirst(3);
			//3 2 1 
			linkedList.AddLast(4);
			linkedList.AddLast(5);
			//3 2 1 4 5
			linkedList.AddAfter(linkedList.Head.Next.Next, 32);
			//3 2 1 32 4 5
			linkedList.AddBefore(linkedList.Head.Next.Next, 30);
			//3 2 30 1 32 4 5

		}
	}
}

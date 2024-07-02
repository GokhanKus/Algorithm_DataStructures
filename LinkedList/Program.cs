using DataStructuresLibrary.LinkedList.SinglyLinkedList;

namespace LinkedList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//LinkedListApp1();
			//LinkedListApp2();
			//LinkedListApp3();
			//LinkedListApp4();
		}

		private static void LinkedListApp4()
		{
			var linkedList = new SinglyLinkedList<int>();
			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);
			linkedList.AddFirst(0);
			linkedList.RemoveFirst();
			linkedList.RemoveLast();
		}

		private static void LinkedListApp3()
		{
			var rnd = new Random();
			var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
			var linkedList = new SinglyLinkedList<int>(initial);

			var q = from item in linkedList
					where item % 2 == 0
					select item;

			foreach (var item in q)
			{
				Console.WriteLine(item);
			}

			linkedList.Where(x => x > 5).ToList().ForEach(x => Console.Write(x + " "));
		}
		private static void LinkedListApp2()
		{
			var charList = new List<char> { 'a', 'b', 'c' };
			var linkedList2 = new SinglyLinkedList<char>(charList);
			foreach (var item in linkedList2)
			{
				Console.WriteLine(item);
			}
			var linkedList3 = new SinglyLinkedList<int>(1, 5, 11, 16);
		}
		private static void LinkedListApp1()
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
			foreach (var item in linkedList)
			{
				Console.WriteLine(item);
			}
		}
	}
}

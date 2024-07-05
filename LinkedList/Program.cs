using DataStructuresLibrary.LinkedList.DoublyLinkedList;
using DataStructuresLibrary.LinkedList.SinglyLinkedList;

namespace LinkedList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//SinglyLinkedListApp1();
			//SinglyLinkedListApp2();
			//SinglyLinkedListApp3();
			//SinglyLinkedListApp4();
			//SinglyLinkedListApp5();

			//DoublyLinkedListApp1();
			DoublyLinkedListApp2();
		}
		private static void DoublyLinkedListApp2()
		{
			var names = new DoublyLinkedList<string>("molly", "polly", "tilly", "billy");
			var numbers = new DoublyLinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
			var chars = new DoublyLinkedList<char>(new List<char> { 'a', 'b', 'c', 'd' });
			numbers.Remove(5);
			string a1 = names.RemoveFirst();
			string a2 = names.RemoveLast();
			int b1 = numbers.RemoveFirst();
			int b2 = numbers.RemoveLast();
			char c1 = chars.RemoveFirst();
			char c2 = chars.RemoveLast();

			foreach (var name in names)
			{
				Console.Write(name + " ");
			}
			foreach (var number in numbers)
			{
				Console.Write(number + " ");
			}
			foreach (var character in chars)
			{
				Console.Write(character + " ");
			}
		}
		private static void DoublyLinkedListApp1()
		{
			var dbLinkedList = new DoublyLinkedList<int>();
			//dbLinkedList.AddFirst(3);
			//dbLinkedList.AddFirst(2);
			//dbLinkedList.AddFirst(1);
			dbLinkedList.AddLast(4);
			dbLinkedList.AddLast(5); // 4 5 
			dbLinkedList.AddAfter(dbLinkedList.Head, new DoublyLinkedListNode<int>(20)); // 4 20 5
			dbLinkedList.AddBefore(dbLinkedList.Head, new DoublyLinkedListNode<int>(30)); //30 4 20 5
			dbLinkedList.AddBefore(dbLinkedList.Head.Next.Next, new DoublyLinkedListNode<int>(50)); //30 4 50 20 5
																									//var nodeList = dbLinkedList.GetAllNodes(); //dugumleri bir listeye atar
			foreach (var item in dbLinkedList)
			{
				Console.WriteLine(item);
			}
		}
		private static void SinglyLinkedListApp5()
		{
			var list = new SinglyLinkedList<int>(2, 4, 8, 16, 32);
			list.Remove(2);
			list.Remove(32);
			list.Remove(8);

			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
		private static void SinglyLinkedListApp4()
		{
			var linkedList = new SinglyLinkedList<int>();
			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);
			linkedList.AddFirst(0);
			linkedList.RemoveFirst();
			linkedList.RemoveLast();
		}
		private static void SinglyLinkedListApp3()
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
		private static void SinglyLinkedListApp2()
		{
			var charList = new List<char> { 'a', 'b', 'c' };
			var linkedList2 = new SinglyLinkedList<char>(charList);
			foreach (var item in linkedList2)
			{
				Console.WriteLine(item);
			}
			var linkedList3 = new SinglyLinkedList<int>(1, 5, 11, 16);
		}
		private static void SinglyLinkedListApp1()
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

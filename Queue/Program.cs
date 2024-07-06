using DataStructuresLibrary.Queue;

namespace Queue
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = { 10, 20, 30, 40, 50 };
			var q1 = new CustomQueue<int>(); //QueueType.Array (Generic List)
			var q2 = new CustomQueue<int>(QueueType.LinkedList); //DoublyLinkedList

			foreach (int number in numbers)
			{
				Console.WriteLine(number);
				q1.EnQueue(number);
				q2.EnQueue(number);
			}

			Console.WriteLine($"q1 peek: {q1.Peek()}");
			Console.WriteLine($"q2 peek: {q2.Peek()}");

			Console.WriteLine($"q1 Dequeue: {q1.DeQueue()}");
			Console.WriteLine($"q2 Dequeue: {q2.DeQueue()}");

			Console.WriteLine($"q1 Size: {q1.Size()}");
			Console.WriteLine($"q2 Size: {q2.Size()}");

			Console.WriteLine($"q1 Rear: {q1.Rear()}");
			Console.WriteLine($"q2 Rear: {q2.Rear()}");

			Console.WriteLine($"q1 Front: {q1.Front()}");
			Console.WriteLine($"q2 Front: {q2.Front()}");

			Console.WriteLine($"q1 Count: {q1.Count}");
			Console.WriteLine($"q2 Count: {q2.Count}");
			
		}
	}
}

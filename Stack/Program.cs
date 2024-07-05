using DataStructuresLibrary.Stack;

namespace Stack
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var charSet = new char[] { 'a', 'b', 'c', 'd', 'e' };
			var stack1 = new CustomStack<char>(); //bizim olusturdugumuz stack yapisi bu stack List tipindedir belirtmezsek default bu..
			var stack2 = new CustomStack<char>(StackType.LinkedList); //bizim olusturdugumuz stack yapisi bu stack linkedlist tipindedir
			foreach (var c in charSet)
			{
				Console.WriteLine(c);
				stack1.Push(c);
				stack2.Push(c);
			}
			Console.WriteLine($"stack1 Peek item: {stack1.Peek()}"); //silinecek son elemani gosterir
			Console.WriteLine($"stack2 Peek item: {stack2.Peek()}");

			Console.WriteLine($"stack1 Popped item: {stack1.Pop()}"); //son elemani siler ve gosterir
			Console.WriteLine($"stack2 Popped item: {stack2.Pop()}");

			Console.WriteLine($"stack1 Count: {stack1.Count}");
			Console.WriteLine($"stack2 Count: {stack2.Count}");
			
			//bu islemlerden sonra;
			//stack1 : a b c d generic list
			//stack2 : d c b a linked list
		}
	}
}

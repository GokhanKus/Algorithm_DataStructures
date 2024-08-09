using CustomTypesLibrary;

namespace CustomTypesApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var student = new Student(10, "Gokhan", 2.75);
			Console.WriteLine(student);
		}
	}
}

using CustomTypesLibrary;
using DataStructures.Array;

namespace CustomTypesApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//CustomTypeApp1();
			CustomTypeApp2();
		}
		private static void CustomTypeApp2()
		{
			var students = new Student[]
			{
				new Student(10,"Gokhan",2.75),
				new Student(15,"Ayse",2.80),
				new Student(20,"Ahmet",3.15),
				new Student(25,"Fatma",2.25),
				new Student(30,"Veli",3.55),
				new Student(35,"Zeynep",3.85),
				new Student(40,"Hakan",2.45),
				new Student(45,"Yagmur",3.00)
			};
			var arr = new Array<Student>(students);
			arr.Add(new Student(50, "Asli", 2.25));
			foreach (var student in arr)
			{
                Console.WriteLine(student);
            }
		}
		private static void CustomTypeApp1()
		{
			var student = new Student(10, "Gokhan", 2.75);
			Console.WriteLine(student);
		}
	}
}

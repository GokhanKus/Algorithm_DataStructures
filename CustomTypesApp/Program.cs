using CustomTypesLibrary;
using DataStructures.Array;
using DataStructuresLibrary.LinkedList.SinglyLinkedList;
using DataStructuresLibrary.Tree.BinarySearchTree;

namespace CustomTypesApp
{
	internal class Program
	{
		private static Student[] students;
		static void Main(string[] args)
		{
			students = new Student[]
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
			//CustomTypeApp1();
			//CustomTypeApp2();
			//CustomTypeApp3();
			CustomTypeApp4();
		}
		private static void CustomTypeApp4()
		{
			var linkedlist = new SinglyLinkedList<Student>(students);

			var bst = new BinarySearchTree<Student>(linkedlist);
			foreach (var student in bst)
			{
				Console.WriteLine(student);
			}
		}
		private static void CustomTypeApp3()
		{
			var linkedlist = new SinglyLinkedList<Student>(students);
			linkedlist.AddBefore(linkedlist.Head, new Student(55, "Tolga", 4.00));
			foreach (var student in linkedlist)
			{
				Console.WriteLine(student);
			}
		}
		private static void CustomTypeApp2()
		{
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

using DataStructuresLibrary.Tree.BinarySearchTree;
using DataStructuresLibrary.Tree.BinaryTree;
using System.Threading.Channels;
namespace BinaryTree
{
	public class Program
	{
		static void Main(string[] args)
		{
			//BSTApp1();
			//BSTApp2();
			BSTApp3();
		}

		private static void BSTApp3()
		{
			int[] values = { 15, 20, 17, 65, 5, 48 };
			
			var bst = new BinarySearchTree<int>(values);
			var minNode = bst.FindMin(bst.Root);
			var maxNode = bst.FindMax(bst.Root);
			Console.WriteLine($"Minimum Value: {minNode}");
			Console.WriteLine($"Maximum Value: {maxNode}");
		}
		private static void BSTApp2()
		{
			int[] values = { 15, 20, 17, 65, 5, 48 };
			var bst = new BinarySearchTree<int>(values);
			var bt = new BinaryTree<int>();

			Console.Write("InOrder Non Recursive: ");
			bt.InOrderNonRecursive(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.Write("PreOrder Non Recursive: ");
			bt.PreOrderNonRecursive(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.Write("PostOrder Non Recursive: ");
			bt.PostOrderNonRecursive(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.Write("Level Order Non Recursive: ");
			bt.LevelOrderNonRecursive(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			Console.ReadKey();
		}
		private static void BSTApp1()
		{
			int[] values = { 15, 20, 17, 65, 5, 48 };
			var bst = new BinarySearchTree<int>(values);
			var bt = new BinaryTree<int>();
			/*
					15
					/ \
				   5   20
				       / \
					  17  65
						  /
						 48
			 */

			Console.Write("InOrder: ");
			bt.InOrderRecursive(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.Write("PreOrder: ");
			bt.PreOrderRecursive(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.Write("PostOrder: ");
			bt.PostOrderRecursive(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.ReadKey();
		}


	}
}

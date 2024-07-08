using DataStructuresLibrary.Tree.BinarySearchTree;
using DataStructuresLibrary.Tree.BinaryTree;
using System.Threading.Channels;
namespace BinaryTree
{
	public class Program
	{
		static void Main(string[] args)
		{
			BSTApp1();
		}

		private static void BSTApp1()
		{
			int[] values = { 15, 20, 17, 65, 5, 48 };
			var bst = new BinarySearchTree<int>(values);
			/*
					15
					/ \
				   5   20
				       / \
					  17  65
						  /
						 48
			 */
			var bt = new BinaryTree<int>();

			Console.Write("InOrder: ");
			bt.InOrder(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.Write("PreOrder: ");
			bt.PreOrder(bst.Root).ForEach(node => Console.Write($"{node,-3} "));

			bt.ClearList();
			Console.WriteLine();

			Console.Write("PostOrder: ");
			bt.PostOrder(bst.Root).ForEach(node => Console.Write($"{node,-3} "));


			Console.ReadKey();
		}
	}
}

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
			//BSTApp3();
			//BSTApp4();
			//BSTApp5();
			BSTApp6();
		}

		private static void BSTApp6()
		{
			var bt = new BinaryTree<char>();
			bt.Root = new Node<char>('F');
			bt.Root.Left = new Node<char>('A');
			bt.Root.Right = new Node<char>('T');
			bt.Root.Left.Left = new Node<char>('D');
			var deepestNode = bt.DeepestNode();
			var maxDepth = BinaryTree<char>.MaxDepth(bt.Root);
			var nodes = bt.LevelOrderNonRecursive(bt.Root);
			foreach (var node in nodes)
			{
				Console.Write($"{node,-3} ");
			}
			Console.WriteLine();
			Console.WriteLine($"deeepest Node: {deepestNode}");
			Console.WriteLine($"Max Depth: {maxDepth}");
		}

		private static void BSTApp5()
		{
			/*
					15			depth:1
					/ \			
				   5   20		depth:2
				       / \		
					  17  65	depth:3
						  /		
						 48		depth:4 (Deepest Node: 48)
			 */
			byte[] values = { 15, 20, 17, 65, 5, 48 };
			var bst = new BinarySearchTree<byte>(values);
			var bt = new BinaryTree<byte>();

			var deepestNode = bt.DeepestNode(bst.Root);
			var maxDepth = BinaryTree<byte>.MaxDepth(bst.Root);
			var list = new BinaryTree<byte>().InOrderNonRecursive(bst.Root);

			foreach (var node in list)
			{
				Console.Write($"{node,-3} ");
			}

			Console.WriteLine();
			Console.WriteLine($"Min value: {bst.FindMin(bst.Root)}");
			Console.WriteLine($"Max value: {bst.FindMax(bst.Root)}");
			Console.WriteLine($"Max Depth: {maxDepth}");
			Console.WriteLine($"Deepest Node: {deepestNode}");
		}

		private static void BSTApp4()
		{
			List<int> values = new List<int> { 23, 16, 45, 3, 22, 37, 99 };
			var bst = new BinarySearchTree<int>(values);

			var removedNode = bst.Remove(bst.Root, 23);
			var removedNode2 = bst.Remove(bst.Root, 45);
			var removedNode3 = bst.Remove(bst.Root, 3);
			new BinaryTree<int>().InOrderRecursive(bst.Root).ForEach(node => Console.Write(node + " "));

			var keyNode = bst.Find(bst.Root, 22);
			Console.WriteLine($"keyNode Value: {keyNode.Value}\nkeyNode left: {keyNode.Left}\nkeyNode right: {keyNode.Right}");
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

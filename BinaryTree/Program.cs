using DataStructuresLibrary.Tree.BinarySearchTree;
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
			Console.ReadKey();
		}
	}
}

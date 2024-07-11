
using DataStructuresLibrary.Tree.BinaryTree;
using System.Collections;

namespace DataStructuresLibrary.Tree.BinarySearchTree
{
	public class BinarySearchTreeEnumerator<T> : IEnumerator<T> where T : IComparable
	{
		private List<Node<T>> list;
		private int indexer = -1;
		//public Node<T> Root { get; set; }
		//public Node<T>? _currentNode { get; set; }
		public BinarySearchTreeEnumerator(Node<T> root)
		{
			list = new BinaryTree<T>().LevelOrderNonRecursive(root); //farkli sekillerde de agaci dolasabiliriz
			//list = new BinaryTree<T>().InOrderNonRecursive(root);
		}
		public T Current => list[indexer].Value;
		object IEnumerator.Current => Current;
		public void Dispose() => list = null;
		public bool MoveNext()
		{
			indexer++;
			return indexer < list.Count ? true : false;
		}
		public void Reset() => indexer = -1;
	}
}
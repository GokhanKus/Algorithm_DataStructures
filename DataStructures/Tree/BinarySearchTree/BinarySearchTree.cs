using System.Collections;
using DataStructuresLibrary.Tree.BinaryTree;

namespace DataStructuresLibrary.Tree.BinarySearchTree
{
    //bir sinif CompareTo metoduna sahip degilse onu bst'de kullanamazsin node left right buyukse +1 esitse 0 kucukse -1 doner dugum degerleri karsilastirilabilir
    //o yuzden kisitlama getirdik IComparable
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable
	{
		public Node<T>? Root { get; set; }
		public BinarySearchTree()
		{
		}
		public BinarySearchTree(IEnumerable<T> collection)
		{
			foreach (var value in collection)
				Add(value);
		}
		public void Add(T value)
		{
			if (value is null)
				throw new ArgumentNullException();
			var newNode = new Node<T>(value);

			if (Root == null)
				Root = newNode;
			else
			{
				var current = Root;
				Node<T> parent = current;
				while (true)
				{
					parent = current;
					//sol-alt agac
					if (value.CompareTo(current.Value) == -1) //-1 ise kucuk 0 ise esit 1 ise buyuktr
					{
						current = current.Left;
						if (current == null)
						{
							parent.Left = newNode;
							break;
						}
					}
					//sag-alt agac
					else
					{
						current = current.Right;
						if (current == null)
						{
							parent.Right = newNode;
							break;
						}
					}
				}
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

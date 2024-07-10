using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
		public Node<T> FindMin(Node<T> root)
		{
			var current = root;
			while (current.Left != null)
				current = current.Left;

			return current;
		}
		public Node<T> FindMax(Node<T> root)
		{
			var current = root;
			while (current.Right != null)
				current = current.Right;

			return current;
		}
		public Node<T> Find(Node<T> root, T value)// big O (log(n))
		{
			var current = root;
			//generic ifadelerde operator (=,<,>) kullanılmaz metot kullanilabilir
			while (value.CompareTo(current.Value) != 0) //karsilastirmanin sonucu +1 donerse buyuk, 0 ise esit, -1 ise kucuktur
			{
				if (value.CompareTo(current.Value) == -1)
					current = current.Left;
				else //+1 ise yani buyukse..
					current = current.Right;
				if (current == null)
					throw new ArgumentNullException("couldn't found the value in the tree");
				//return default(Node<T>);
			}
			return current;
		}
		public Node<T> Remove(Node<T> root, T value)
		{
			if (root == null)
				return root; //throw new ArgumentNullException();

			//recursive
			if (value.CompareTo(root.Value) < 0)
				root.Left = Remove(root.Left, value);
			else if (value.CompareTo(root.Value) > 0)
				root.Right = Remove(root.Right, value);
			else
			{
				//tek cocuk ya da cocuksuz
				if (root.Left == null)
					return root.Right;

				else if (root.Right == null)
					return root.Left;

				//iki cocuk
				root.Value = FindMin(root.Right).Value;
				root.Right = Remove(root.Right, root.Value);
			}
			return root;
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

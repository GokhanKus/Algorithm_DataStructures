using DataStructuresLibrary.Queue;
using DataStructuresLibrary.Stack;
using System.ComponentModel.Design;

namespace DataStructuresLibrary.Tree.BinaryTree
{
	public class BinaryTree<T> where T : IComparable
	{
		public List<Node<T>> list { get; private set; }
		public BinaryTree()
		{
			list = new List<Node<T>>();
		}
		public List<Node<T>> InOrderRecursive(Node<T> root) //left - data(root) - right order
		{
			if (root != null)
			{
				InOrderRecursive(root.Left);
				list.Add(root);
				InOrderRecursive(root.Right);
			}
			return list;
		}
		public List<Node<T>> PreOrderRecursive(Node<T> root) //data(root) - left - right order
		{
			if (root != null)
			{
				list.Add(root);
				PreOrderRecursive(root.Left);
				PreOrderRecursive(root.Right);
			}
			return list;
		}
		public List<Node<T>> PostOrderRecursive(Node<T> root) //left -  right order - data(root)
		{
			if (root != null)
			{
				PostOrderRecursive(root.Left);
				PostOrderRecursive(root.Right);
				list.Add(root);
			}
			return list;
		}
		public List<Node<T>> InOrderNonRecursive(Node<T> root)
		{
			List<Node<T>> list = new List<Node<T>>();
			var stack = new CustomStack<Node<T>>();
			var currentNode = root;
			bool done = false;
			while (!done)
			{
				if (currentNode != null)
				{
					stack.Push(currentNode);
					currentNode = currentNode.Left;
				}
				else
				{
					if (stack.Count == 0)
						done = true;
					else
					{
						currentNode = stack.Pop();
						list.Add(currentNode);
						currentNode = currentNode.Right;
					}
				}
			}
			return list;
		}
		public List<Node<T>> PreOrderNonRecursive(Node<T> root)
		{
			if (root == null) throw new ArgumentNullException();

			List<Node<T>> list = new List<Node<T>>();
			var stack = new CustomStack<Node<T>>();
			stack.Push(root);
			while (stack.Count != 0)
			{
				var temp = stack.Pop();
				list.Add(temp);

				if (temp.Right != null)
					stack.Push(temp.Right);

				if (temp.Left != null)
					stack.Push(temp.Left);
			}
			return list;
		}
		public List<Node<T>> PostOrderNonRecursive(Node<T> root)
		{
			List<Node<T>> list = new List<Node<T>>();
			if (root == null) return list;

			var stack1 = new CustomStack<Node<T>>();
			var stack2 = new CustomStack<Node<T>>();

			stack1.Push(root);

			while (stack1.Count > 0)
			{
				var node = stack1.Pop();
				stack2.Push(node);

				if (node.Left != null)
				{
					stack1.Push(node.Left);
				}

				if (node.Right != null)
				{
					stack1.Push(node.Right);
				}
			}

			while (stack2.Count > 0)
			{
				list.Add(stack2.Pop());
			}

			return list;
		}
		public List<Node<T>> LevelOrderNonRecursive(Node<T> root) //seviye bazli siralama 
		{
			List<Node<T>> list = new List<Node<T>>();
			var queue = new CustomQueue<Node<T>>();
			queue.EnQueue(root);
			while (queue.Count > 0)
			{
				var temp = queue.DeQueue();
				list.Add(temp);
				if (temp.Left != null)
					queue.EnQueue(temp.Left);
				if (temp.Right != null)
					queue.EnQueue(temp.Right);
			}
			return list;
		}

		public void ClearList() => list.Clear();
	}
}

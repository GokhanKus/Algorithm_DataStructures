using DataStructuresLibrary.Queue;
using DataStructuresLibrary.Stack;
using System.ComponentModel.Design;

namespace DataStructuresLibrary.Tree.BinaryTree
{
	public class BinaryTree<T> where T : IComparable
	{
		public Node<T>? Root { get; set; }
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
		public static int MaxDepth(Node<T> root)
		{
			if (root == null) return 0;

			int leftDepth = MaxDepth(root.Left);
			int rightDepth = MaxDepth(root.Right);

			return (leftDepth > rightDepth) ?
				leftDepth + 1 :
				rightDepth + 1;
		}
		public Node<T> DeepestNode(Node<T> root)
		{
			Node<T> deepestNode = null;
			if (root == null) throw new ArgumentNullException("empty tree!");

			var queue = new CustomQueue<Node<T>>();
			queue.EnQueue(root);
			while (queue.Count > 0)
			{
				deepestNode = queue.DeQueue();
				if (deepestNode.Left != null)
					queue.EnQueue(deepestNode.Left);
				if (deepestNode.Right != null)
					queue.EnQueue(deepestNode.Right);
			}
			return deepestNode;
		}
		public Node<T> DeepestNode()
		{
			var list = LevelOrderNonRecursive(Root);
			return list[list.Count - 1];
		}
		public int NumberOfLeaves1(Node<T> root) //number of leaf nodes on the tree
		{
			int count = 0;
			if (root == null) return count;

			var q = new CustomQueue<Node<T>>();
			q.EnQueue(root);
			while (q.Count > 0)
			{
				var temp = q.DeQueue();
				if (temp.Left == null && temp.Right == null) //eger node'un cocugu yoksa yaprak dugumdur
					count++;

				if (temp.Left != null)
					q.EnQueue(temp.Left);

				if (temp.Right != null)
					q.EnQueue(temp.Right);

			}
			return count;
		}
		public int NumberOfLeaves2(Node<T> root)
		{
			var numberOfLeaves = LevelOrderNonRecursive(root).Where(node => node.Left == null && node.Right == null).ToList().Count;
			return numberOfLeaves;
		}
		public int NumberOfFullNodes(Node<T> root) //cocugu olan dugumlerin sayisi 2 veya 1 
		{
			var numberOfLeaves = LevelOrderNonRecursive(root).Where(node => node.Left != null && node.Right != null).ToList().Count;
			return numberOfLeaves;
		}
		public int NumberOfHalfNodes(Node<T> root) //cocugu olan dugumlerin sayisi 2 veya 1 
		{
			var numberOfLeaves = LevelOrderNonRecursive(root)
				.Where(node => (node.Left != null && node.Right == null) || node.Left == null && node.Right != null)
				.ToList().Count;
			return numberOfLeaves;
		}
		public void PrintPaths(Node<T> root)
		{
			var path = new T[256];
			PrintPaths(root, path, 0);
		}

		private void PrintPaths(Node<T> root, T[] path, int pathLen)
		{
			if (root == null) return;

			path[pathLen] = root.Value;
			pathLen++;

			if (root.Left is null && root.Right is null) //yaprak dugum mu?
				PrintArray(path, pathLen);
			else
			{
				PrintPaths(root.Left, path, pathLen);
				PrintPaths(root.Right, path, pathLen);
			}

		}

		private void PrintArray(T[] path, int len)
		{
			for (int i = 0; i < len; i++)
				Console.Write($"{path[i]} ");
			Console.WriteLine();
		}
		public void ClearList() => list.Clear();
	}
}

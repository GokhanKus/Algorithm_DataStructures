using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Stack
{
	public class CustomStack<T>
	{
		private readonly IStack<T> stack;
		public int Count => stack.Count;
		public CustomStack(StackType type = StackType.Array)
		{
			if (type == StackType.Array)
				stack = new ArrayStack<T>();
			else
				stack = new LinkedListStack<T>();
		}
		public T Pop() //Stack'in tipine bagli olarak ArrayStack veya LinkedListStack nesnesindeki pop metodu calisacak POLYMORPHISM
		{
			return stack.Pop();
		}
		public T Peek()
		{
			return stack.Peek();
		}
		public void Push(T value)
		{
			stack.Push(value);
		}
		public void Clear()
		{
			stack.Clear();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.DisJointSet
{
	public class DisjointSetNode<T>
	{
		public T? Value { get; set; }
		public int Rank { get; set; }
		public DisjointSetNode<T>? Parent { get; set; }
		public DisjointSetNode()
		{

		}
		public DisjointSetNode(T value)
		{
			Value = value;
			Rank = 0;
			Parent = this;
		}
		public override string ToString()
		{
			return $"{Value}";
		}
	}
}

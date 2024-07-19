using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph
{
	public class Edge<T, C> : IEdge<T> where C : IComparable
	{
		public Edge(IVertex<T> target, C weight)
		{
			TargetVertex = target;
			_weight = weight;
		}
		private object _weight;
		public T TargetVertexKey => TargetVertex.Key;
		public IVertex<T> TargetVertex { get; private set; }
		public W Weight<W>() where W : IComparable
		{
			return (W)_weight;
		}
		public override string ToString()
		{
			return TargetVertex.Key.ToString();
		}
	}
}

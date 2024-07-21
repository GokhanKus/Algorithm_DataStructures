using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph
{
	public class Edge<T, TW> : IEdge<T> where TW : IComparable
	{
		public Edge(IVertex<T> target, TW weight)
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
	public class DirectedEdge<T, TW> : IDirectedEdge<T>
	{
		private object _weight;
		public IDirectedVertex<T> TargetVertex { get; private set; }
		public T TargetVertexKey => TargetVertex.Key;
		IVertex<T> IEdge<T>.TargetVertex => TargetVertex as IVertex<T>;
		public W Weight<W>() where W : IComparable
		{
			return (W)_weight;
		}
		public override string ToString()
		{
			return $"{TargetVertexKey}";
		}
	}
}

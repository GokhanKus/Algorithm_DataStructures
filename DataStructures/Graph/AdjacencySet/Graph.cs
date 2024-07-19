using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class Graph<T> : IGraph<T>
	{
		public bool IsWeightedGraph => throw new NotImplementedException();
		public int Count => throw new NotImplementedException();
		public IVertex<T> ReferenceVertex => throw new NotImplementedException();
		public IEnumerable<IVertex<T>> VertexesAsEnumerable => throw new NotImplementedException();
		public void AddVertex(T key)
		{
			throw new NotImplementedException();
		}
		public IGraph<T> Clone()
		{
			throw new NotImplementedException();
		}
		public bool ContainsVertex(T key)
		{
			throw new NotImplementedException();
		}
		public IEnumerable<T> Edges(T key)
		{
			throw new NotImplementedException();
		}
		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}
		public IVertex<T> GetVertex(T key)
		{
			throw new NotImplementedException();
		}
		public bool HasEdge(T source, T dest)
		{
			throw new NotImplementedException();
		}
		public void RemoveEdge(T source, T dest)
		{
			throw new NotImplementedException();
		}
		public void RemoveVertex(T key)
		{
			throw new NotImplementedException();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		private class Vertex<T> : IVertex<T>
		{
			public T Key { get; set; }
			public HashSet<Vertex<T>> Edges = new HashSet<Vertex<T>>();
			IEnumerable<IEdge<T>> IVertex<T>.Edges => Edges.Select(x => new Edge<T, int>(x, 1));
			public IEdge<T> GetEdge(IVertex<T> targetVertex)
			{
				return new Edge<T, int>(targetVertex, 1);
			}
			public IEnumerator<T> GetEnumerator()
			{
				return Edges.Select(x => x.Key).GetEnumerator();
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class DirectedGraph<T>:IDirectedGraph<T>
	{
		public IDirectedVertex<T> ReferenceVertex => throw new NotImplementedException();

		public IEnumerable<IDirectedVertex<T>> VertexesAsEnumerable => throw new NotImplementedException();

		public bool IsWeightedGraph => throw new NotImplementedException();

		public int Count => throw new NotImplementedException();

		IVertex<T> IGraph<T>.ReferenceVertex => throw new NotImplementedException();

		IEnumerable<IVertex<T>> IGraph<T>.VertexesAsEnumerable => throw new NotImplementedException();

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

		public IDirectedVertex<T> GetVertex(T key)
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

		IVertex<T> IGraph<T>.GetVertex(T key)
		{
			throw new NotImplementedException();
		}

		private class DirectedVertex<T> : IDirectedVertex<T>
		{
			public IEnumerable<IDirectedEdge<T>> OutEdges => throw new NotImplementedException();

			public IEnumerable<IDirectedEdge<T>> InEdged => throw new NotImplementedException();

			public int OutEdgesCount => throw new NotImplementedException();

			public int InEdgesCount => throw new NotImplementedException();

			public T Key => throw new NotImplementedException();

			public IEnumerable<IEdge<T>> Edges => throw new NotImplementedException();

			public IEdge<T> GetEdge(IVertex<T> targetVertex)
			{
				throw new NotImplementedException();
			}

			public IEnumerator<T> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			public IDirectedEdge<T> GetOutEdge(IDirectedVertex<T> targetVertex)
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}
	}
}

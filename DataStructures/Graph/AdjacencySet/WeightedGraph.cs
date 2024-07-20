using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class WeightedGraph<T, TW> : IGraph<T> where TW : IComparable
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
		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		private class WeightedVertex<T, TW> : IVertex<T> where TW : IComparable
		{
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
			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}
	}
}

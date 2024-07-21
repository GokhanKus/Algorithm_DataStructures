using System.Collections;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class DirectedGraph<T> : IDirectedGraph<T>
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
			public HashSet<DirectedVertex<T>> OutEdges { get; private set; }
			public HashSet<DirectedVertex<T>> InEdges { get; private set; }
			public DirectedVertex(T key)
			{
				Key = key;
				OutEdges = new HashSet<DirectedVertex<T>>();
				InEdges = new HashSet<DirectedVertex<T>>();
			}
			IEnumerable<IDirectedEdge<T>> IDirectedVertex<T>.OutEdges => OutEdges.Select(x => new DirectedEdge<T, int>(x, 1));
			IEnumerable<IDirectedEdge<T>> IDirectedVertex<T>.InEdges => InEdges.Select(x => new DirectedEdge<T, int>(x, 1));
			public int OutEdgesCount => OutEdges.Count;
			public int InEdgesCount => InEdges.Count;
			public T Key { get; set; }
			public IEnumerable<IEdge<T>> Edges => OutEdges.Select(x => new Edge<T, int>(x, 1));
			public IEdge<T> GetEdge(IVertex<T> targetVertex) =>
				new Edge<T, int>(targetVertex, 1);
			public IDirectedEdge<T> GetOutEdge(IDirectedVertex<T> targetVertex) =>
				new DirectedEdge<T, int>(targetVertex, 1);
			public IEnumerator<T> GetEnumerator() =>
				 OutEdges.Select(x => x.Key).GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}

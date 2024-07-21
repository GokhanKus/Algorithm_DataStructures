using System.Collections;
using System.Linq;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class DirectedGraph<T> : IDirectedGraph<T>
	{
		public DirectedGraph()
		{
			vertexes = new Dictionary<T, DirectedVertex<T>>();
		}
		public DirectedGraph(IEnumerable<T> collection)
		{
			vertexes = new Dictionary<T, DirectedVertex<T>>();
			foreach (var item in collection)
			{
				AddVertex(item);
			}
		}
		private Dictionary<T, DirectedVertex<T>> vertexes;
		public IDirectedVertex<T> ReferenceVertex => vertexes[this.First()];
		IVertex<T> IGraph<T>.ReferenceVertex => ReferenceVertex; // as IVertex<T>; 
		public IEnumerable<IDirectedVertex<T>> VertexesAsEnumerable => vertexes.Select(X => X.Value);
		IEnumerable<IVertex<T>> IGraph<T>.VertexesAsEnumerable => VertexesAsEnumerable; // as IEnumerable<IVertex<T>>;
		public bool IsWeightedGraph => false;
		public int Count => vertexes.Count;
		public void AddVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			var newVertex = new DirectedVertex<T>(key);
			vertexes.Add(key, newVertex);
		}
		public void AddEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			if (vertexes[source].OutEdges.Contains(vertexes[dest]) || vertexes[dest].InEdges.Contains(vertexes[source]))
				throw new Exception("the edge has been already defined!");

			vertexes[source].OutEdges.Add(vertexes[dest]);
			vertexes[dest].InEdges.Add(vertexes[source]);
		}
		IGraph<T> IGraph<T>.Clone()
		{
			return Clone();
		}
		public DirectedGraph<T> Clone()
		{
			var graph = new DirectedGraph<T>();

			foreach (var vertex in vertexes)
				graph.AddVertex(vertex.Key);

			foreach (var vertex in vertexes)
				foreach (var node in vertex.Value.OutEdges)
					graph.AddEdge(vertex.Value.Key, node.Key);

			return graph;
		}
		public bool ContainsVertex(T key) => vertexes.ContainsKey(key);
		public IEnumerable<T> Edges(T key)
		{
			if (key == null) throw new ArgumentNullException();
			return vertexes[key].OutEdges.Select(x => x.Key);
		}
		public IDirectedVertex<T> GetVertex(T key) => vertexes[key];
		IVertex<T> IGraph<T>.GetVertex(T key) => GetVertex(key);// as IVertex<T>;
		public bool HasEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			return vertexes[source].OutEdges.Contains(vertexes[dest]) && //a dugumunun kenari b dugumunu iceriyorsa 
				vertexes[dest].InEdges.Contains(vertexes[source]);      //b dugumunun kenari a dugumunu iceriyorsa 
		}
		public void RemoveEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			if (!vertexes[source].OutEdges.Contains(vertexes[dest]) || !vertexes[dest].InEdges.Contains(vertexes[source]))
				throw new Exception("the edge has been already defined!");

			vertexes[source].OutEdges.Remove(vertexes[dest]);
			vertexes[dest].InEdges.Remove(vertexes[source]);
		}
		public void RemoveVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			if (!vertexes.ContainsKey(key)) throw new ArgumentException("the vertex is not in this graph.");

			foreach (var vertex in vertexes[key].OutEdges) //dugumle ilgili olan kenarlari kaldiralim
				vertex.OutEdges.Remove(vertexes[key]);

			foreach (var vertex in vertexes[key].InEdges) //dugumle ilgili olan kenarlari kaldiralim
				vertex.InEdges.Remove(vertexes[key]);

			vertexes.Remove(key);
		}
		public IEnumerator<T> GetEnumerator()
		{
			return vertexes.Select(x => x.Key).GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
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

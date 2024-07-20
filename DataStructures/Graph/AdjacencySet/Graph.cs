using System.Collections;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class Graph<T> : IGraph<T>
	{
		public Graph()
		{
			vertexes = new Dictionary<T, Vertex<T>>();
		}
		public Graph(IEnumerable<T> collection)
		{
			vertexes = new Dictionary<T, Vertex<T>>();
			foreach (var item in collection)
			{
				AddVertex(item);
			}
		}
		private Dictionary<T, Vertex<T>> vertexes;
		public bool IsWeightedGraph => false;
		public int Count => vertexes.Count;
		public IVertex<T> ReferenceVertex => vertexes[this.First()];
		public IEnumerable<IVertex<T>> VertexesAsEnumerable => vertexes.Select(x => x.Value);
		public void AddVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			var newVertex = new Vertex<T>(key);
			vertexes.Add(key, newVertex);
		}
		IGraph<T> IGraph<T>.Clone() => Clone();
		public Graph<T> Clone()
		{
			var graph = new Graph<T>();

			foreach (var vertex in vertexes)
				graph.AddVertex(vertex.Key);

			foreach (var vertex in vertexes)
				foreach (var edge in vertex.Value.Edges)
					graph.AddEdge(vertex.Value.Key, edge.Key);

			return graph;
		}
		public bool ContainsVertex(T key) => vertexes.ContainsKey(key);
		public IEnumerable<T> Edges(T key)
		{
			if (key == null) throw new ArgumentNullException();
			return vertexes[key].Edges.Select(x => x.Key);
		}
		public IVertex<T> GetVertex(T key) => vertexes[key];
		public bool HasEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			return vertexes[source].Edges.Contains(vertexes[dest]) && //a dugumunun kenari b dugumunu iceriyorsa 
				vertexes[dest].Edges.Contains(vertexes[source]);      //b dugumunun kenari a dugumunu iceriyorsa 
		}
		public void AddEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			if (vertexes[source].Edges.Contains(vertexes[dest]) || vertexes[dest].Edges.Contains(vertexes[source]))
				throw new Exception("the edge has been already defined!");

			vertexes[source].Edges.Add(vertexes[dest]);
			vertexes[dest].Edges.Add(vertexes[source]);
		}
		public void RemoveEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			if (!vertexes[source].Edges.Contains(vertexes[dest]) || !vertexes[dest].Edges.Contains(vertexes[source]))
				throw new Exception("the edge has been already defined!");

			vertexes[source].Edges.Remove(vertexes[dest]);
			vertexes[dest].Edges.Remove(vertexes[source]);
		}
		public void RemoveVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			if (!vertexes.ContainsKey(key)) throw new ArgumentException("the vertex is not in this graph.");
			foreach (var vertex in vertexes[key].Edges) //dugumle ilgili olan kenarlari kaldiralim
				vertex.Edges.Remove(vertexes[key]);

			vertexes.Remove(key);
		}
		public IEnumerator<T> GetEnumerator() => vertexes.Select(x => x.Key).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		private class Vertex<T> : IVertex<T>
		{
			public T Key { get; set; }
			public HashSet<Vertex<T>> Edges { get; private set; }
			public Vertex(T key)
			{
				Key = key;
				Edges = new HashSet<Vertex<T>>();
			}
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

using System.Collections;
using System.Linq;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class WeightedGraph<T, TW> : IGraph<T> where TW : IComparable
	{
		private Dictionary<T, WeightedVertex<T, TW>> vertexes;
		public WeightedGraph()
		{
			vertexes = new Dictionary<T, WeightedVertex<T, TW>>();
		}
		public WeightedGraph(IEnumerable<T> collection)
		{
			vertexes = new Dictionary<T, WeightedVertex<T, TW>>();
			foreach (var weightedVertex in collection)
				AddVertex(weightedVertex);
		}
		public bool IsWeightedGraph => true;
		public int Count => vertexes.Count;
		public IVertex<T> ReferenceVertex => vertexes[this.First()];
		public IEnumerable<IVertex<T>> VertexesAsEnumerable => vertexes.Select(x => x.Value);
		public void AddVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			var newVertex = new WeightedVertex<T, TW>(key);
			vertexes.Add(key, newVertex);
		}
		IGraph<T> IGraph<T>.Clone() => Clone();
		public WeightedGraph<T, TW> Clone()
		{
			var graph = new WeightedGraph<T, TW>();

			foreach (var vertex in vertexes)
				graph.AddVertex(vertex.Key);

			foreach (var vertex in vertexes)
				foreach (var edge in vertex.Value.Edges)
					graph.AddEdge(vertex.Value.Key, edge.Key.Key, edge.Value);

			// edge.Key = weighted graph,  edge.Key.Key weighted graph'in anahtar degeri
			return graph;
		}
		public bool ContainsVertex(T key) => vertexes.ContainsKey(key);
		public IEnumerable<T> Edges(T key)
		{
			if (key == null) throw new ArgumentNullException();
			return vertexes[key].Edges.Select(x => x.Key.Key);
		}
		public IVertex<T> GetVertex(T key) => vertexes[key];
		public void AddEdge(T source, T dest, TW weight)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			vertexes[source].Edges.Add(vertexes[dest], weight);
			vertexes[dest].Edges.Add(vertexes[source], weight);
		}
		public bool HasEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			return vertexes[source].Edges.ContainsKey(vertexes[dest]) && //a dugumunun kenari b dugumunu iceriyorsa 
				vertexes[dest].Edges.ContainsKey(vertexes[source]);      //b dugumunun kenari a dugumunu iceriyorsa 
		}
		public void RemoveEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			if (!vertexes[source].Edges.ContainsKey(vertexes[dest]) || !vertexes[dest].Edges.ContainsKey(vertexes[source]))
				throw new Exception("the edge has been already defined!");

			vertexes[source].Edges.Remove(vertexes[dest]);
			vertexes[dest].Edges.Remove(vertexes[source]);
		}
		public void RemoveVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			if (!vertexes.ContainsKey(key)) throw new ArgumentException("the vertex is not in this graph.");

			foreach (var vertex in vertexes[key].Edges) //dugumle ilgili olan kenarlari kaldiralim
				vertex.Key.Edges.Remove(vertexes[key]);

			vertexes.Remove(key);
		}
		public IEnumerator<T> GetEnumerator() => vertexes.Select(x => x.Key).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		private class WeightedVertex<T, TW> : IVertex<T> where TW : IComparable
		{
			public T Key { get; set; }
			public Dictionary<WeightedVertex<T, TW>, TW> Edges;
			public WeightedVertex(T key)
			{
				Key = key;
				Edges = new Dictionary<WeightedVertex<T, TW>, TW>();
			}
			IEnumerable<IEdge<T>> IVertex<T>.Edges => Edges.Select(x => new Edge<T, TW>(x.Key, x.Value));
			public IEdge<T> GetEdge(IVertex<T> targetVertex)
			{
				TW typeWeight = Edges[targetVertex as WeightedVertex<T, TW>];
				return new Edge<T, TW>(targetVertex, typeWeight); //ilgili kenari alirken hedef vertex ve agirligiyla beraber aliyoruz
			}
			public IEnumerator<T> GetEnumerator()
			{
				return Edges.Select(x => x.Key.Key).GetEnumerator(); //x.Key dictionary'nin, 2. key ise prop'taki T Key ifadesine karsilik geliyor
			}
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}

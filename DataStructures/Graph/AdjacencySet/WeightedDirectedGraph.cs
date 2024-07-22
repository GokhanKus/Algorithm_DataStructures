using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph.AdjacencySet
{
	public class WeightedDirectedGraph<T, TW> : IDirectedGraph<T> where TW : IComparable
	{
		private Dictionary<T, WeightedDirectedVertex<T, TW>> vertexes;

		public WeightedDirectedGraph()
		{
			vertexes = new Dictionary<T, WeightedDirectedVertex<T, TW>>();
		}
		public WeightedDirectedGraph(IEnumerable<T> collection)
		{
			vertexes = new Dictionary<T, WeightedDirectedVertex<T, TW>>();
			foreach (var weightedDiVertex in collection)
				AddVertex(weightedDiVertex);
		}
		public IDirectedVertex<T> ReferenceVertex => vertexes[this.First()];
		IVertex<T> IGraph<T>.ReferenceVertex => ReferenceVertex;
		public IEnumerable<IDirectedVertex<T>> VertexesAsEnumerable => vertexes.Select(x => x.Value);
		IEnumerable<IVertex<T>> IGraph<T>.VertexesAsEnumerable => VertexesAsEnumerable;
		public bool IsWeightedGraph => true;
		public int Count => vertexes.Count;
		public void AddVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			var newVertex = new WeightedDirectedVertex<T, TW>(key);
			vertexes.Add(key, newVertex);
		}
		IGraph<T> IGraph<T>.Clone() => Clone();
		public WeightedDirectedGraph<T, TW> Clone()
		{
			var graph = new WeightedDirectedGraph<T, TW>();

			foreach (var vertex in vertexes)
				graph.AddVertex(vertex.Key);

			foreach (var vertex in vertexes)
				foreach (var node in vertex.Value.OutEdges)
					graph.AddEdge(vertex.Value.Key, node.Key.Key, node.Value);

			return graph;
		}
		public void AddEdge(T source, T dest, TW weight)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			if (vertexes[source].OutEdges.ContainsKey(vertexes[dest]) || vertexes[dest].InEdges.ContainsKey(vertexes[source]))
				throw new Exception("the edge has been already defined!");

			vertexes[source].OutEdges.Add(vertexes[dest], weight);
			vertexes[dest].InEdges.Add(vertexes[source], weight);
		}
		public bool HasEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			return vertexes[source].OutEdges.ContainsKey(vertexes[dest]) && //a dugumunun kenari b dugumunu iceriyorsa 
				vertexes[dest].InEdges.ContainsKey(vertexes[source]);      //b dugumunun kenari a dugumunu iceriyorsa 
		}
		public bool ContainsVertex(T key) => vertexes.ContainsKey(key);
		public IEnumerable<T> Edges(T key)
		{
			if (key == null) throw new ArgumentNullException();
			return vertexes[key].Edges.Select(x => x.TargetVertexKey);
			//return vertexes[key].OutEdges.Select(x => x.Key.Key);
		}
		public IDirectedVertex<T> GetVertex(T key) => vertexes[key];
		IVertex<T> IGraph<T>.GetVertex(T key) => GetVertex(key);
		public void RemoveEdge(T source, T dest)
		{
			if (source == null || dest == null)
				throw new ArgumentNullException();

			if (!vertexes.ContainsKey(source) || !vertexes.ContainsKey(dest))
				throw new ArgumentException("source or destination vertex is not in the graph.");

			if (!vertexes[source].OutEdges.ContainsKey(vertexes[dest]) || !vertexes[dest].InEdges.ContainsKey(vertexes[source]))
				throw new Exception("the edge has been already defined!");

			vertexes[source].OutEdges.Remove(vertexes[dest]);
			vertexes[dest].InEdges.Remove(vertexes[source]);
		}
		public void RemoveVertex(T key)
		{
			if (key == null) throw new ArgumentNullException();
			if (!vertexes.ContainsKey(key)) throw new ArgumentException("the vertex is not in this graph.");

			foreach (var vertex in vertexes[key].OutEdges) //dugumle ilgili olan kenarlari kaldiralim
				vertex.Key.OutEdges.Remove(vertexes[key]);

			foreach (var vertex in vertexes[key].InEdges) //dugumle ilgili olan kenarlari kaldiralim
				vertex.Key.InEdges.Remove(vertexes[key]);

			vertexes.Remove(key);
		}
		public IEnumerator<T> GetEnumerator() => vertexes.Select(x => x.Key).GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		private class WeightedDirectedVertex<T, TW> : IDirectedVertex<T> where TW : IComparable
		{
			public T Key { get; set; }
			public Dictionary<WeightedDirectedVertex<T, TW>, TW> OutEdges;
			public Dictionary<WeightedDirectedVertex<T, TW>, TW> InEdges;
			public WeightedDirectedVertex(T key)
			{
				Key = key;
				OutEdges = new Dictionary<WeightedDirectedVertex<T, TW>, TW>();
				InEdges = new Dictionary<WeightedDirectedVertex<T, TW>, TW>();
			}
			IEnumerable<IDirectedEdge<T>> IDirectedVertex<T>.OutEdges => OutEdges.Select(x => new DirectedEdge<T, TW>(x.Key, x.Value));
			IEnumerable<IDirectedEdge<T>> IDirectedVertex<T>.InEdges => InEdges.Select(x => new DirectedEdge<T, TW>(x.Key, x.Value));
			public IEnumerable<IEdge<T>> Edges => OutEdges.Select(x => new Edge<T, TW>(x.Key, x.Value));
			public int OutEdgesCount => OutEdges.Count;
			public int InEdgesCount => InEdges.Count;
			public IEdge<T> GetEdge(IVertex<T> targetVertex)
			{
				var node = OutEdges[targetVertex as WeightedDirectedVertex<T, TW>];
				return new Edge<T, TW>(targetVertex, node); //ilgili kenari alirken hedef vertex ve agirligiyla beraber aliyoruz
			}
			public IDirectedEdge<T> GetOutEdge(IDirectedVertex<T> targetVertex)
			{
				var node = OutEdges[targetVertex as WeightedDirectedVertex<T, TW>];
				return new DirectedEdge<T, TW>(targetVertex, node); //ilgili kenari alirken hedef vertex ve agirligiyla beraber aliyoruz
			}
			public IEnumerator<T> GetEnumerator() => OutEdges.Select(x => x.Key.Key).GetEnumerator();
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}

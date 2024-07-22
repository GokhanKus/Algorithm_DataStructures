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

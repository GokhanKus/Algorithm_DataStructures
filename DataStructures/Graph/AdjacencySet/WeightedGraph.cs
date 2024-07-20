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

using DataStructuresLibrary.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph.MinimumSpanningTree
{
	public class Prims<T, TW> where T : IComparable where TW : IComparable
	{
		public List<MSTEdge<T, TW>> FindMinimumSpanningTree(IGraph<T> graph)
		{
			var edges = new List<MSTEdge<T, TW>>();
			dfs(graph, graph.ReferenceVertex, new BinaryHeap<MSTEdge<T, TW>>(), new HashSet<T>(), edges);
			return edges;
		}
		private void dfs(IGraph<T> graph, IVertex<T> currentVertex, BinaryHeap<MSTEdge<T, TW>> spNeighbours, HashSet<T> spVertexes, List<MSTEdge<T, TW>> spEdges)
		{
			while (true)
			{
				//reference vertex'in bagli oldugu kenar bilgileri alindi
				foreach (var edge in currentVertex.Edges)
				{
					var e = new MSTEdge<T, TW>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<TW>());
					spNeighbours.Add(e); //binaryheap add metodu min heape gore eklenecek
				}
				var minEdge = spNeighbours.DeleteMinMax();
				//var olan kenarlari dikkate alma
				while (spVertexes.Contains(minEdge.Source) && spVertexes.Contains(minEdge.Destination))
				{
					minEdge = spNeighbours.DeleteMinMax();
					if (spNeighbours.Count == 0) return;
				}

				//vertex takibi (ziyaret edilen vertexler (dugumler) listeye alindi
				if (!spVertexes.Contains(minEdge.Source))
					spVertexes.Add(minEdge.Source);

				spVertexes.Add(minEdge.Destination);
				spEdges.Add(minEdge);

				currentVertex = graph.GetVertex(minEdge.Destination);
			}
		}
	}
}

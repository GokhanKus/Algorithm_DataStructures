using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph.Search
{
	public class DepthFirst<T>
	{
		public bool Find(IGraph<T> graph, T vertexKey)
		{
			return DFS(graph.ReferenceVertex, new HashSet<T>(), vertexKey);
		}
		private bool DFS(IVertex<T> current, HashSet<T> visited, T vertexKeyToSearch)
		{
			visited.Add(current.Key);
			Console.WriteLine(current.Key);
			if (current.Key.Equals(vertexKeyToSearch))
				return true;

			foreach (var edge in current.Edges)
			{
				if (visited.Contains(edge.TargetVertexKey)) continue;
				if (DFS(edge.TargetVertex, visited, vertexKeyToSearch)) return true;
			}
			return false;
		}
	}
}

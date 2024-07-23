using DataStructuresLibrary.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Graph.Search
{
	public class BreadthFirst<T>
	{
		public bool Find(IGraph<T> graph, T vertexKey)
		{
			return BFS(graph.ReferenceVertex, new HashSet<T>(), vertexKey);
		}
		private bool BFS(IVertex<T> referenceVertex, HashSet<T> visited, T vertexKeyToSearch)
		{
			var q = new CustomQueue<IVertex<T>>();
			q.EnQueue(referenceVertex);
			visited.Add(referenceVertex.Key);
			while (q.Count > 0)
			{

				var current = q.DeQueue();
				Console.WriteLine(current); //Vertex.cs (nested class ToString() override edildi ya da current.key yazdirilabilir)
				if (current.Key.Equals(vertexKeyToSearch)) return true;

				foreach (var edge in current.Edges)
				{
					if (visited.Contains(edge.TargetVertexKey)) continue;
					visited.Add(edge.TargetVertexKey);
					q.EnQueue(edge.TargetVertex);
				}
			}
			return false;
		}
	}
}

using DataStructuresLibrary.Graph;
using DataStructuresLibrary.Graph.AdjacencySet;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Graph
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//GraphApp();
			//WeightedGraphApp();
			DirectedGraphApp();
		}
		private static void DirectedGraphApp()
		{
			List<char> vertexes = new List<char>() { 'A', 'B', 'C', 'D', 'E' };
			var directedGraph = new DirectedGraph<char>(vertexes);

			directedGraph.AddEdge('A', 'D');
			directedGraph.AddEdge('B', 'A');
			directedGraph.AddEdge('C', 'A');
			directedGraph.AddEdge('C', 'B');
			directedGraph.AddEdge('C', 'D');
			directedGraph.AddEdge('C', 'E');
			directedGraph.AddEdge('D', 'E');

			directedGraph.RemoveVertex('C');
			//directedGraph.RemoveEdge('A', 'D');
			//directedGraph.RemoveEdge('C', 'D');
			//directedGraph.RemoveEdge('D', 'E');
			//directedGraph.RemoveVertex('D');

			foreach (var key in directedGraph) //key = 'A' ,'B' etc..
			{
				Console.Write($"{key} => ");
				//ilgili dugum uzerindeyken hangi dugumu / dugumleri isaret ediyor(yonlu oldugu dugumler)
				foreach (var pointedVertex in directedGraph.GetVertex(key)) //(directedGraph.Edges(key)
				{
					Console.Write($"   {pointedVertex}");
				}
				Console.WriteLine();
			}

			Console.WriteLine("is there an edge between A and B ? {0}", directedGraph.HasEdge('A', 'B') ? "Yes" : "No!");
			Console.WriteLine("is there an edge between B and A ? {0}", directedGraph.HasEdge('B', 'A') ? "Yes" : "No!");

			//Console.WriteLine("is there an edge between B and C ? {0}", directedGraph.HasEdge('B', 'C') ? "Yes" : "No!");
			//Console.WriteLine("is there an edge between C and B ? {0}", directedGraph.HasEdge('C', 'B') ? "Yes" : "No!");

			Console.WriteLine("is there an edge between A and E ? {0}", directedGraph.HasEdge('A', 'E') ? "Yes" : "No!");
			Console.WriteLine("is there an edge between E and A ? {0}", directedGraph.HasEdge('E', 'A') ? "Yes" : "No!");

			Console.WriteLine($"the number of vertexes: {directedGraph.Count}");
		}
		private static void WeightedGraphApp()
		{
			var weightedGraph = new WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });
			weightedGraph.AddVertex('E');

			weightedGraph.AddEdge('A', 'B', 1.2);
			weightedGraph.AddEdge('A', 'D', 2.3);
			weightedGraph.AddEdge('D', 'C', 5.5);

			foreach (var vertex in weightedGraph.VertexesAsEnumerable)
			{
				Console.Write(vertex.Key + " => ");
				foreach (var edge in vertex.Edges)
				{
					Console.Write($"  {vertex.Key} - {edge.Weight<double>()} - {edge.TargetVertexKey} ||");
				}
				Console.WriteLine();
			}
			//2 foreach de ayni
			//foreach (var vertex in weightedGraph)
			//{
			//	Console.Write($"{vertex} => ");
			//	foreach (var neighbourVertex in weightedGraph.Edges(vertex)) //weightedGraph.GetVertex(vertex)
			//	{
			//		var node = weightedGraph.GetVertex(neighbourVertex).GetEdge(weightedGraph.GetVertex(vertex));
			//		Console.Write($"  {vertex} - {node.Weight<double>()} - {neighbourVertex}");
			//	}
			//	Console.WriteLine();
			//}
			Console.WriteLine("is there an edge between A and B ? {0}", weightedGraph.HasEdge('A', 'B') ? "Yes" : "No!");
			Console.WriteLine("is there an edge between B and A ? {0}", weightedGraph.HasEdge('B', 'A') ? "Yes" : "No!");

			Console.WriteLine("is there an edge between B and C ? {0}", weightedGraph.HasEdge('B', 'C') ? "Yes" : "No!");
			Console.WriteLine("is there an edge between C and B ? {0}", weightedGraph.HasEdge('C', 'B') ? "Yes" : "No!");

			Console.WriteLine($"the number of vertex: {weightedGraph.Count}");
		}
		private static void GraphApp()
		{
			char[] vertexes = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
			var graph = new Graph<char>(vertexes);

			graph.AddEdge(vertexes[0], vertexes[1]);
			graph.AddEdge(vertexes[0], vertexes[3]);
			graph.AddEdge(vertexes[3], vertexes[2]);
			graph.AddEdge(vertexes[2], vertexes[4]);
			graph.AddEdge(vertexes[3], vertexes[4]);
			graph.AddEdge('E', 'F');
			graph.AddEdge('F', 'G'); //boyle de kenar eklenir

			//graph.RemoveVertex('A');
			//graph.RemoveEdge('E','F');

			var vertexD = graph.GetVertex('D');
			foreach (var neighbourVertex in vertexD)
			{
				Console.WriteLine(neighbourVertex);
			}
			//key = vertexlerin degeri 'A', 'B' gibi.. hangi dugum hangisiyle iliskili (has edge? between two vertex)
			foreach (var key in graph)
			{
				Console.Write(key + " => ");
				foreach (var item in graph.Edges(key)) //graph.GetVertex(key)
				{
					Console.Write($"  {item}");
				}
				Console.WriteLine();
			}
			Console.WriteLine("is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No!");
			Console.WriteLine("is there an edge between B and A ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No!");

			Console.WriteLine("is there an edge between A and C ? {0}", graph.HasEdge('A', 'C') ? "Yes" : "No!");
			Console.WriteLine("is there an edge between C and A ? {0}", graph.HasEdge('C', 'A') ? "Yes" : "No!");

			Console.WriteLine($"the number of vertex: {graph.Count}");
		}
	}
}

using DataStructuresLibrary.Graph.AdjacencySet;

namespace Graph
{
	internal class Program
	{
		static void Main(string[] args)
		{
			GraphApp1();
		}

		private static void GraphApp1()
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

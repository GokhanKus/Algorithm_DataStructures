
namespace DataStructuresLibrary.Graph
{
	public interface IGraph<T> : IEnumerable<T>
	{
		bool IsWeightedGraph { get; }
		int Count { get; }
		IVertex<T> ReferenceVertex { get; }
		IEnumerable<IVertex<T>> VertexesAsEnumerable { get; }
		IEnumerable<T> Edges(T key);
		IGraph<T> Clone();
		bool ContainsVertex(T key);
		IVertex<T> GetVertex(T key);
		bool HasEdge(T source, T dest);
		void AddVertex(T key);
		void RemoveVertex(T key);
		void RemoveEdge(T source, T dest);
	}
	public interface IVertex<T> : IEnumerable<T>
	{
		T Key { get; }
		IEnumerable<IEdge<T>> Edges { get; }
		IEdge<T> GetEdge(IVertex<T> targetVertex);
	}
	public interface IEdge<T>
	{
		T TargetVertexKey { get; }
		IVertex<T> TargetVertex { get; }
		W Weight<W>() where W : IComparable;
	}

	public interface IDirectedGraph<T> : IGraph<T>
	{
		new IDirectedVertex<T> ReferenceVertex { get; }
		new IEnumerable<IDirectedVertex<T>> VertexesAsEnumerable { get; }
		new IDirectedVertex<T> GetVertex(T key);
	}
	public interface IDirectedVertex<T> : IVertex<T>
	{
		IDirectedEdge<T> GetOutEdge(IDirectedVertex<T> targetVertex);
		IEnumerable<IDirectedEdge<T>> OutEdges { get; }
		IEnumerable<IDirectedEdge<T>> InEdged { get; }
		int OutEdgesCount { get; }
		int InEdgesCount { get; }
	}
	public interface IDirectedEdge<T> : IEdge<T>
	{
		new IDirectedVertex<T> TargetVertex { get; }
	}
}

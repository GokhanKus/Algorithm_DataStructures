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
		IEdge<T> GetEdge(IVertex<T> vertex);
	}
	public interface IEdge<T>  
	{
		T TargetVertexKey { get; }
		IVertex<T> TargetVertex { get; }
		W Weight<W>() where W : IComparable;
	}
}

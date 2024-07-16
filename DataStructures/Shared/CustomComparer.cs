namespace DataStructuresLibrary.Shared
{
	public class CustomComparer<T> : IComparer<T> where T : IComparable
	{
		private readonly bool isMax;
		private readonly IComparer<T> _comparer;
		public CustomComparer(SortDirection direction, IComparer<T> comparer)
		{
			isMax = direction == SortDirection.Descending; // eger azalan ise max heaptir ve isMax true doner
			_comparer = comparer;
		}
		public int Compare(T? x, T? y)
		{
			return isMax == false ? compare(x, y) : compare(y, x);
		}
		private int compare(T? x, T? y) => _comparer.Compare(x, y);
	}
}

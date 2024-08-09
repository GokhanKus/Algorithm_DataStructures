namespace CustomTypesLibrary
{
	public class Student : IComparable
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public double GPA { get; set; }
		public Student(int id, string name, double gpa)
		{
			Id = id;
			Name = name;
			GPA = gpa;
		}
		public Student()
		{

		}
		public override string ToString()
		{
			return $"{Id}   {Name}	 {GPA}";
		}
		public int CompareTo(object? obj)
		{
			var other = obj as Student;
			//return string.Compare(this.Name, other.Name); //isme gore siralasin ve bst inorder traversal olmali
			return this.GPA.CompareTo(other.GPA);
			//return this.Id.CompareTo(other.Id);
			//id'ye gorede karsilastirabilirdik ve bstde ekler isek sirali olmasini bekleriz
		}
	}
}

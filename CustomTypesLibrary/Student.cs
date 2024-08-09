namespace CustomTypesLibrary
{
	public class Student
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
			return $"{Id}\n{Name}\n{GPA}";
		}
	}
}

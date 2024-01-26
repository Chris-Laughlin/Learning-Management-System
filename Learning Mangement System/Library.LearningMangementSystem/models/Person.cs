namespace Library.LearningMangementSystem.models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Dictionary<int, double> Grades { get; set; }

        public List<Course> enrolledCourses { get; set; }

        public string? Classification { get; set; }

        public Person()
        {

            Grades = new Dictionary<int, double>();
        }

        public override string ToString()
        {
            return $"{Name} - {Classification}";
        }
    }
}

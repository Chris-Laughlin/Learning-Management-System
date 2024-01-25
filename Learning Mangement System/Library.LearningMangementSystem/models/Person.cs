namespace Library.LearningMangementSystem.models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Dictionary<int, double> Grades { get; set; }

        public char CLassification { get; set; }

        public Person()
        {
            Grades = new Dictionary<int, double>();
        }
    }
}

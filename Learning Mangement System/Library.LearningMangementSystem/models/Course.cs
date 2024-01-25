namespace Library.LearningMangementSystem.models
{
    public class Course
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Person> Roster { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Module> Modules { get; set; }

        public Course() {
            Roster = new List<Person> { };
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }
    }
}

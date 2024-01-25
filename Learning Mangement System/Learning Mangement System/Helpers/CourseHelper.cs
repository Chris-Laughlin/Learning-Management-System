using Library.LearningMangementSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Mangement_System.Helpers
{
    public class CourseHelper
    {
        private List<Course> courses = new List<Course>();
        public void CreateCourse() {
            Console.WriteLine("Enter Course Code: ");
            var courseCode = Console.ReadLine();
            Console.WriteLine("Enter Course Name: ");
            var courseName = Console.ReadLine();
            Console.WriteLine("Enter Course Description: ");
            var courseDescription = Console.ReadLine();

            var myCourse = new Course()
            {
                Code = courseCode ?? string.Empty,
                Name = courseName,
                Description = courseDescription
            };

            courses.Add(myCourse);

        }
        public void listAllCourses() 
        {
            Console.WriteLine("All Courses:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Code: {courses[i].Code}, Name: {courses[i].Name}, Description: {courses[i].Description}");
            }
            Console.WriteLine();
        }
    }
}

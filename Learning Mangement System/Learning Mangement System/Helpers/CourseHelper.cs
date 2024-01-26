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
        public void CreateCourse()
        {
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
                Description = courseDescription,
                Roster = new List<Person>(),
                Assignments = new List<Assignment>()
            };

            courses.Add(myCourse);

        }
        public void listAllCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses in List!");
                return;
            }
            Console.WriteLine("All Courses:");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Code: {courses[i].Code}, Name: {courses[i].Name}, Description: {courses[i].Description}");
            }
            Console.WriteLine();
        }

        public void updateCourseInfo()
        {
            listAllCourses();
            if (courses.Count < 0)
            {
                return;
            }
            Console.WriteLine("Enter Course number: ");
            var courseNum = Console.ReadLine();
            if (int.Parse(courseNum) > courses.Count() || int.Parse(courseNum) < 1)
            {
                Console.WriteLine("Invalid Number");
            }
            else
            {
                Console.WriteLine("Enter Course Code: ");
                var courseCode = Console.ReadLine();
                Console.WriteLine("Enter Course Name: ");
                var courseName = Console.ReadLine();
                Console.WriteLine("Enter Course Description: ");
                var courseDescription = Console.ReadLine();

                courses[int.Parse(courseNum) - 1].Code = courseCode;
                courses[int.Parse(courseNum) - 1].Name = courseName;
                courses[int.Parse(courseNum) - 1].Description = courseDescription;

                Console.WriteLine("Course Succesfully updated!");
            }

        }

        public void findCourse()
        {
            if (courses.Count < 0) {
                Console.WriteLine("No Courses Found");
                return; 
            }
            Console.WriteLine("Find course by Name or Description?");
            var method = Console.ReadLine();
            if(method == "Name")
            {
                Console.WriteLine("Enter Course Name");
                var courseName = Console.ReadLine();
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i].Name == courseName)
                    {
                        Console.WriteLine("Course Found!!");
                        Console.WriteLine();
                        Console.WriteLine($"{i + 1}. Code: {courses[i].Code}, Name: {courses[i].Name}, Description: {courses[i].Description}");
                        return;
                    }
                }
                    
            }
            else if (method == "Description")
            {
                Console.WriteLine("Enter Course Description");
                var courseDescription = Console.ReadLine();
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i].Description == courseDescription)
                    {
                        Console.WriteLine("Course Found!!");
                        Console.WriteLine();
                        Console.WriteLine($"{i + 1}. Code: {courses[i].Code}, Name: {courses[i].Name}, Description: {courses[i].Description}");
                        return;
                    }
                }

            }
            Console.WriteLine("No courses found");
        }

        public void addToRoster(Person person)
        {
            Console.WriteLine("Enter Course Name");
            var courseName = Console.ReadLine();
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name == courseName)
                {
                    courses[i].Roster.Add(person);
                    //person.enrolledCourses.Add(courses[i]);
                    Console.WriteLine("Student Added Successfully!!");

                    Console.WriteLine($"Roster for {courses[i].Name} after adding {person.Name}:");
                    foreach (var student in courses[i].Roster)
                    {
                        Console.WriteLine($"- {student.Name}");
                    }

                    return; // Assuming you want to exit the method after adding the person
                }
            }
            Console.WriteLine("No Course Found.");

        }

        public void removeFromRoster(Person person)
        {
            Console.WriteLine("Enter Course Name");
            var courseName = Console.ReadLine();
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name == courseName)
                {
                    foreach (var student in courses[i].Roster)
                    {
                        if(student == person)
                        {
                            courses[i].Roster.Remove(person);
                            Console.WriteLine("Student Removed Successfully!!");

                            Console.WriteLine($"Roster for {courses[i].Name} after Removing {person.Name}:");
                            foreach (var students in courses[i].Roster)
                            {
                                Console.WriteLine($"- {students.Name}");
                            }

                            return; // Assuming you want to exit the method after adding the person
                        }
                    }
                    Console.WriteLine("Student Not in Course");
                    return;
                }
            }
            Console.WriteLine("No Course Found.");
        }

        public void createAssignment()
        {
            Console.WriteLine("Enter Course you want to create Assignment for.");
            var courseName = Console.ReadLine();
            foreach(var course in  courses)
            {
                if(course.Name == courseName)
                {
                    Console.WriteLine("Enter Assignment Name");
                    var assignmentName = Console.ReadLine();
                    Console.WriteLine("Enter Assignment Description");
                    var assignmentDescription = Console.ReadLine();
                    Console.WriteLine("Enter Total Available points");
                    var totalPoints = Console.ReadLine();
                    var assignment = new Assignment()
                    {
                        Name = assignmentName, 
                        Description = assignmentDescription, 
                        TotalAvailablePoints = double.Parse(totalPoints),
                        DueDate = DateTime.Now
                    };
                    course.Assignments.Add(assignment);
                    Console.WriteLine("Assignment Added Successfully");
                    for (int i = 0; i < course.Assignments.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Assignment Name: {course.Assignments[i].Name}, Description: {course.Assignments[i].Description}, Total Points: {course.Assignments[i].TotalAvailablePoints}, Due Date: {course.Assignments[i].DueDate}");
                    }
                    return;
                }
            }
            Console.WriteLine("No course Found");
        }

        public void studentCourses(Person person)
        {
            foreach(var course in courses)
            {
                if (course.Roster.Contains(person))
                {
                    Console.WriteLine($"- {course.Name}");
                }
            }
        }


    }
}

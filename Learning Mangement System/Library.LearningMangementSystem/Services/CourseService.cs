using Library.LearningMangementSystem.Database;
using Library.LearningMangementSystem.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.LearningMangementSystem.Services
{
    public class CourseService
    {
        public static CourseService Current
        {
            get
            {
                return new CourseService();
            }
        }
        public IEnumerable<Course> courses
        {
            get
            {
                return FakeDatabase.Courses;
            }
        }
        public void CreateCourse( string courseName, string courseCode, string courseDescription)
        {
            var myCourse = new Course()
            {
                Code = courseCode ?? string.Empty,
                Name = courseName,
                Description = courseDescription,
                Roster = new List<Person>(),
                Assignments = new List<Assignment>()
            };

            FakeDatabase.Courses.Add(myCourse);

        }
        public void listAllCourses()
        {
            if (FakeDatabase.Courses.Count == 0)
            {
                Debug.WriteLine("No courses in List!");
                return;
            }
            Debug.WriteLine("All Courses:");
            for (int i = 0; i < FakeDatabase.Courses.Count; i++)
            {
                Debug.WriteLine($"{i + 1}. Code: {FakeDatabase.Courses[i].Code}, Name: {FakeDatabase.Courses[i].Name}, Description: {FakeDatabase.Courses[i].Description}");
            }
            Debug.WriteLine("");
        }

        public void updateCourseInfo()
        {
            listAllCourses();
            if (FakeDatabase.Courses.Count < 0)
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

                FakeDatabase.Courses[int.Parse(courseNum) - 1].Code = courseCode;
                FakeDatabase.Courses[int.Parse(courseNum) - 1].Name = courseName;
                FakeDatabase.Courses[int.Parse(courseNum) - 1].Description = courseDescription;

                Console.WriteLine("Course Succesfully updated!");
            }

        }

        public void findCourse()
        {
            if (FakeDatabase.Courses.Count < 0)
            {
                Console.WriteLine("No Courses Found");
                return;
            }
            Console.WriteLine("Find course by Name or Description?");
            var method = Console.ReadLine();
            if (method == "Name")
            {
                Console.WriteLine("Enter Course Name");
                var courseName = Console.ReadLine();
                for (int i = 0; i < FakeDatabase.Courses.Count; i++)
                {
                    if (FakeDatabase.Courses[i].Name == courseName)
                    {
                        Console.WriteLine("Course Found!!");
                        Console.WriteLine();
                        Console.WriteLine($"{i + 1}. Code: {FakeDatabase.Courses[i].Code}, Name: {FakeDatabase.Courses[i].Name}, Description: {FakeDatabase.Courses[i].Description}");
                        return;
                    }
                }

            }
            else if (method == "Description")
            {
                Console.WriteLine("Enter Course Description");
                var courseDescription = Console.ReadLine();
                for (int i = 0; i < FakeDatabase.Courses.Count; i++)
                {
                    if (FakeDatabase.Courses[i].Description == courseDescription)
                    {
                        Console.WriteLine("Course Found!!");
                        Console.WriteLine();
                        Console.WriteLine($"{i + 1}. Code: {FakeDatabase.Courses[i].Code}, Name: {FakeDatabase.Courses[i].Name}, Description: {FakeDatabase.Courses[i].Description}");
                        return;
                    }
                }

            }
            Console.WriteLine("No courses found");
        }

        public void addToRoster(Person person, Course courseName)
        {
            for (int i = 0; i < FakeDatabase.Courses.Count; i++)
            {
                if (FakeDatabase.Courses[i].Name == courseName.Name)
                {
                    FakeDatabase.Courses[i].Roster.Add(person);
                    //person.enrolledCourses.Add(courses[i]);
                    Debug.WriteLine("Student Added Successfully!!");

                    Debug.WriteLine($"Roster for {FakeDatabase.Courses[i].Name} after adding {person.Name}:");
                    foreach (var student in FakeDatabase.Courses[i].Roster)
                    {
                        Debug.WriteLine($"- {student.Name}");
                    }

                    return; // Assuming you want to exit the method after adding the person
                }
            }
            Debug.WriteLine("No Course Found.");

        }

        public void removeFromRoster(Person person)
        {
            Console.WriteLine("Enter Course Name");
            var courseName = Console.ReadLine();
            for (int i = 0; i < FakeDatabase.Courses.Count; i++)
            {
                if (FakeDatabase.Courses[i].Name == courseName)
                {
                    foreach (var student in FakeDatabase.Courses[i].Roster)
                    {
                        if (student == person)
                        {
                            FakeDatabase.Courses[i].Roster.Remove(person);
                            Console.WriteLine("Student Removed Successfully!!");

                            Console.WriteLine($"Roster for {FakeDatabase.Courses[i].Name} after Removing {person.Name}:");
                            foreach (var students in FakeDatabase.Courses[i].Roster)
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
            foreach (var course in FakeDatabase.Courses)
            {
                if (course.Name == courseName)
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
            foreach (var course in FakeDatabase.Courses)
            {
                if (course.Roster.Contains(person))
                {
                    Console.WriteLine($"- {course.Name}");
                }
            }
        }

        public void createModule(string moduleName, string moduleDescription)
        {

        }


    }
}

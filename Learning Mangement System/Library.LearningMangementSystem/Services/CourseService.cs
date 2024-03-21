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
                Debug.WriteLine("No Courses Found");
                return;
            }
            Debug.WriteLine("Find course by Name or Description?");
            var method = Console.ReadLine();
            if (method == "Name")
            {
                Debug.WriteLine("Enter Course Name");
                var courseName = Console.ReadLine();
                for (int i = 0; i < FakeDatabase.Courses.Count; i++)
                {
                    if (FakeDatabase.Courses[i].Name == courseName)
                    {
                        Debug.WriteLine("Course Found!!");
                        Debug.WriteLine($"{i + 1}. Code: {FakeDatabase.Courses[i].Code}, Name: {FakeDatabase.Courses[i].Name}, Description: {FakeDatabase.Courses[i].Description}");
                        return;
                    }
                }

            }
            else if (method == "Description")
            {
                Debug.WriteLine("Enter Course Description");
                var courseDescription = Console.ReadLine();
                for (int i = 0; i < FakeDatabase.Courses.Count; i++)
                {
                    if (FakeDatabase.Courses[i].Description == courseDescription)
                    {
                        Debug.WriteLine("Course Found!!");
                        Debug.WriteLine($"{i + 1}. Code: {FakeDatabase.Courses[i].Code}, Name: {FakeDatabase.Courses[i].Name}, Description: {FakeDatabase.Courses[i].Description}");
                        return;
                    }
                }

            }
            Debug.WriteLine("No courses found");
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

        public void removeFromRoster(Person person, Course courseName)
        {
            for (int i = 0; i < FakeDatabase.Courses.Count; i++)
            {
                if (FakeDatabase.Courses[i].Name == courseName.Name)
                {
                    foreach (var student in FakeDatabase.Courses[i].Roster)
                    {
                        if (student == person)
                        {
                            FakeDatabase.Courses[i].Roster.Remove(person);
                            Debug.WriteLine("Student Removed Successfully!!");

                            Debug.WriteLine($"Roster for {FakeDatabase.Courses[i].Name} after Removing {person.Name}:");
                            foreach (var students in FakeDatabase.Courses[i].Roster)
                            {
                                Debug.WriteLine($"- {students.Name}");
                            }

                            return; // Assuming you want to exit the method after adding the person
                        }
                    }
                    Debug.WriteLine("Student Not in Course");
                    return;
                }
            }
            Debug.WriteLine("No Course Found.");
        }

        public void createAssignment(Course courseName, string assignmentName, string assignmentDescription, string totalPoints)
        {
            foreach (var course in FakeDatabase.Courses)
            {
                if (course.Name == courseName.Name)
                {
                    var assignment = new Assignment()
                    {
                        Name = assignmentName,
                        Description = assignmentDescription,
                        TotalAvailablePoints = double.Parse(totalPoints),
                        DueDate = DateTime.Now
                    };
                    course.Assignments.Add(assignment);
                    Debug.WriteLine($"Assignment Added Successfully to course '{courseName.Name}'");
                    for (int i = 0; i < course.Assignments.Count; i++)
                    {
                        Debug.WriteLine($"{i + 1}. Assignment Name: {course.Assignments[i].Name}, Description: {course.Assignments[i].Description}, Total Points: {course.Assignments[i].TotalAvailablePoints}, Due Date: {course.Assignments[i].DueDate}");
                    }
                    return;
                }
            }
            Debug.WriteLine("No course Found");
        }

        public List<Course> studentCourses(Person person)
        {
            var temp = new List<Course>();
            foreach (var course in FakeDatabase.Courses)
            {
                if (course.Roster.Contains(person))
                {
                    temp.Add(course);
                    Debug.WriteLine($"- {course.Name}");
                }
            }
            return temp;
        }

        public void AddModule(Course courseName, string moduleName, string moduleDescription)
        {
            for (int i = 0; i < FakeDatabase.Courses.Count; i++)
            {
                if (FakeDatabase.Courses[i].Name == courseName.Name)
                {
                    var module = new Module()
                    {
                        Name = moduleName,
                        Descrition = moduleDescription,
                    };

                    // Print course and module information for debugging
                    Debug.WriteLine($"Adding module '{moduleName}' to course '{courseName.Name}' with description '{moduleDescription}'");

                    FakeDatabase.Courses[i].Modules.Add(module);
                    FakeDatabase.Courses[i].Modules[i].addNewContent();

                    // Print all modules in the course
                    Debug.WriteLine($"Modules in course '{courseName.Name}':");
                    foreach (var mod in FakeDatabase.Courses[i].Modules)
                    {
                        Debug.WriteLine($"Module: {mod.Name}, Description: {mod.Descrition}");
                    }
                    return;
                }
            }

            // Print error message if no course is found
            Debug.WriteLine("No Course Found.");
        }

    }
}

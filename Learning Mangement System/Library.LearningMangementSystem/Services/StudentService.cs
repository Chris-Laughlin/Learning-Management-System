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
    public class StudentService
    {

        public static StudentService Current {
            get
            {
                return new StudentService();
            }
        }
        public IEnumerable<Person?> students
        {
            get
            {
                return FakeDatabase.Students.Where(p => p is Person).Select(p => p as Person);
            }
        }
        public void createStudent(string studentName, string studentClassification)
        {
            var student = new Person()
            {
                Name = studentName,
                Classification = studentClassification
                //enrolledCourses = new List<Course>()
            };
            FakeDatabase.Students.Add(student);
        }

        public void listAllStudents()
        {
            if (FakeDatabase.Students.Count == 0)
            {
                Debug.WriteLine("No students in List!");
                return;
            }
            Debug.WriteLine("All Students:");
            for (int i = 0; i < FakeDatabase.Students.Count; i++)
            {
                Debug.WriteLine($"{i + 1}. Name: {FakeDatabase.Students[i].Name}, Classification: {FakeDatabase.Students[i].Classification}");
            }
            Debug.WriteLine("");
        }

        public void updateStudentInfo(Person person, string studentName, string studentClassification)
        {
            if (FakeDatabase.Students.Count == 0)
            {
                return;
            }

            for (int i = 0; i < FakeDatabase.Students.Count; i++)
            {
                if (FakeDatabase.Students[i].Name == person.Name)
                {
                    FakeDatabase.Students[i].Name = studentName;
                    FakeDatabase.Students[i].Classification = studentClassification;
                    return; // Exit the loop after updating the student
                }
            }

            Debug.WriteLine("No student found with the given name.");
        }


        public void searchStudent()
        {
            Console.WriteLine("Enter Students Name: ");
            var studentName = Console.ReadLine();

            for (int i = 0; i < FakeDatabase.Students.Count; i++)
            {
                if (FakeDatabase.Students[i].Name == studentName)
                {
                    Console.WriteLine("Student Found!");
                    Console.WriteLine($"{i + 1}. Name: {FakeDatabase.Students[i].Name}, Classification: {FakeDatabase.Students[i].Classification}");
                    return;
                }
            }
            Console.WriteLine("Student Not found");
        }

        public void submitAssignment(Person studentName)
        {
            Debug.WriteLine("Assignment Submitted Successfully!!!");
        }

        public Person getStudent(string name)
        {
            for (int i = 0; i < FakeDatabase.Students.Count; i++)
            {
                if (FakeDatabase.Students[i].Name == name)
                {
                    return FakeDatabase.Students[i];
                }
            }
            return null;
        }
    }
}

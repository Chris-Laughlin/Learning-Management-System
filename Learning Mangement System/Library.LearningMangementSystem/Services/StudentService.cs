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
                return FakeDatabase.Students;
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

        public void updateStudentInfo(string studentName, string studentClassification)
        {
            listAllStudents();
            if (FakeDatabase.Students.Count < 0)
            {
                return;
            }
            Console.WriteLine("Enter student Number: ");
            var studentNum = int.Parse(Console.ReadLine());
            if (studentNum < 0 || studentNum > FakeDatabase.Students.Count)
            {
                Console.WriteLine("Invalid student.");
            }
            else
            {
                FakeDatabase.Students[studentNum - 1].Name = studentName;
                FakeDatabase.Students[studentNum - 1].Classification = studentClassification;
            }
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

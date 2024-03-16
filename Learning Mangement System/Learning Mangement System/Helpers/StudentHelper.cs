using Library.LearningMangementSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Mangement_System.Helpers
{
    internal class StudentHelper
    {
        public void createStudent()
        {
            Console.WriteLine("Enter Student name: ");
            var studentName = Console.ReadLine();
            Console.WriteLine("Enter Student Classification: ");
            var studentClassification = Console.ReadLine();


            var student = new Person()
            {
                Name = studentName,
                Classification = studentClassification
                //enrolledCourses = new List<Course>()
            };

            students.Add(student);
            
        }

        public void listAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students in List!");
                return;
            }
            Console.WriteLine("All Students:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {students[i].Name}, Classification: {students[i].Classification}");
            }
            Console.WriteLine();
        }

        public void updateStudentInfo()
        {
            listAllStudents();
            if (students.Count < 0)
            {
                return;
            }
            Console.WriteLine("Enter student Number: ");
            var studentNum = int.Parse(Console.ReadLine());
            if(studentNum < 0 || studentNum > students.Count)
            {
                Console.WriteLine("Invalid student.");
            }
            else
            {
                Console.WriteLine("Enter Student name: ");
                var studentName = Console.ReadLine();
                Console.WriteLine("Enter Student Classification: ");
                var studentClassification = Console.ReadLine();
                students[studentNum-1].Name = studentName;
                students[studentNum-1].Classification = studentClassification;

                Console.WriteLine("Student profile updated Successfully!!");
            }
        }
        public void searchStudent() 
        { 
            Console.WriteLine("Enter Students Name: ");
            var studentName = Console.ReadLine();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == studentName)
                {
                    Console.WriteLine("Student Found!");
                    Console.WriteLine($"{i + 1}. Name: {students[i].Name}, Classification: {students[i].Classification}");
                    return;
                }
            }
            Console.WriteLine("Student Not found");
        }

        public Person getStudent(string name)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == name)
                {
                    return students[i];
                }
            }
            return null;
        }
    }
}

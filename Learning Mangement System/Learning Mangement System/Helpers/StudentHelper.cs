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
        private List<Person> students = new List<Person>();
        public void createStudent()
        {
            Console.WriteLine("Enter Student name: ");
            var studentName = Console.ReadLine();
            Console.WriteLine("Enter Student Classification: ");
            var studentClassification = Console.ReadLine();
            Console.WriteLine("Enter Course Description: ");
            

            var student = new Person()
            {
                Name = studentName,
                Classification = studentClassification,
            };

            students.Add(student);

            students.ForEach(Console.WriteLine);
            
        }

        public void listAllStudents()
        {
            Console.WriteLine("All Students:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {students[i].Name}, Classification: {students[i].Classification}");
            }
            Console.WriteLine();
        }
    }
}

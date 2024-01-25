using Learning_Mangement_System.Helpers;
using Library.LearningMangementSystem.models;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();

            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. List all Courses");
                Console.WriteLine("4. List all Students");


                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1: 
                            courseHelper.CreateCourse();
                            break;
                        case 2:
                            studentHelper.createStudent();
                            break;
                        case 3:
                            courseHelper.listAllCourses();
                            break;
                        case 4:
                            studentHelper.listAllStudents();
                            break;
                        case 12:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
     
        }
    }
}
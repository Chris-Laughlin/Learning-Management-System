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
                Console.WriteLine("5. Update Course Info");
                Console.WriteLine("6. Update Student Info");
                Console.WriteLine("7. Search Student by Name");
                Console.WriteLine("8. Search Course by Name or Description");
                Console.WriteLine("9. Add Student to Course");
                Console.WriteLine("10. Remove Student Student from Course");
                Console.WriteLine("11. Add Assignment to Course");
                Console.WriteLine("12. List Student Courses");
                Console.WriteLine("14. Exit");


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
                        case 5:
                            courseHelper.updateCourseInfo();
                            break;
                        case 6:
                            studentHelper.updateStudentInfo();
                            break;
                        case 7:
                            studentHelper.searchStudent();
                            break;
                        case 8:
                            courseHelper.findCourse();
                            break;
                        case 9:
                            Console.WriteLine("Enter Students Name: ");
                            var the_name = Console.ReadLine();
                            var get_name = studentHelper.getStudent(the_name);
                            if(get_name != null)
                                courseHelper.addToRoster(get_name);
                            else
                            {
                                Console.WriteLine("No student Found");
                            }
                            break;
                        case 10:
                            Console.WriteLine("Enter Students Name: ");
                            var The_name = Console.ReadLine();
                            var Get_name = studentHelper.getStudent(The_name);
                            if (Get_name != null)
                                courseHelper.removeFromRoster(Get_name);
                            else
                            {
                                Console.WriteLine("No student Found");
                            }
                            break;
                        case 11:
                            courseHelper.createAssignment();
                            break;
                        case 12:
                            Console.WriteLine("Enter Students Name: ");
                            var studentName = Console.ReadLine();
                            var getStudent = studentHelper.getStudent(studentName);
                            if (getStudent != null)
                                courseHelper.studentCourses(getStudent);
                            else
                            {
                                Console.WriteLine("No student Found");
                            }
                            break;
                        case 14:
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
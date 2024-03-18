using Library.LearningMangementSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningMangementSystem.Database
{
    public static class FakeDatabase
    {
        private static List<Person> students=new List<Person>();
        private static List<Course> courses = new List<Course>();
        public static List<Person> Students
        {
            get
            {
                return students;
            }
        }

        public static List<Course> Courses
        {
            get
            {
                return courses;
            }
        }
    }
}

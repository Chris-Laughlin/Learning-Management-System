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
        public static List<Person> students {
            get
            {
                return new List<Person>();
            }
        }

        public static List<Course> courses
        {
            get
            {
                return new List<Course>();
            }
        }
    }
}

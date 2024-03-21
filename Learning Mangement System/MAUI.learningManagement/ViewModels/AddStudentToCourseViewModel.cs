using Library.LearningMangementSystem.models;
using Library.LearningMangementSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.learningManagement.ViewModels
{
    public class AddStudentToCourseViewModel
    {
        public ObservableCollection<Person> Student
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.students);
            }
        }

        public Person SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }

        public ObservableCollection<Course> Course
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.courses);
            }
        }

        public event PropertyChangedEventHandler ?PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClick(Shell s)
        {
            s.GoToAsync("//AddStudentToCourse");
        }

        public void AddStudentClick()
        {
            if (SelectedPerson == null) { return; }
            if (SelectedCourse == null) { return; }

            CourseService.Current.addToRoster(SelectedPerson, SelectedCourse);
            RefreshView();
        }

        public void RefreshView()
        {
            Debug.WriteLine("Refreshing Add Student");
            NotifyPropertyChanged(nameof(Student));
            NotifyPropertyChanged(nameof(Course));
        }

    }
}

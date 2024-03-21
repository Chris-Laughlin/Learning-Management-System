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
    internal class AddAssignmentToCourseViewModel
    {
        public string assignmentDescription { get; set; }
        public string assignmentName { get; set; }
        public string totalPoints { get; set; }

        public Course SelectedCourse { get; set; }

        public ObservableCollection<Course> Course
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.courses);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClick(Shell s)
        {
            s.GoToAsync("//AddStudentToCourse");
        }

        public void AddAssignmentClicked()
        {
            if (SelectedCourse == null) { return; }

            CourseService.Current.createAssignment(SelectedCourse, assignmentName, assignmentDescription, totalPoints);
            RefreshView();
        }

        public void RefreshView()
        {
            Debug.WriteLine("Refreshing Module");
            NotifyPropertyChanged(nameof(Course));
        }
    }
}

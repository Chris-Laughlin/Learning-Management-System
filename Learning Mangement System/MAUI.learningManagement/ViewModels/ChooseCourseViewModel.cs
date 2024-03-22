using Library.LearningMangementSystem.Database;
using Library.LearningMangementSystem.models;
using Library.LearningMangementSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.learningManagement.ViewModels
{
    internal class ChooseCourseViewModel
    {
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

        public void CourseClicked()
        {
            if (SelectedCourse == null) { return; }

            FakeDatabase.theSelectedCourse = SelectedCourse;

            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Course));
        }
    }
}

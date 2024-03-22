using Library.LearningMangementSystem.Database;
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
    internal class CourseInformationViewModel
    {

        public Course SelectedCourse = FakeDatabase.theSelectedCourse;
        public Assignment SelectedAssignment;

        public ObservableCollection<Course> Course
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.courses);
            }
        }

        public ObservableCollection<Module> Modules
        {
            get
            {
                return new ObservableCollection<Module>(CourseService.Current.getModules(SelectedCourse));
            }
        }
        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(CourseService.Current.getAssignments(SelectedCourse));
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
        public void submitAssignmentClicked()
        {
            StudentService.Current.submitAssignment(FakeDatabase.theSelectedPerson);
            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Course));
        }
    }
}

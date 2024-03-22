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
    internal class SearchForCourseViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Course> Course
        {
            get
            {
                var filteredList = CourseService.Current.courses.Where(s =>
                    s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ||
                    s.Description.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));

                return new ObservableCollection<Course>(filteredList);
            }
        }
        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Course));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClick(Shell s)
        {
            s.GoToAsync("//AddStudentToCourse");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Course));
        }
    }
}


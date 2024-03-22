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
    internal class SearchForStudentViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Person> Student
        {
            get
            {
                var filteredList = StudentService.Current.students.Where(s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));
                return new ObservableCollection<Person>(filteredList);
            }
        }
        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(Student));
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
            NotifyPropertyChanged(nameof(Student));
        }
    }
}

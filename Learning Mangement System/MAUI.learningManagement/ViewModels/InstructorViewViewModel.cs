using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Library.LearningMangementSystem.models;
using Library.LearningMangementSystem.Services;
using System.Threading.Tasks;

namespace MAUI.learningManagement.ViewModels
{
    public class InstructorViewViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Person> Student
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.students);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClick(Shell s)
        {
            s.GoToAsync("//AddStudent");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Student));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Library.LearningMangementSystem.models;
using Library.LearningMangementSystem.Services;
using System.Diagnostics;
using System.Threading.Tasks;


namespace MAUI.learningManagement.ViewModels
{
    public class InstructorViewViewModel: INotifyPropertyChanged
    {
        int count = 0;
        public ObservableCollection<Person> Student
        {
            get
            {
                Debug.WriteLine("Getting STUDENT PLEASEEEEE " + count);
                count++;
                return new ObservableCollection<Person>(StudentService.Current.students);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClick(Shell s)
        {
            s.GoToAsync("//AddStudent");
        }

        public void RefreshView()
        {
            Debug.WriteLine("Refreshing");
            NotifyPropertyChanged(nameof(Student));
        }
    }
}

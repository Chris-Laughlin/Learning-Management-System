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
    internal class ChooseStudentViewModel
    {
        public Person SelectedPerson { get; set; }

        public ObservableCollection<Person> Student
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.students);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StudentClicked()
        {
            if (SelectedPerson == null) { return; }

            FakeDatabase.theSelectedPerson = SelectedPerson;

            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Person));
        }
    }
}

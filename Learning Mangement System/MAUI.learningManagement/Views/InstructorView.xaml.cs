using MAUI.learningManagement.ViewModels;
using Library.LearningMangementSystem.models;
using System.Diagnostics;

namespace MAUI.learningManagement.Views
{
    public partial class InstructorView : ContentPage
    {
        public InstructorView()
        {
            InitializeComponent();
            BindingContext = new InstructorViewViewModel();
        }

        private void BackClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        private void AddCourseClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AddCourse");
        }

        private void AddStudentClicked(object sender, EventArgs e)
        {
            (BindingContext as InstructorViewViewModel)?.AddClick(Shell.Current);
        }

        private void AddStudentToCourseClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AddStudentToCourse");
        }
        private void RemoveStudentClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//RemoveStudentFromRoster");
        }
        private void AddModuleClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AddModuleToCourse");
        }

        private void AddAssignmentClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AddAssignmentToCourse");
        }

        private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
        {
            Debug.WriteLine("ContentPage_NavigateTo");
            (BindingContext as InstructorViewViewModel)?.RefreshView();
        }
    }
}

using MAUI.learningManagement.ViewModels;
using Library.LearningMangementSystem.models;

namespace MAUI.learningManagement.Views;

public partial class InstructorView : ContentPage
{

    public InstructorView()
    {
        InitializeComponent();
        BindingContext = new InstructorViewViewModel();
        var studentHelper = new StudentHelper();
        var courseHelper = new CourseHelper();
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
        (BindingContext as InstructorViewViewModel).AddClick(Shell.Current);
    }
    private void AddStudentToCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddStudentToCourse");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RefreshView();
    }
}
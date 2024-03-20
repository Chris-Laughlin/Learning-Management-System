using Library.LearningMangementSystem.Services;
using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class AddCourse : ContentPage
{
    public AddCourse()
    {
        InitializeComponent();
        BindingContext = new AddCourseViewModel();
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddCourseViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        var context = BindingContext as AddCourseViewModel;
        string courseName = "";
        string courseId = "";
        string courseDescription = "";

        courseName = context.courseName;
        courseId = context.courseId;
        courseDescription = context.courseDescription;

        CourseService.Current.CreateCourse(courseName, courseId, courseDescription);
        CourseService.Current.listAllCourses();
        Shell.Current.GoToAsync("//InstructorView");
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }
}
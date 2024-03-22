using Library.LearningMangementSystem.Database;
using Library.LearningMangementSystem.Services;
using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class UpdateCourse : ContentPage
{
	public UpdateCourse()
	{
		InitializeComponent();
        BindingContext = new UpdateCourseViewModel();
    }
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new UpdateCourseViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        var context = BindingContext as UpdateCourseViewModel;
        string courseName = "";
        string courseId = "";
        string courseDescription = "";

        courseName = context.courseName;
        courseId = context.courseId;
        courseDescription = context.courseDescription;

        CourseService.Current.updateCourseInfo(FakeDatabase.theSelectedCourse, courseName, courseId, courseDescription);
        CourseService.Current.listAllCourses();
        Shell.Current.GoToAsync("//InstructorView");
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }
}
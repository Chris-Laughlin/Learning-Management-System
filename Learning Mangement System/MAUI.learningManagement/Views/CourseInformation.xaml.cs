using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class CourseInformation : ContentPage
{
	public CourseInformation()
	{
		InitializeComponent();
        BindingContext = new CourseInformationViewModel();
    }

    private void SubmitAssignmentClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseInformationViewModel)?.submitAssignmentClicked();
        Shell.Current.GoToAsync("//StudentCourses");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentCourses");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        Debug.WriteLine("ContentPage_NavigateTo");
        (BindingContext as AddAssignmentToCourseViewModel)?.RefreshView();
    }
}
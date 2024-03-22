using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class StudentCourse : ContentPage
{
	public StudentCourse()
	{
		InitializeComponent();
        BindingContext = new StudentCoursesViewModel();
    }
    private void ViewSelectedCourse(object sender, EventArgs e)
    {
        (BindingContext as StudentCoursesViewModel)?.CourseClicked();
        Shell.Current.GoToAsync("//CourseInformation");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        Debug.WriteLine("ContentPage_NavigateTo");
        (BindingContext as StudentCoursesViewModel)?.RefreshView();
    }

}
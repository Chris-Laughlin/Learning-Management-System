using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class ChooseCourse : ContentPage
{
	public ChooseCourse()
	{
		InitializeComponent();
        BindingContext = new ChooseCourseViewModel();
    }
    private void ModifyCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as ChooseCourseViewModel)?.CourseClicked();
        Shell.Current.GoToAsync("//UpdateCourse");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        (BindingContext as ChooseCourseViewModel)?.RefreshView();
    }
}
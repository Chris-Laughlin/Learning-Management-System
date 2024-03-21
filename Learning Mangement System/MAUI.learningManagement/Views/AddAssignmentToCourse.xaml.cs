using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class AddAssignmentToCourse : ContentPage
{
	public AddAssignmentToCourse()
	{
		InitializeComponent();
        BindingContext = new AddAssignmentToCourseViewModel();
    }
    private void AddModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as AddAssignmentToCourseViewModel)?.AddAssignmentClicked();
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        Debug.WriteLine("ContentPage_NavigateTo");
        (BindingContext as AddAssignmentToCourseViewModel)?.RefreshView();
    }
}
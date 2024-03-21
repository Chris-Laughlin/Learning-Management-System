using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class AddModuleToCourse : ContentPage
{
	public AddModuleToCourse()
	{
		InitializeComponent();
        BindingContext = new AddModuleToCourseViewModel();
    }
    private void AddModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as AddModuleToCourseViewModel)?.AddNewModuleClicked();
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        Debug.WriteLine("ContentPage_NavigateTo");
        (BindingContext as AddModuleToCourseViewModel)?.RefreshView();
    }
}
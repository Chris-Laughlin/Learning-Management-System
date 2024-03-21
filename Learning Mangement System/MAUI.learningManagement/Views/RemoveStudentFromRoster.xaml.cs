using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class RemoveStudentFromRoster : ContentPage
{
	public RemoveStudentFromRoster()
	{
		InitializeComponent();
        BindingContext = new RemoveStudentFromRosterViewModel();
    }
    private void RemoveStudentClicked(object sender, EventArgs e)
    {
        (BindingContext as RemoveStudentFromRosterViewModel)?.RemoveStudentClick();
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        Debug.WriteLine("ContentPage_NavigateTo");
        (BindingContext as RemoveStudentFromRosterViewModel)?.RefreshView();
    }
}
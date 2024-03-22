using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class AddStudentToCourse : ContentPage
{
    public AddStudentToCourse()
    {
        InitializeComponent();
        BindingContext = new AddStudentToCourseViewModel();
    }
    private void AddStudentToCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as AddStudentToCourseViewModel)?.AddStudentClick();
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        (BindingContext as AddStudentToCourseViewModel).RefreshView();
    }
}
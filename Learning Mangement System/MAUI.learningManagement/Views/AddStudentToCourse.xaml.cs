using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class AddStudentToCourse : ContentPage
{
    public AddStudentToCourse()
    {
        InitializeComponent();
        BindingContext = new AddStudentToCourseViewModel();
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }
}
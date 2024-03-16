using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class AddCourse : ContentPage
{
	public AddCourse()
	{
		InitializeComponent();
        BindingContext = new AddCourseViewModel();
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }
}
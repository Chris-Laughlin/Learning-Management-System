using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class AddStudent : ContentPage
{
	public AddStudent()
	{
		InitializeComponent();
        BindingContext = new AddStudentViewModel();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }
}
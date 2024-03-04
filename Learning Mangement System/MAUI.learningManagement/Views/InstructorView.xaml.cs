using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}
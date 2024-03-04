using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
        InitializeComponent();
		BindingContext = new StudentViewViewModel();
	}

	private void BackClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}
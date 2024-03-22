using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class ChooseStudent : ContentPage
{
	public ChooseStudent()
	{
		InitializeComponent();
        BindingContext = new ChooseStudentViewModel();
    }
    private void ModifyStudentClicked(object sender, EventArgs e)
    {
        (BindingContext as ChooseStudentViewModel)?.StudentClicked();
        Shell.Current.GoToAsync("//UpdateStudent");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        (BindingContext as ChooseStudentViewModel)?.RefreshView();
    }
}
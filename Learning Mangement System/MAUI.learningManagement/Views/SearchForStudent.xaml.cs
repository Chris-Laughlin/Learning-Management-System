using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class SearchForStudent : ContentPage
{
	public SearchForStudent()
	{
		InitializeComponent();
        BindingContext = new SearchForStudentViewModel();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as SearchForStudentViewModel).RefreshView();
    }
}
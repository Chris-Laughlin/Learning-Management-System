using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class SearchForCourse : ContentPage
{
	public SearchForCourse()
	{
		InitializeComponent();
        BindingContext = new SearchForCourseViewModel();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as SearchForCourseViewModel).RefreshView();
    }
}
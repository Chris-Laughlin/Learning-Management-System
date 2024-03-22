using Library.LearningMangementSystem.Database;
using Library.LearningMangementSystem.Services;
using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement.Views;

public partial class UpdateStudent : ContentPage
{
	public UpdateStudent()
	{
		InitializeComponent();
        BindingContext = new UpdateStudentViewModel();
    }
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new UpdateStudentViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        var context = BindingContext as UpdateStudentViewModel;
        string classification = "";
        switch (context.ClassificationString)
        {
            case "Senior":
                classification = "Senior";
                break;
            case "Junior":
                classification = "Junior";
                break;
            case "Sophmore":
                classification = "Sophmore";
                break;
            case "Freshman":
                classification = "Freshman";
                break;
        }

        StudentService.Current.updateStudentInfo(FakeDatabase.theSelectedPerson, context.Name, classification);
        Shell.Current.GoToAsync("//InstructorView");
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }
}
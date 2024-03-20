using MAUI.learningManagement.ViewModels;
using Library.LearningMangementSystem.Database;
using Library.LearningMangementSystem.Services;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class AddStudent : ContentPage
{

    public AddStudent()
    {
        InitializeComponent();
        BindingContext = new AddStudentViewModel();
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddStudentViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        var context = BindingContext as AddStudentViewModel;
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

        StudentService.Current.createStudent(context.Name, classification);
        Shell.Current.GoToAsync("//InstructorView");
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }
}
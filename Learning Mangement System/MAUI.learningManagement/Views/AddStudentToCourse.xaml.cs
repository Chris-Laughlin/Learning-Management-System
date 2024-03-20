using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;

public partial class AddStudentToCourse : ContentPage
{
    public AddStudentToCourse()
    {
        InitializeComponent();
        BindingContext = new AddStudentToCourseViewModel();
    }
    private void AddStudentToCourseClicked(object sender, EventArgs e)
    {
        var context = BindingContext as AddStudentToCourseViewModel;
        (BindingContext as AddStudentToCourseViewModel)?.AddStudentClick();
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        Debug.WriteLine("ContentPage_NavigateTo");
        (BindingContext as AddStudentToCourseViewModel)?.RefreshView();
    }
}

/*using MAUI.learningManagement.ViewModels;
using System.Diagnostics;

namespace MAUI.learningManagement.Views;
public partial class RemoveStudentFromRosterView : ContentPage
{
    public RemoveStudentFromRosterView()
    {
        InitializeComponent();
        BindingContext = new AddStudentToCourseViewModel();
    }

    private void AddStudentToCourseClicked(object sender, EventArgs e)
    {
        var context = BindingContext as RemoveStudentFromRosterViewModel;
        (BindingContext as RemoveStudentFromRosterViewModel)?.AddStudentClick();
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorView");
    }

    private void ContentPage_NavigateTo(object sender, NavigationEventArgs e)
    {
        Debug.WriteLine("ContentPage_NavigateTo");
        (BindingContext as RemoveStudentFromRosterViewModel)?.RefreshView();
    }
}*/


/*<? xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns = "http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MAUI.learningManagement.Views.RemoveStudentFromRosterView"
             Title="RemoveStudentFromRosterView"
             NavigatedTo="ContentPage_NavigateTo">
    <VerticalStackLayout Spacing = "10" >
        < Label
        Text="Remove Student From Roster"
        FontSize="20"
        VerticalOptions="Center" 
        HorizontalOptions="Center" />
        <Label
        Text = "Students"
        FontSize="18"
        Margin="0,10,0,0"/>

        <ListView ItemsSource = "{Binding Student}"
              SelectedItem="{Binding SelectedPerson, Mode=TwoWay}">
        </ListView>

        <Label
        Text = "Course"
        FontSize="18"
        Margin="0,10,0,0"/>

        <ListView ItemsSource = "{Binding Course}"
              SelectedItem="{Binding SelectedCourse, Mode=TwoWay}">
        </ListView>

        <Button
        Text = "Add Student to Course"
        Clicked="RemoveStudentClick"/>

        <Button
            Text = "Back"
            Clicked="AddStudentToCourseClicked"/>
    </VerticalStackLayout>
</ContentPage>*/
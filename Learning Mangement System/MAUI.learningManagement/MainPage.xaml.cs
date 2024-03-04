using MAUI.learningManagement.ViewModels;

namespace MAUI.learningManagement
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void StudentClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//StudentView");
        }

        private void InstructorClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InstructorView");
        }
    }

}

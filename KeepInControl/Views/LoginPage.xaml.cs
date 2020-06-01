using KeepInControl.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeepInControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel LoginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = LoginViewModel = LoginViewModel ?? new LoginViewModel();
        }
    }
}
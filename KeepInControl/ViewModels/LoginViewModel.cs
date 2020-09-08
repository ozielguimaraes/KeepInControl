using KeepInControl.Services;
using KeepInControl.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeepInControl.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand SignInComand => new Command(async () => await SignIn());

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async Task SignIn()
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Campo Login é obrigatório.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Campo Senha é obrigatório.", "OK");
                return;
            }

            if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
                await Application.Current.MainPage.DisplayAlert("Ops!", "Você não está conectado na internet.", "OK");

            //TODO Create service communication
            var userService = new UserService();
            await userService.AutenticateAsync(UserName, Password);

            await Application.Current.MainPage.Navigation.PushModalAsync(new TransactionsView());
            //await Shell.Current.GoToAsync("transactions");
        }
    }
}
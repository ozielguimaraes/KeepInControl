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
                await Application.Current.MainPage.DisplayAlert("Aviso", "Campo Login é obrigatório.", "OK");

            if (string.IsNullOrWhiteSpace(Password))
                await Application.Current.MainPage.DisplayAlert("Aviso", "Campo Senha é obrigatório.", "OK");

            if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
                await Application.Current.MainPage.DisplayAlert("Ops!", "Você não está conectado na internet.", "OK");

            //TODO Create service communication
            App.UserIsLogged = true;
        }
    }
}
using KeepInControl.Views;
using Xamarin.Forms;

namespace KeepInControl
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("transactions", typeof(TransactionsView));
        }
    }
}
using KeepInControl.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeepInControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionsView : ContentPage
    {
        private readonly TransactionsViewModel ViewModel;

        public TransactionsView()
        {
            InitializeComponent();
            BindingContext = ViewModel = ViewModel ?? new TransactionsViewModel();
        }
    }
}
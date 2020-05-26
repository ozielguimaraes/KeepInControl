using KeepInControl.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeepInControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListExpenseView : ContentPage
    {
        private readonly ListExpenseViewModel ViewModel;

        public ListExpenseView()
        {
            InitializeComponent();
            BindingContext = ViewModel ?? new ListExpenseViewModel();
        }
    }
}
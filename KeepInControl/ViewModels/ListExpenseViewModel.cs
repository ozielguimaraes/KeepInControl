using KeepInControl.Resources.Themes;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KeepInControl.ViewModels
{
    public class ListExpenseViewModel : BaseViewModel
    {
        public ListExpenseViewModel()
        {
            Title = "Expenses";
        }
        private static bool useDarkMode = false;
        public bool UseDarkMode
        {
            get => useDarkMode;
            set
            {
                useDarkMode = value;
                OnPropertyChanged(nameof(UseDarkMode));

                if (UseDarkMode && App.Theme != AppTheme.Dark)
                {
                    Application.Current.Resources = new DarkTheme();
                    App.Theme = AppTheme.Dark;
                }
                else if (!UseDarkMode && App.Theme == AppTheme.Dark)
                {
                    Application.Current.Resources = new LightTheme();
                    App.Theme = AppTheme.Light;
                }
            }
        }
    }
}
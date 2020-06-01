using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using KeepInControl.Models;
using KeepInControl.Resources.Themes;
using KeepInControl.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KeepInControl.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public ICommand LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
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
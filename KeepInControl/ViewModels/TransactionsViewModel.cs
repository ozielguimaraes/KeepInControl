using KeepInControl.IoC;
using KeepInControl.Models;
using KeepInControl.Services;
using KeepInControl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KeepInControl.ViewModels
{
    public class TransactionsViewModel : BaseViewModel
    {
        public Command LoadCommand { get; }

        public TransactionsViewModel()
        {
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
            Items = new ObservableCollection<Transaction>();
        }

        public ObservableCollection<Transaction> Items { get; set; }

        private async Task ExecuteLoadCommand()
        {
            Items.Clear();
            var service = AppContainer.Resolve<ITransactionService>();
            var items = await service.GetRecentAsync();
            items?.ForEach(item => Items.Add(item));
        }
    }
}
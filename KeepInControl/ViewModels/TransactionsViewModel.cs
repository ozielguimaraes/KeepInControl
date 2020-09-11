using KeepInControl.Models;
using KeepInControl.Services;
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
        }

        public List<Transaction> Items { get; set; }

        private async Task ExecuteLoadCommand()
        {
            var service = new TransactionService();
            Items = await service.GetRecentAsync();
        }
    }
}
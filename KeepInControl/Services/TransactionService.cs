using KeepInControl.Models;
using KeepInControl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeepInControl.Services
{
    sealed class TransactionService : ITransactionService
    {
        public async Task<List<Transaction>> GetRecentAsync()
        {
			return await BaseService.Current.GetAsync<List<Transaction>>("https://run.mocky.io/v3/aa0b2e82-77f8-44dd-9cb0-e8caab4ed1a3");
        }
    }
}
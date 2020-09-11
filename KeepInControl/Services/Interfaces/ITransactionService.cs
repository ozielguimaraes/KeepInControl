using KeepInControl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeepInControl.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetRecentAsync();
    }
}
using KeepInControl.Models;
using KeepInControl.Models.Enumerations;
using KeepInControl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeepInControl.Services.Mocks
{
    sealed class TransactionServiceMock : ITransactionService
    {
        public async Task<List<Transaction>> GetRecentAsync()
        {
            await Task.Delay(100);

            return new List<Transaction>{
            new Transaction{
            Id = 1,
                Description="'Golub' Taxi Transportation",
                Date= DateTime.Now,
                Value=394,
                Type= TransactionType.Income,
                Category = TransactionCategory.Transportation
            },
            new Transaction{
            Id = 1,
                Description="'Golub' Taxi Transportation",
                Date= DateTime.Now,
                Value=394,
                Type= TransactionType.Income,
                Category = TransactionCategory.Transportation
            },
            new Transaction{
            Id = 2,
                Description="'Francois' Restaurant Dinner",
                Date= DateTime.Now.AddDays(-12),
                Value=854.42m,
                Type= TransactionType.Outcome,
                Category = TransactionCategory.Restaurant
            },
            new Transaction{
            Id = 3,
                Description="'Golub' Taxi Transportation",
                Date= DateTime.Now,
                Value=256,
                Type= TransactionType.Income,
                Category = TransactionCategory.Transportation
            },
            new Transaction{
            Id = 4,
                Description="'AirMax' Travel to Canada",
                Date= DateTime.Now.AddDays(120),
                Value=12000.98m,
                Type= TransactionType.Outcome,
                Category = TransactionCategory.Transportation
            },
            new Transaction{
            Id = 5,
                Description="Freelancer job #1",
                Date= DateTime.Now.AddDays(120),
                Value=1500,
                Type= TransactionType.Income,
                Category = TransactionCategory.Salary
            }
        };
        }
    }
}
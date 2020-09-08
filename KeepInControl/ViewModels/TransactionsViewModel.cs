using KeepInControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KeepInControl.ViewModels
{
    public class TransactionsViewModel : BaseViewModel
    {
        public TransactionsViewModel()
        {
            Items = new List<Transaction>
            {
                new Transaction
                {
                 Id = 1,
                 Establishment = "Ponto Frio",
                 Value = 122,
                 Date = DateTime.Now
                },
                new Transaction
                {
                 Id = 2,
                 Establishment = "Azure",
                 Value = 12,
                 Date = DateTime.Now.AddDays(-1)
                },
                new Transaction
                {
                 Id = 3,
                 Establishment = "Netflix",
                 Value = 37.9m,
                 Date = DateTime.Now.AddDays(-2)
                },
                new Transaction
                {
                 Id = 4,
                 Establishment = "Parcela da casa",
                 Value = 1200,
                 Date = DateTime.Now.AddDays(-5)
                }
            };
        }

        public List<Transaction> Items { get; set; }
    }
}
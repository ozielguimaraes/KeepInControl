using KeepInControl.Models.Enumerations;
using System;

namespace KeepInControl.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTimeOffset Date { get; set; }
        public TransactionCategory Category { get; set; }
        public TransactionType Type { get; set; }
    }
}
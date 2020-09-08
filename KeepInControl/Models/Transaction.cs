using System;

namespace KeepInControl.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Establishment { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
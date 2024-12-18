using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionTracker.Model.Enums;

namespace TransactionTracker.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Title { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public CurrencyType Currency { get; set; }
        public string Notes { get; set; }
        public string Tags { get; set; }  // A comma-separated string of tags
        public bool IsDebtCleared { get; set; }
        public DateTime? DueDate { get; set; }  // Only used for Debt transactions
    }
}

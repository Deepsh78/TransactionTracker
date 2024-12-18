using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TransactionTracker.Model;
using TransactionTracker.Model.Enums;
using TransactionTracker.Services.Interface;

namespace TransactionTracker.Services
{
    public class TransactionService: ITransactionService

    {
        private const string FilePath = "transactions.json";  // JSON file for storing transactions

        public async Task<List<Transaction>> LoadTransactions()
        {
            if (File.Exists(FilePath))
            {
                var json = await File.ReadAllTextAsync(FilePath);
                return JsonConvert.DeserializeObject<List<Transaction>>(json) ?? new List<Transaction>();
            }
            return new List<Transaction>();
        }

        // Asynchronously add a transaction
        public async Task AddTransaction(Transaction transaction)
        {
            var transactions = await LoadTransactions();
            transactions.Add(transaction);
            await SaveTransactions(transactions);
        }

        // Save transactions back to the JSON file
        private async Task SaveTransactions(List<Transaction> transactions)
        {
            var json = JsonConvert.SerializeObject(transactions, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(FilePath, json);
        }

        // Make the method async and return a Task<List<Transaction>> for asynchronous operations
        public async Task<decimal> GetTotalAmountByType(TransactionType type, CurrencyType currency)
        {
            var transactions = await LoadTransactions(); // Await to get the actual transactions list
            var filteredTransactions = transactions.Where(t => t.Type == type && t.Currency == currency).ToList();
            return filteredTransactions.Sum(t => t.Amount);
        }

        // Make the method async and return a Task<List<Transaction>> for asynchronous operations
        public async Task<List<Transaction>> GetPendingDebts(CurrencyType currency)
        {
            var transactions = await LoadTransactions(); // Await to get the actual transactions list
            return transactions.Where(t => t.Type == TransactionType.Debt && !t.IsDebtCleared && t.Currency == currency).ToList();
        }

        // Make the method async and return a Task<List<Transaction>> for asynchronous operations
        public async Task<List<Transaction>> GetTransactionsByTags(List<string> tags, CurrencyType currency)
        {
            var transactions = await LoadTransactions(); // Await to get the actual transactions list
            return transactions.Where(t => tags.All(tag => t.Tags.Contains(tag)) && t.Currency == currency).ToList();
        }

        // Make the method async and return a Task<List<Transaction>> for asynchronous operations
        public async Task<List<Transaction>> GetSortedTransactionsByDate(CurrencyType currency, DateTime startDate, DateTime endDate)
        {
            var transactions = await LoadTransactions(); // Await to get the actual transactions list
            return transactions
                .Where(t => t.Currency == currency && t.Date >= startDate && t.Date <= endDate)
                .OrderBy(t => t.Date)
                .ToList();
        }

    }
}

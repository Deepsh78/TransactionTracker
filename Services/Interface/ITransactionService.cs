using TransactionTracker.Model;
using TransactionTracker.Model.Enums;

namespace TransactionTracker.Services.Interface
{
    public interface ITransactionService
    {
        Task<List<Transaction>> LoadTransactions();

        // Method to add a new transaction
        Task AddTransaction(Transaction transaction);

        // Method to get the total amount by transaction type and currency
        Task<decimal> GetTotalAmountByType(TransactionType type, CurrencyType currency);

        // Method to get all pending debts for a specific currency
        Task<List<Transaction>> GetPendingDebts(CurrencyType currency);

        // Method to get transactions filtered by tags and currency
        Task<List<Transaction>> GetTransactionsByTags(List<string> tags, CurrencyType currency);

        // Method to get sorted transactions based on date range and currency
        Task<List<Transaction>> GetSortedTransactionsByDate(CurrencyType currency, DateTime startDate, DateTime endDate);

    }
}


using TransactionTracker.Model;
using TransactionTracker.Model.Enums;
using TransactionTracker.Services;

namespace TransactionTracker.Components.Pages
{
    public partial class Dashboard
    {
        private decimal totalInflows;
        private decimal totalOutflows;
        private decimal totalDebts;
        private decimal clearedDebts;
        private decimal remainingDebts;
        private List<Transaction> topTransactions;

        protected override async Task OnInitializedAsync() // Make this async and return a Task
        {
            // Fetch statistics for the dashboard using await for asynchronous methods
            totalInflows = await TransactionService.GetTotalAmountByType(TransactionType.Credit, CurrencyType.NepaliRS);  // Example currency
            totalOutflows = await TransactionService.GetTotalAmountByType(TransactionType.Debit, CurrencyType.NepaliRS);
            totalDebts = await TransactionService.GetTotalAmountByType(TransactionType.Debt, CurrencyType.NepaliRS);
            remainingDebts = (await TransactionService.GetPendingDebts(CurrencyType.NepaliRS)).Sum(d => d.Amount); // Await the GetPendingDebts and then sum

            clearedDebts = totalDebts - remainingDebts;

            // Await the transaction loading and apply the ordering logic
            topTransactions = (await TransactionService.LoadTransactions())
                .OrderByDescending(t => t.Amount)
                .Take(5)
                .ToList();
        }
    }
}
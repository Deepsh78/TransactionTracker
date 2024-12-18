using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTracker.Services
{
    public static class AppState
    {
        public static string SelectedCurrency { get; set; } = "USD"; // Default to USD
    }
}

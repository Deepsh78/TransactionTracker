using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTracker.Model.Enums
{

    public enum CurrencyType
    {
        NepaliRS = 1,
        USD,
        Euro
    }

    public enum TransactionType
    {
        Credit = 1,
        Debit,
        Debt
    }
}

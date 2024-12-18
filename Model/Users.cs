using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionTracker.Model.Enums;

namespace TransactionTracker.Model
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CurrencyType PreferredCurrency { get; set; }

    }
}

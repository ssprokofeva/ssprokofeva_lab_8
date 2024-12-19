using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    internal class BankTransaction
    {
        public DateTime Timestamp { get; }
        public decimal Amount { get; }

        public BankTransaction(decimal amount)
        {
            Timestamp = DateTime.Now;
            Amount = amount;
        }
    }
}
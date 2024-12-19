using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    public class BankAccount : IDisposable
    {
        private readonly string _accountNumber;
        private decimal _balance;
        private string _type;
        private List<BankTransaction> _transactions = new List<BankTransaction>();

        private static string GenerateAccountNumber()
        {
            return Guid.NewGuid().ToString();
        }

        public BankAccount()
        {
            _accountNumber = GenerateAccountNumber();
            _balance = 0m;
            _type = "Default";
        }

        public BankAccount(decimal balance) : this()
        {
            _balance = balance;
        }

        public BankAccount(string type) : this()
        {
            _type = type;
        }

        public BankAccount(decimal balance, string type) : this(balance)
        {
            _type = type;
        }

        public BankAccount(string accountNumber, decimal balance, string type)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _type = type;
        }

        public string AccountNumber => _accountNumber;
        public decimal Balance => _balance;
        public string Type => _type;

        public decimal Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                _transactions.Add(new BankTransaction(amount));
            }
            return _balance;
        }

        public decimal Withdraw(decimal amount)
        {
            if (_balance >= amount && amount > 0)
            {
                _balance -= amount;
                _transactions.Add(new BankTransaction(-amount));
            }
            return _balance;
        }

        public bool Transfer(BankAccount destinationAccount, decimal amount)
        {
            if (Withdraw(amount) == amount)
            {
                destinationAccount.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            SaveTransactionsToFile();

            _transactions.Clear();

            GC.SuppressFinalize(this);
        }

        private void SaveTransactionsToFile()
        {
            using (StreamWriter writer = File.CreateText("transactions.txt"))
            {
                foreach (var transaction in _transactions)
                {
                    writer.WriteLine($"{transaction.Timestamp} - {transaction.Amount}");
                }
            }
        }

        ~BankAccount()
        {
            Dispose();
        }
    }
}
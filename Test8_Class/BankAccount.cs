using System;
using System.Collections.Generic;
using System.Text;

namespace Test8_Class
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                { balance += item.Amount; }
                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance.");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;            
        }
        public void MakeDeposit(decimal amount, DateTime date, string note) 
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note) 
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Not suffient funds for this withdrawl.");
            }
            var withdrawl = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawl);
        }

        public string GetAccountHistory()
        {
            //StringBuilder是可变字符串，string是不可变字符串。
            var history = new StringBuilder("Account history:\n");
            history.Append($"Accout information: Number {this.Number}, Owner {this.Owner}, Balance {this.Balance}\n");
            history.Append("Date\t\t\tAccount\tNote\n");
            foreach (var item in allTransactions)
            {
                history.Append($"{item.Date}\t{item.Amount}\t{item.Notes}\n");
            }

            return history.ToString();
        }
    }
}

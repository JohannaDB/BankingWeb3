using System.Collections.Generic;

namespace Banking.Models.Domain
{
    public interface IBankAccount
    {
        string AccountNumber { get; }
        decimal Balance { get; }
        IEnumerable<Transaction> Transactions { get; }

        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
}
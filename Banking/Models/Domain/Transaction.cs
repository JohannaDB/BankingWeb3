using System;

namespace Banking.Models.Domain
{
    public class Transaction
    {
        public decimal Amount { get; }

        public TransactionType TransactionType { get; }

        public DateTime DateOfTransaction { get; }

        public bool IsWithdraw {
            get {
                return TransactionType == TransactionType.Withdraw;
            }
        }
        public bool IsDeposit{
            get {
                return TransactionType == TransactionType.Deposit;
            }
        }
        public Transaction(decimal amount, TransactionType transactionType)
        {
            Amount = amount;
            TransactionType = transactionType;
            DateOfTransaction = DateTime.Today;
        }
    }
}

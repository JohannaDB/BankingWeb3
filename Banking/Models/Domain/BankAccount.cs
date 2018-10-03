using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Models.Domain
{
    public class BankAccount : IBankAccount
    {
        #region Fields
        //Fields ipv attributen

        //private string _accountNumber;
        private decimal _balance;
        private ICollection<Transaction> _transactions;

        //constante definiëren = sowieso static!
        //geldwaarden altijd met decimal
        //met M erachter, double bekijken als decimal
        //D voor double
        //  public const decimal WithdrawCost = 0.10M;

        //readonly, kan waarde meegegeven worden hier, of via constructor ingegeven worden
        //niet static, moet niet, als je hem static maakt kan je hem niet instatiëren in de constructor
        //  public static readonly decimal _withdrawCost = 0.10M;

        //public decimal getbalance()
        //{
        //    return _balance;
        //}

        //private void setbalance(decimal value)
        //{
        //    _balance = value;
        //} 
        #endregion

        #region Properties
        //property AccountNumber, standaard getter en setter op deze manier
        //prop & 2 keer tab, dan krijg je skelet van property
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                //value is een keyword, dat enkel bij setter kan gebruikt worden
                _balance = value;
            }
        }


        //readonly property, enkel getter
        public IEnumerable<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
        }
        public string AccountNumber { get; private set; } 


        #endregion

        #region Constructors
        //ctor, 2 keer tab = constructor
        public BankAccount(string accountNumber) : this(accountNumber, 0)
        {
        }

        //constructor aanroepen via :this(parameter)
        public BankAccount(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            _transactions = new List<Transaction>();
            //_withdrawCost = 0.10M;
        }
        #endregion

        #region Methods
        //int nrOfTimes = optionele parameter, moet achteraan de parameterlijst staan, met defaultwaarde
        public void Deposit(decimal amount/*, int nrOfTimes = 1*/)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            Balance += amount/* * nrOfTimes*/;
            _transactions.Add(new Transaction(amount, TransactionType.Deposit));
        }

        //virtual zodat je aantoont dat deze methode mag overschreven worden
        public virtual void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            Balance -= amount;
            _transactions.Add(new Transaction(amount, TransactionType.Withdraw));

        }

        public override string ToString()
        {
            return $"{AccountNumber} -- {Balance}";
        }

        public override bool Equals(object obj)
        {
            BankAccount ba = obj as BankAccount;
            //BankAccount ba = (BankAccount) obj; werpt mogelijks exception
            if (ba == null) return false;
            return AccountNumber == ba.AccountNumber;
        }

        public override int GetHashCode()
        {
            return AccountNumber.GetHashCode();
        }
        //gouden regel: als je de equals overschrijft, moet je ook de hashCode overschrijven
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Models.Domain
{
    public class BankAccount
    {
        #region Fields
        //Fields ipv attributen

        //private string _accountNumber;
        private decimal _balance;

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
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");
            Balance -= amount;
        } 
        #endregion
    }
}

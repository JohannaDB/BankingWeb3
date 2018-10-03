using Banking.Models.Domain;
using System;
using System.Collections.Generic;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myBA = new BankAccount("123-12312312-99");
            Console.WriteLine($"Account {myBA.AccountNumber} created...");
            Console.WriteLine($"Balance is currently {myBA.Balance} Euro");
            //Console.WriteLine($"Withdrawcost is {BankAccount.WithdrawCost} Euro");


            BankAccount myOtherBA = new BankAccount("123-32112332-99", 50);
            //var myOtherBA = new BankAccount("123-32112332-99", 50); -> gaan vaak var gebruiken hiervoor

            Console.WriteLine($"Account {myOtherBA.AccountNumber} created...");
            Console.WriteLine($"Balance is currently {myOtherBA.Balance} Euro");

            myBA.Deposit(1000);
            Console.WriteLine(myBA);
            myBA.Deposit(200/*, 3*/);
            Console.WriteLine(myBA);
            myBA.Withdraw(100);
            //toString wordt automatisch aangeroepen!
            Console.WriteLine(myBA);

            //IEnumerable<Transaction> transactions = myBA.Transactions;
            var transactions = myBA.Transactions;
            foreach (var item in transactions)
            {
                Console.WriteLine($"{item.DateOfTransaction} -- {item.Amount} -- {item.TransactionType}");
            }

            var mySA = new SavingsAccount("123-12312312-88", 0.01M);
            mySA.Deposit(1000);
            mySA.AddInterest();
            mySA.Withdraw(20);

            var transactions2 = mySA.Transactions;
            foreach (var item in transactions2)
            {
                Console.WriteLine($"{item.DateOfTransaction} -- {item.Amount} -- {item.TransactionType}");
            }

            Console.ReadKey();
        }
    }
}

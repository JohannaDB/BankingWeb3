using Banking.Models.Domain;
using System;

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
            Console.WriteLine($"Account {myOtherBA.AccountNumber} created...");
            Console.WriteLine($"Balance is currently {myOtherBA.Balance} Euro");

            myBA.Deposit(1000);
            Console.WriteLine($"Balance is currently {myBA.Balance} Euro");
            myBA.Deposit(200/*, 3*/);
            Console.WriteLine($"Balance is currently {myBA.Balance} Euro");
            myBA.Withdraw(100);
            Console.WriteLine($"Balance is currently {myBA.Balance} Euro");
            Console.ReadKey();
        }
    }
}

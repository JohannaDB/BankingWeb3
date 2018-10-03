namespace Banking.Models.Domain
{
    public class SavingsAccount : BankAccount
    {
        private const decimal WithdrawCost = 0.10M;
        public decimal InterestRate { get; private set; }

        //superklasse aanroepen : base
        public SavingsAccount(string accountNumber, decimal interestRate) : base(accountNumber)
        {
            InterestRate = interestRate;
        }

        public void AddInterest()
        {
            Deposit(Balance * InterestRate);
        }
        
        //je moet override erbij zetten, als je een methode wil overriden, moet je ook aangeven in de methode in de andere klasse : virtual
        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount);
            base.Withdraw(WithdrawCost);
        }
    }
}

namespace _02.BankAccounts
{
    using System;

    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { 
        
        }

        public void DepositAmount(decimal ammount)
        {
            this.Balance += ammount;
        }

        public void WithdrawAmount(decimal ammount)
        {
            if (ammount > this.Balance)
            {
                throw new ArgumentException("Amount is higher than balance in the account");
            }

            this.Balance -= ammount;
        }

        public override decimal CalculateInterestAmount(int numOfMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                throw new ArgumentException("Interest amount cannot be calculated with positive balance less than 1000");
            }

            return base.CalculateInterestAmount(numOfMonths);
        }
    }
}

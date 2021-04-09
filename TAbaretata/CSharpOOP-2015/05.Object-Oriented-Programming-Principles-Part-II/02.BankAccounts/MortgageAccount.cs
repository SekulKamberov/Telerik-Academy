namespace _02.BankAccounts
{
    using System;

    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { 
        
        }

        public void DepositAmount(decimal ammount)
        {
            this.Balance += ammount;
        }

        public override decimal CalculateInterestAmount(int numOfMonths)
        {
            if (numOfMonths < 0)
            {
                throw new ArgumentException("Number of months cannot be negative");
            }
            if (this.Customer is IndividualCustomer)
            {
                numOfMonths -= 3;
            }
            else if (this.Customer is CompanyCustomer)
            {
                if (numOfMonths <= 12)
                {
                    return 0.5m * base.CalculateInterestAmount(numOfMonths);
                }
                else
                {
                    decimal result = 0.5m * base.CalculateInterestAmount(12);
                    result += base.CalculateInterestAmount(numOfMonths - 12);
                    return result;
                }
            }
            if (numOfMonths < 0)
            {
                return 0;
            }

            return base.CalculateInterestAmount(numOfMonths);
        }
    }
}

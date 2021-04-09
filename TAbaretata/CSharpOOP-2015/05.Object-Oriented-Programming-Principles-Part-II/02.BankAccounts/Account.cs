namespace _02.BankAccounts
{
    using System;

    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get { return this.customer; }
            private set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative");
                }

                this.balance = value;
            }
        }
        
        public decimal InterestRate
        {
            get { return this.interestRate; }
            private set { this.interestRate = value; } 
        }

        public virtual decimal CalculateInterestAmount(int numOfMonths)
        {
            if (numOfMonths < 0)
            {
                throw new ArgumentException("Number of months cannot be negative");
            }

            return numOfMonths * this.InterestRate;
        }

    }
}

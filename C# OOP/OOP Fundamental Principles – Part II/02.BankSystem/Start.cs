namespace _02.BankSystem
{
    using System;
    using System.Collections.Generic;
    using _02.BankSystem.Abstract;

    public class Start
    {
        public static void Main(string[] args)
        {
            Individual individualCustomer = new Individual("Svetlin Nakov");
            DepositAccount customerDepositAccount = new DepositAccount(individualCustomer, 3, 0);
            customerDepositAccount.Deposit(1000);
            customerDepositAccount.Draw(500);
            LoanAccount customerLoanAccount = new LoanAccount(individualCustomer, 4, 0);
            customerLoanAccount.Deposit(1000);
            MortgageAccount customerMortgageAccount = new MortgageAccount(individualCustomer, 5, 0);
            customerMortgageAccount.Deposit(1000);

            Company companyCustomer = new Company("Microsoft");
            DepositAccount companyDepositAccount = new DepositAccount(companyCustomer, 3, 0);
            companyDepositAccount.Deposit(1000);
            companyDepositAccount.Draw(500);
            LoanAccount companyLoanAccount = new LoanAccount(companyCustomer, 4, 0);
            companyLoanAccount.Deposit(1000);
            MortgageAccount companyMortgageAccount = new MortgageAccount(companyCustomer, 5, 0);
            companyMortgageAccount.Deposit(1000);

            IList<Account> accounts = new List<Account>() { customerDepositAccount, customerLoanAccount, customerMortgageAccount, companyDepositAccount, companyLoanAccount, companyMortgageAccount };
            var bank = new Bank("TelerikBank", accounts);

            foreach (var account in accounts)
            {
                Console.WriteLine("{0} {1} {2} RateForEightMonths:{3} Ballance:{4}", account.Customer.Name, account.Customer.GetType().Name, account.GetType().Name, account.CalculateInterestAmount(8), account.Balance);
            }
        }
    }
}

namespace VisitorPattern
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var creditAccount = new CreditAccount("Pesho", 1000, 2000);
            Console.WriteLine(creditAccount.Balance);
            var monthlyVisitor = new MonthlyRateCalculatorVisitor();
            creditAccount.Accept(monthlyVisitor);
            Console.WriteLine(creditAccount.Balance);
            creditAccount.Accept(monthlyVisitor);
            Console.WriteLine(creditAccount.Balance);

            var interestRateVisitor = new InterestVisitor(20);
            creditAccount.Accept(interestRateVisitor);
            creditAccount.Accept(monthlyVisitor);
            Console.WriteLine(creditAccount.Balance);
            Console.WriteLine();

            var savingsAccount = new SavingsAccount("Gosho", 2000);
            savingsAccount.Accept(monthlyVisitor);
            Console.WriteLine(savingsAccount.Balance);
            savingsAccount.Accept(monthlyVisitor);
            Console.WriteLine(savingsAccount.Balance);

            savingsAccount.Accept(interestRateVisitor);
            savingsAccount.Accept(monthlyVisitor);
            Console.WriteLine(savingsAccount.Balance);
        }
    }
}

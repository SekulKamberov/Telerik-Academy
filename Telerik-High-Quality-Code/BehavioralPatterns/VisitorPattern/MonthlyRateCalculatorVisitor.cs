namespace VisitorPattern
{
    public class MonthlyRateCalculatorVisitor : IVisitor
    {
        public void Visit(IAccount bankAccount)
        {
            if (bankAccount != null)
            {
                bankAccount.Balance += bankAccount.Balance * (bankAccount.InterestRate / 100);
            }
        }
    }
}

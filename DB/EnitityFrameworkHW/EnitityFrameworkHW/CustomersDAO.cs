namespace EnitityFrameworkHW
{
    using System.Linq;

    public class CustomersDAO
    {
        public string Insert(string customerID, string companyName)
        {                                                                                         
            using(var dbContext = new NorthwindEntities())
            {
                var customer = new Customer()
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                };

                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                return customer.CustomerID;
            }
        }

        public string Insert(Customer customer)
        {
            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                return customer.CustomerID;
            }
        }

        public void Update(string id, string newCompanyName)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == id);
                if (customer != null)
                {
                    customer.CompanyName = newCompanyName;
                    dbContext.SaveChanges();
                }
            }
        }

        public void Delete(string id)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == id);
                if (customer != null)
                {
                    dbContext.Customers.Remove(customer);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}

namespace EnitityFrameworkHW
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            //// 01. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
            Console.WriteLine("========== 01 ==========");
            using (var dbContext = new NorthwindEntities())
            {
                var products = dbContext.Products.Where(p => p.ProductID < 10).ToList();

                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductName);
                }

                var prod = from c in dbContext.Products select c.ProductName;
            }

            //// 02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.
            //Console.WriteLine("========== 02 ==========");
            //var customersDAO = new CustomersDAO();
            //string randomID = "ID" + new Random().Next(0, 999);
            //var newCustomerId = customersDAO.Insert(randomID, "INSERTED Moreno Taquería");
            //Console.WriteLine("Customer inserted with ID: {0}", newCustomerId);
            //customersDAO.Update(randomID, "UPDATED Moreno Taquería");
            //customersDAO.Delete(randomID);

            //// 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            // FindAndPrintCustomers(1997, "Canada");

            // 04. Implement previous by using native SQL query and executing it through the DbContext
            // FindAndPrintCustomersSqlQuery(1997, "Canada");
            // SQL Injection prevented
            // FindAndPrintCustomersSqlQuery(1997, "Canada 'OR 1 = 1 --");

            // 05. Write a method that finds all the sales by specified region and period (start / end dates).
            // FindAndPrintSalesByCountryStartEndPeriodSqlQuery("Canada", new DateTime(1996, 11, 11), new DateTime(1997, 2, 1));

            // 06. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. 
            // Find for the API for schema generation in MSDN or in Google.
            // CloneNorthwindByConnectionStringFromAppConfig("NorthwindEntitiesClone");
            // CloneNorthwind("NorthwindForTelerik");

            // 07. Try to open two different data contexts and perform concurrent changes on the same records. 
            // What will happen at SaveChanges()? 
            // How to deal with it?

            // In Northwind.csdl file set <Property Name="CompanyName" Type="String" MaxLength="40" FixedLength="false" Unicode="true" Nullable="false" ConcurrencyMode="None" />
            // to
            // ConcurrencyMode="Fixed"
            // or from Diagram => Table => PropertyName => Properties ... ConcurencyMode
            //OpenTwoDbContexts();

            // 08. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.

            // NOT SOLVED

            //using (var db = new NorthwindEntities())
            //{
            //    var employeeTeritories = db.Employees.FirstOrDefault().TerritoriesProp;
            //    foreach (var teritory in employeeTeritories)
            //    {
            //        Console.WriteLine(teritory.TerritoryID);
            //    }
            //}
        }

        private static void FindAndPrintCustomers(int yearOfOrder, string shipingCountry)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customers = dbContext.Customers
                    .Where(c => c.Orders.Where(o => o.OrderDate.Value.Year == yearOfOrder && o.ShipCountry == shipingCountry).Count() > 0)
                    .Select(c => new { ID = c.CustomerID })
                    .ToList();

                Console.WriteLine("Customers count: " + customers.Count);

                foreach (var customer in customers)
                {
                    Console.WriteLine("ID: {0}", customer.ID);
                }

                Console.WriteLine();
                Console.WriteLine("The orders are: ");

                var orders = dbContext.Orders
                    .Where(o => o.OrderDate.Value.Year == yearOfOrder && o.ShipCountry == shipingCountry)
                    .Select(order => new
                    {
                        OrderId = order.OrderID,
                        CustomerId = order.CustomerID,
                    }).ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine("OrderId: {0}, CustomerID: {1}", order.OrderId, order.CustomerId);
                }
            }
        }

        // dbContext.Database.SqlQuery<Entity> or Model
        private static void FindAndPrintCustomersSqlQuery(int yearOfOrder, string shipCountry)
        {
            using (var dbContext = new NorthwindEntities())
            {
                string query = "SELECT * " +
                                     " FROM Customers WHERE CustomerID IN " +
                                     "(SELECT o.CustomerID FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID " +
                                     "WHERE YEAR(o.OrderDate) = @yearOfOrder AND o.ShipCountry = @shipCountry)";
                // object[] parametars = { yearOfOrder, shipCountry };

                //var queryString = dbContext.Database.SqlQuery<Customer>(query,
                //        new SqlParameter("yearOfOrder", yearOfOrder),
                //        new SqlParameter("shipCountry", shipCountry));
                //Console.WriteLine(queryString);
                //Console.WriteLine();
                var customers = dbContext.Database.SqlQuery<CustomerViewModel>(query,
                        new SqlParameter("yearOfOrder", yearOfOrder),
                        new SqlParameter("shipCountry", shipCountry))
                    .ToList<CustomerViewModel>();

                //var customers = dbContext.Database.SqlQuery<Customer>(query,
                //        new SqlParameter("yearOfOrder", yearOfOrder),
                //        new SqlParameter("shipCountry", shipCountry))
                //    .ToList<Customer>();

                foreach (var customer in customers)
                {
                    Console.WriteLine("CustomerID: {0} Country: {1}", customer.CustomerID, customer.Country);
                }
            }
        }

        private static void FindAndPrintSalesByCountryStartEndPeriodSqlQuery(string shipCountry, DateTime startPeriod, DateTime endPeriod)
        {
            using (var dbContext = new NorthwindEntities())
            {
                string query = "SELECT * FROM Orders WHERE @startPeriod < OrderDate AND OrderDate < @endPeriod AND ShipCountry = @shipCountry";
                var orders = dbContext.Database.SqlQuery<Order>(query,
                        new SqlParameter("startPeriod", startPeriod),
                        new SqlParameter("endPeriod", endPeriod),
                        new SqlParameter("shipCountry", shipCountry))
                    .ToList<Order>();

                foreach (var order in orders)
                {
                    Console.WriteLine("OrderID: {0} OrderDate: {1} ShipCountry: {2}", order.OrderID, order.OrderDate, order.ShipCountry);
                }
            }
        }

        private static void CloneNorthwindByConnectionStringFromAppConfig(string cloneName)
        {
            using (var dbContext = new NorthwindEntities("name=" + cloneName))
            {
                dbContext.Database.CreateIfNotExists();
                var randomNumber = new Random().Next(10, 99);
                dbContext.Customers.Add(new Customer() { CustomerID = "ABC" + randomNumber, CompanyName = "CLONE COMPANY" });
                dbContext.SaveChanges();

                var customers = dbContext.Customers.ToList();
                Console.WriteLine("Database Name: " + cloneName);
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CustomerID + " " + customer.CompanyName);
                }
            }
        }

        private static void CloneNorthwind(string cloneName)
        {
            string connectionString = @"metadata=res://*/NorthwindEntities.csdl|res://*/NorthwindEntities.ssdl|res://*/NorthwindEntities.msl;provider=System.Data.SqlClient;provider connection string=';data source=.\SQLEXPRESS;initial catalog=" + cloneName + ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework';";

            using (var dbContext = new NorthwindEntities(connectionString))
            {
                dbContext.Database.CreateIfNotExists();
                var randomNumber = new Random().Next(10, 99);
                dbContext.Customers.Add(new Customer() { CustomerID = "ABC" + randomNumber, CompanyName = "CLONE COMPANY" });
                dbContext.SaveChanges();

                var customers = dbContext.Customers.ToList();
                Console.WriteLine("Database Name: " + cloneName);
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CustomerID + " " + customer.CompanyName);
                }
            }
        }

        private static void OpenTwoDbContexts()
        {
            var randomNumber = new Random().Next(10, 99);
            var id = "ABC" + randomNumber;

            using (var firstDbContext = new NorthwindEntities())
            {
                var newCustomer = new Customer() { CustomerID = id, CompanyName = "COMPANY" + id };
                firstDbContext.Customers.Add(newCustomer);
                firstDbContext.SaveChanges();
                var customerSelectedByFirstDbContext = firstDbContext.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                customerSelectedByFirstDbContext.CompanyName = "Updated By First";

                using (var secondDbContext = new NorthwindEntities())
                {
                    var customerSelectedBySecondDbContext = secondDbContext.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                    customerSelectedBySecondDbContext.CompanyName = "Updated By Second";
                    secondDbContext.SaveChanges();
                    var selectedBySecondDb = secondDbContext.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                    Console.WriteLine("SecondDbContext => CompanyName: {0}", selectedBySecondDb.CompanyName);
                }

                try
                {
                    firstDbContext.SaveChanges();
                    var selectedByFirstDb = firstDbContext.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                    Console.WriteLine("FirstDbContext => CompanyName: {0}", selectedByFirstDb.CompanyName);
                }
                catch (DbUpdateConcurrencyException)
                {
                    Console.WriteLine("OptimisticConcurrencyException handled on FirstDbContext.SaveChanges()");
                }

            }

            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                Console.WriteLine("Actual CompanyName: {0}", customer.CompanyName);
            }
        }
    }

    public class OrderViewModel
    {
        public string CustomerID { get; set; }

        public int OrderID { get; set; }

        public string ShipCountry { get; set; }

        public DateTime OrderDate { get; set; }
    }

    public class CustomerViewModel
    {
        public string CustomerID { get; set; }

        public string Country { get; set; }
    }
}

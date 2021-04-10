namespace EntityFrameworkHW
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            // 01. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database

            // 02. Create a DAO class with static methods which provide functionality for inserting, 
            // modifying and deleting customers. Write a testing class.

            //Console.WriteLine();
            //Console.WriteLine("EXERCISE 2");

            //DAO.InsertCustomer("MANU1", "IVAN IVANOV IVANOV");
            //DAO.UpdateCustomer("MANU2", "DANON DANON DANON", null, "SIR");
            //DAO.DeleteCustomer("MANU2");


            // 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            //Console.WriteLine();
            //Console.WriteLine("EXERCISE 3");

            var db = new NorthwindEntities();
            using (db)
            {
                //////var orders = db.Orders
                //////    .Where(o => o.ShipCountry == "Canada")
                //////    .Where(o => o.ShippedDate.Value.Year == 1997)
                //////    .Select(c =>
                //////        new
                //////        {
                //////            ID = c.CustomerID,
                //////            Customer = c.Customer.ContactName,
                //////            ShipDate = c.ShippedDate,
                //////            Country = c.ShipCountry

                //////        });

                //////foreach (var order in orders)
                //////{
                //////    Console.WriteLine("ID = " + order.ID + ", Customer = " + order.Customer + ", ShipDate = " + order.ShipDate + ", Country = " + order.Country);
                //////}

                //////// 04. Implement previous by using native SQL query and executing it through the DbContext.
                //////Console.WriteLine();
                //////Console.WriteLine("EXERCISE 4");

                //////string nativeSQLQuery = "SELECT c.* " +
                //////                            "from Customers c " +
                //////                            "JOIN Orders o " +
                //////                            "ON o.CustomerID = c.CustomerID " +
                //////                            "WHERE o.ShipCountry = 'Canada' AND YEAR(o.ShippedDate) = 1997";

                //////var customers = db.Database.SqlQuery<Customer>(nativeSQLQuery);
                //////foreach (var cust in customers)
                //////{
                //////    Console.WriteLine(cust.CustomerID + " " + cust.CompanyName + " " + cust.ContactName + " " + cust.Region);
                //////}

                //////// 05. Write a method that finds all the sales by specified region and period (start / end dates).

                //////Console.WriteLine();
                //////Console.WriteLine("EXERCISE 5");

                //////var region = "RJ";
                //////var startPeriod = 1997;
                //////var endPeriod = 1997;
                //////var ordersByRegion = db.Orders
                //////    .Where(o => o.OrderDate.Value.Year >= startPeriod)
                //////    .Where(o => o.OrderDate.Value.Year <= endPeriod)
                //////    .Where(o => o.ShipRegion == region)
                //////    .Select(c =>
                //////        new
                //////        {
                //////            ID = c.CustomerID,
                //////            Customer = c.Customer.ContactName,
                //////            OrderDate = c.OrderDate,
                //////            Region = c.ShipRegion,
                //////            Country = c.ShipCountry

                //////        });

                //////foreach (var order in ordersByRegion)
                //////{
                //////    Console.WriteLine("ID = " + order.ID + ", Customer = " + order.Customer + ", OrderDate = " + order.OrderDate + ", Region = " + order.Region + ", Country = " + order.Country);
                //////}

                // 07. Try to open two different data contexts and perform concurrent changes on the same records. 
                // What will happen at SaveChanges()? How to deal with it?

                //var db2 = new NorthwindEntities();
                //using (db2)
                //{
                //    var customer = db.Customers.Find("MANU1");
                //    customer.CompanyName = "BMW1";
                //    customer.ContactTitle = "WOW1";
                //    db.SaveChanges();

                //    var customer2 = db2.Customers.Find("MANU1");
                //    customer2.CompanyName = "BMW2";
                //    customer2.ContactTitle = "WOW2";
                //    db2.SaveChanges();
                //}


                // 09. Create a method that places a new order in the Northwind database. 
                // The order should contain several order items. Use transaction to ensure the data consistency.

                //var query = DAO.GenerateInsertOrderQuery("VINET", 5, "Bulgaria", 
                //    new Order_Detail_No_ID[] { 
                //        new Order_Detail_No_ID(11, 100, 50, 0), 
                //        new Order_Detail_No_ID(22, 50, 40, 0)});

                //var result = db.Database.SqlQuery<Object>(query);
                //foreach (var i in result) 
                //{
                //    Console.WriteLine(i);
                //}


                // 10. Create a stored procedures in the Northwind database for finding the total incomes for given supplier name and period (start date, end date). Implement a C# method that calls the stored procedure and returns the retuned record set.

                // SORRY , no time to implement it :)

                                /*CREATE PROCEDURE dbo.usp_income (@SuplierID INT, @StartYear INT, @EndYear INT)
                                     AS
	                                     SELECT SUM(o.UnitPrice*o.Quantity*o.Discount) AS INCOME
	                                     FROM [Order Details] o
		                                     JOIN
		                                     Products p
		                                     ON o.ProductID = p.ProductID
		                                     JOIN 
		                                     Suppliers s
		                                     ON s.SupplierID = p.SupplierID
		                                     JOIN Orders ord
		                                     ON ord.OrderID = o.OrderID
	                                     WHERE s.SupplierID = @SuplierID AND (YEAR(ord.OrderDate) > @StartYear AND YEAR(ord.OrderDate) < @EndYear)
                                     GO

                                     EXEC dbo.usp_income 1, 1996, 1998
                                     GO*/
            }
        }
    }
}

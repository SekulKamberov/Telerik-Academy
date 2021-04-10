namespace EntityFrameworkHW
{
    using System;

    public class DAO
    {
        public static string GenerateInsertOrderQuery(string customerID, int employeeID, string shipCountry, Order_Detail_No_ID[] details)
        {
            var db = new NorthwindEntities();
            /*SQL 
                BEGIN TRAN

                INSERT INTO ORDERS(CustomerID, EmployeeID, ShipCountry)
                VALUES ('VINET', 5, 'Bulgaria');

                DECLARE @OrderID int;
                SET @OrderID = SCOPE_IDENTITY()

                INSERT INTO [Order Details] VALUES(@OrderID, 11, 100, 50, 0)
                INSERT INTO [Order Details] VALUES(@OrderID, 22, 50, 40, 0)

                COMMIT TRAN
             */
            var query = string.Format("BEGIN TRAN " +
                " INSERT INTO ORDERS(CustomerID, EmployeeID, ShipCountry) " +
                " VALUES ('{0}', {1}, '{2}'); " +
                " DECLARE @OrderID int; " +
                " SET @OrderID = SCOPE_IDENTITY()", customerID, employeeID, shipCountry);

            for (int i = 0; i < details.Length; i++)
            {
                query += string.Format(" INSERT INTO [Order Details] " +
                    " VALUES(@OrderID, {0}, {1}, {2}, {3})", details[i].ProductID, details[i].UnitPrice,
                        details[i].Quantity, details[i].Discount);
            }

            query += " COMMIT TRAN";

            return query;
        }

        public static void UpdateCustomer(string customerID, string companyName, string contactName = null,
               string contactTitle = null, string address = null, string city = null, string region = null,
                string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            var db = new NorthwindEntities();

            using (db)
            {

                var customer = db.Customers.Find(customerID);
                customer.CompanyName = companyName;
                customer.ContactName = contactName;
                customer.ContactTitle = contactTitle;
                customer.Address = address;
                customer.City = city;
                customer.Region = region;
                customer.PostalCode = postalCode;
                customer.Country = country;
                customer.Phone = phone;
                customer.Fax = fax;

                db.SaveChanges();
                Console.WriteLine("Customer updated.");
            }

        }

        public static void DeleteCustomer(string customerID)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var customer = db.Customers.Find(customerID);
                db.Customers.Remove(customer);
                db.SaveChanges();
                Console.WriteLine("Customer deleted.");
            }
        }

        public static void InsertCustomer(string customerID, string companyName, string contactName = null,
               string contactTitle = null, string address = null, string city = null, string region = null,
                string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            var db = new NorthwindEntities();

            using (db)
            {
                Customer customer = new Customer()
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                db.Customers.Add(customer);
                db.SaveChanges();
                Console.WriteLine("Customer inserted.");

            }
        }
    }

    public class Order_Detail_No_ID
    {
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Order_Detail_No_ID(int productID, decimal unitPrice, short quantity, float discount)
        {
            this.ProductID = productID;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Discount = discount;
        }
    }
}

namespace _04.AddProduct
{
    using System;
    using System.Data.SqlClient;
    using System.Configuration;

    class InsertProduct
    {
        // 04. Write a method that adds a new product in the products table in the Northwind database. 
        // Use a parameterized SQL command.

        static void Main(string[] args)
        {
            // connection string set in App.config file
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            SqlConnection databaseCon = new SqlConnection(connectionString.ConnectionString);
            databaseCon.Open();
            using (databaseCon)
            {
                SqlCommand cmdInsertProduct = new SqlCommand(
                  "INSERT INTO Products (ProductName, SupplierID, CategoryID, Discontinued)"
                    + "VALUES (@productName, @supplierID, @categoryID, @discontinued)", databaseCon);
                cmdInsertProduct.Parameters.AddWithValue("@productName", "BEER");
                cmdInsertProduct.Parameters.AddWithValue("@supplierID", 1);
                cmdInsertProduct.Parameters.AddWithValue("@categoryID", 1);
                cmdInsertProduct.Parameters.AddWithValue("@discontinued", false);
                cmdInsertProduct.ExecuteNonQuery();

                SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", databaseCon);
                int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
                Console.WriteLine("Product inserted with ID = " + insertedRecordId);
            }
        }
    }
}

namespace _03.JoinTables
{
    using System;
    using System.Data.SqlClient;

    class JoinTables
    {
        // 03. Write a program that retrieves from the Northwind database all product categories and the names 
        // of the products in each category. Can you do this with a single SQL query (with table join)?
        static void Main(string[] args)
        {
            const string SERVER = "SQLEXPRESS";
            SqlConnection databaseCon = new SqlConnection("Server=.\\" + SERVER + "; " +
            "Database=Northwind; Integrated Security=true");
            databaseCon.Open();
            using (databaseCon)
            {
                SqlCommand cmdProductNameAndCategory = new SqlCommand(
                  "SELECT c.CategoryName AS [Category Name], p.ProductName AS [Product Name] FROM Products p JOIN Categories c" 
                        + " ON p.CategoryID = c.CategoryID GROUP BY CategoryName, ProductName", databaseCon);
                SqlDataReader reader = cmdProductNameAndCategory.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["Category Name"];
                        string productName = (string)reader["Product Name"];
                        Console.WriteLine("{0} - {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}

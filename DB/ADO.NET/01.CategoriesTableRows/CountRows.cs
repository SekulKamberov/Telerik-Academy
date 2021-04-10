namespace _01.CategoriesTableRows
{
    using System;
    using System.Data.SqlClient;

    public class CountRows
    {
        ////  01. Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  
        ////  rows in the Categories table.

        //// CHANGE SERVER NAME IF DIFFERENT

        public static void Main(string[] args)
        {
            const string SERVER = "SQLEXPRESS";
            SqlConnection databaseCon = new SqlConnection("Server=.\\" + SERVER + "; " +
            "Database=Northwind; Integrated Security=true");
            databaseCon.Open();
            using (databaseCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", databaseCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
            }
        }
    }
}

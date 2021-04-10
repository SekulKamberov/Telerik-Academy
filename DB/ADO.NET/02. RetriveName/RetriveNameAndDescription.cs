namespace _02.RetriveName
{
    using System;
    using System.Data.SqlClient;

    class RetriveNameAndDescription
    {
        /// 02. Write a program that retrieves the name and description of all categories in the Northwind DB.

        static void Main(string[] args)
        {
            const string SERVER = "SQLEXPRESS";
            SqlConnection databaseCon = new SqlConnection("Server=.\\" + SERVER + "; " +
            "Database=Northwind; Integrated Security=true");
            databaseCon.Open();
            using (databaseCon)
            {
                SqlCommand cmdNameDescription = new SqlCommand(
                  "SELECT CategoryName, Description FROM Categories", databaseCon);
                SqlDataReader reader = cmdNameDescription.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} - {1}", categoryName, description);
                    }
                }
            }
        }
    }
}

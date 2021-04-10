namespace ADO.NET
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main(string[] args)
        {
            const string SERVER = "SQLEXPRESS";
            SqlConnection databaseCon = new SqlConnection("Server=.\\" + SERVER + "; " +
            "Database=TelerikAcademy; Integrated Security=true");
            databaseCon.Open();
            using (databaseCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Employees", databaseCon);
                int employeesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Employees count: {0} ", employeesCount);
                Console.WriteLine();

                Console.WriteLine("The most senior 10 employees:");
                SqlCommand cmdAllEmployees = new SqlCommand(
                  "SELECT TOP 10 * FROM Employees ORDER BY HireDate", databaseCon);
                SqlDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        decimal salary = (decimal)reader["Salary"];
                        Console.WriteLine("{0} {1} - {2}", firstName, lastName, salary);
                    }
                }
            }
        }
    }
}

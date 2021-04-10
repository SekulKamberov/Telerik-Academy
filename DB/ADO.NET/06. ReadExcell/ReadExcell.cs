namespace _06.ReadExcell
{
    using System;
    using System.Data.OleDb;

    class ReadExcell
    {
        // 06. Create an Excel file with 2 columns: name and score:
        // Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.

        static void Main(string[] args)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Scores.xlsx; Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

            OleDbConnection dbConn = new OleDbConnection(connectionString);

            // Open connection
            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT Name, Score FROM Scores", dbConn);

                OleDbDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        string score = (string)reader["Score"];
                        Console.WriteLine("{0} - {1}", name, score);
                    }
                }
            }
        }
    }
}

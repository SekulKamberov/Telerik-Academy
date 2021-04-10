namespace _05.RetriveImages
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class StoreImages
    {
        // 05. Write a program that retrieves the images for all categories in the Northwind database 
        // and stores them as JPG files in the file system.

        private static void WriteBinaryFile(int categoryID,
        byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(@"..\..\image" + categoryID + ".JPG");
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }

        static void Main(string[] args)
        {
            // connection string set in Settings file
            SqlConnection databaseCon = new SqlConnection(Settings.Default.DBConnectionString);
            databaseCon.Open();
            using (databaseCon)
            {
                SqlCommand cmdProductNameAndCategory = new SqlCommand(
                  "SELECT CategoryID, Picture FROM Categories", databaseCon);
                SqlDataReader reader = cmdProductNameAndCategory.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int categoryID = (int)reader["CategoryID"];
                        byte[] image = (byte[])reader["Picture"];
                        WriteBinaryFile(categoryID, image);
                        Console.WriteLine("{0}", categoryID);
                    }
                }
            }
        }
    }
}

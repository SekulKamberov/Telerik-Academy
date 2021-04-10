namespace ADO.NetHW
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            // 01. Write a program that retrieves from the Northwind sample database in MS SQL Server 
            // the number of rows in the Categories table.

            string connectionString = "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";


            //Console.WriteLine("========== 01 ==========");
            //int rows = GetNortwindCategoriesRowCount(connectionString);
            //Console.WriteLine("Categories count: {0}", rows);
            //Console.WriteLine();


            //// 02. Write a program that retrieves the name and description of all categories in the Northwind DB.
            //Console.WriteLine("========== 02 ==========");
            //GetCategoriesNameAndDescriptionAndPrint(connectionString);
            //Console.WriteLine();

            //// 03. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
            //// Can you do this with a single SQL query (with table join)?
            //Console.WriteLine("========== 03 ==========");
            //RetrieveCategoriesAndProductsInThemAndPrint(connectionString);
            //Console.WriteLine();

            //// 04. Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
            //Console.WriteLine("========== 04 ==========");
            //int productId = AddProduct(connectionString);
            //Console.WriteLine("Product inserted with ID: {0}", productId);
            //Console.WriteLine();


            //// 05. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
            //Console.WriteLine("========== 05 ==========");
            //GetCategoryImagesAndStoreThemInFileSystem(connectionString);
            //Console.WriteLine();

            //// 06. Create an Excel file with 2 columns: name and score. Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
            //Console.WriteLine("========== 06 ==========");
            //string fileLocation = "../../scores.xlsx";
            //ReadAndDisplayExcelFileData(fileLocation);
            //Console.WriteLine();

            //// 07. Implement appending new rows to the Excel file.
            //Console.WriteLine("========== 07 ==========");
            //string fileLocation = "../../scores.xlsx";
            //InsertInExcelFileScore(fileLocation, "Nakov", 100);
            //Console.WriteLine();

            // 08. Write a program that reads a string from the console and finds all products that contain this string.
            // Ensure you handle correctly characters like ', %, ", \ and _.
            Console.Write("Insert search string: ");
            string input = Console.ReadLine();
            FindAndPrintProductsByString(input, connectionString);
            Console.WriteLine();
            Console.WriteLine("TEST...");
            FindAndPrintProductsByString("p' OR 1 = 1 --", connectionString);
        }

        private static void FindAndPrintProductsByString(string input, string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                //SqlCommand getProductsBySubstring = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE '%@productName%'", sqlConnection);
                //getProductsBySubstring.Parameters.AddWithValue("@productName", input);

                SqlCommand getProductsBySubstring = new SqlCommand("DECLARE @substring nvarchar(255) = @productName SELECT ProductName FROM Products WHERE ProductName LIKE '%' + @substring + '%'", sqlConnection);
                getProductsBySubstring.Parameters.AddWithValue("@productName", input);

                SqlDataReader sqlDataReader = getProductsBySubstring.ExecuteReader();
                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        string name = (string)sqlDataReader["ProductName"];
                        Console.WriteLine("Command Name: {0}", name);
                    }
                }

            }

            sqlConnection.Close();
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            string imageFormat = ".jpg";
            string destination = "../../Images/";
            string imageURL = destination + fileName + imageFormat;
            FileStream stream = File.OpenWrite(imageURL);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        private static int GetNortwindCategoriesRowCount(string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            int rows = 0;
            sqlConnection.Open();
            using (sqlConnection)
            {
                SqlCommand getAllCategories = new SqlCommand("SELECT COUNT(*) FROM Categories", sqlConnection);
                rows = (int)getAllCategories.ExecuteScalar();

            }

            sqlConnection.Close();

            return rows;
        }

        private static void GetCategoriesNameAndDescriptionAndPrint(string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                SqlCommand getCategoriesNamesAndDescription = new SqlCommand("SELECT CategoryName, Description FROM Categories", sqlConnection);
                SqlDataReader sqlDataReader = getCategoriesNamesAndDescription.ExecuteReader();
                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        string name = (string)sqlDataReader["CategoryName"];
                        string desctiption = (string)sqlDataReader["Description"];
                        Console.WriteLine("Command Name: {0} - Description: {1}", name, desctiption);
                    }
                }

            }

            sqlConnection.Close();
        }

        private static void RetrieveCategoriesAndProductsInThemAndPrint(string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                SqlCommand productCategoriesAndNames = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c INNER JOIN Products p ON c.CategoryID = p.CategoryID GROUP BY c.CategoryName, p.ProductName", sqlConnection);
                SqlDataReader sqlDataReader = productCategoriesAndNames.ExecuteReader();
                using (sqlDataReader)
                {
                    string category = string.Empty;
                    while (sqlDataReader.Read())
                    {
                        string newCategory = (string)sqlDataReader["CategoryName"];
                        string product = (string)sqlDataReader["ProductName"];

                        if (newCategory.Equals(category) == false)
                        {
                            Console.WriteLine("===== Category: {0} ", newCategory);
                            category = newCategory;
                        }

                        Console.WriteLine("Product: {0}", product);
                    }
                }
            }

            sqlConnection.Close();
        }

        private static int AddProduct(string connectionString)
        {
            int productId;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {

                SqlCommand insertProductCommand = new SqlCommand("INSERT INTO PRODUCTS(ProductName) VALUES(@productName)", sqlConnection);
                insertProductCommand.Parameters.AddWithValue("@productName", "Software");
                insertProductCommand.ExecuteNonQuery();

                SqlCommand getNewIdCommand = new SqlCommand("SELECT @@Identity", sqlConnection);
                productId = (int)(decimal)getNewIdCommand.ExecuteScalar();
            }

            sqlConnection.Close();

            return productId;
        }

        private static void GetCategoryImagesAndStoreThemInFileSystem(string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("SELECT Picture, CategoryName FROM Categories ", sqlConnection);
                SqlDataReader sqlImagesDataReader = cmd.ExecuteReader();
                using (sqlImagesDataReader)
                {
                    byte[] image;
                    string categoryName;
                    while (sqlImagesDataReader.Read())
                    {
                        image = (byte[])sqlImagesDataReader["Picture"];
                        categoryName = (string)sqlImagesDataReader["CategoryName"];
                        WriteBinaryFile(categoryName, image);
                    }
                }
            }

            sqlConnection.Close();
        }

        private static void ReadAndDisplayExcelFileData(string fileLocation)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=Excel 12.0;";
            var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
            var ds = new DataSet();

            adapter.Fill(ds, "scores");

            //DataTable data = ds.Tables["scores"];
            var data = ds.Tables["scores"].AsEnumerable();

            var query = data.Where(x => x.IsNull("Name") == false && x.IsNull("Score") == false).Select(x =>
                new ScoreRecord
                {
                    Name = x.Field<string>("Name"),
                    Score = x.Field<double>("Score"),
                });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.Score);
            }
        }

        private static void InsertInExcelFileScore(string fileLocation, string name, double score)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=Excel 12.0;";

            OleDbConnection dbConn = new OleDbConnection(connectionString);

            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand(
                    "INSERT INTO [Sheet1$] ([Name], [Score]) VALUES (@name, @score)", dbConn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);

                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }
        }
    }

    public class ScoreRecord
    {
        public string Name { get; set; }

        public double Score { get; set; }
    }
}

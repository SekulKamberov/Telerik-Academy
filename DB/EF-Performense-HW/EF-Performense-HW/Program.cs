namespace EF_Performense_HW
{
    using System;
    using System.Diagnostics;

    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var db = new TelerikAcademyEntities();

            //var count = db.Employees.Find(1);
            //var sw = new Stopwatch();
            //sw.Start();

            ///*
            // * 01. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database 
            // * and later print their name, department and town. Try the both variants: with and without .Include(…). 
            // * Compare the number of executed SQL statements and the performance.
            // */

            ////// 677 executed SQL statements
            ////// time 00:00:01.49
            //foreach (var employee in db.Employees)
            //{
            //    Console.WriteLine("Employee name: " + employee.FirstName + " " + employee.LastName + " Department: " + employee.Department.Name + " Town: " + employee.Address.Town.Name);
            //}
            //string sqlNoInclude = sw.Elapsed.ToString();
            //Console.WriteLine(sqlNoInclude);
            //sw.Restart();

            ////// 1 executed SQL statements
            ////// time 00:00:00.81
            //foreach (var employee in db.Employees.Include("Department").Include("Address.Town"))
            //{
            //    Console.WriteLine("Employee name: " + employee.FirstName + " " + employee.LastName + " Department: " + employee.Department.Name + " Town: " + employee.Address.Town.Name);
            //}
            //string sqlInclude = sw.Elapsed.ToString();
            //Console.WriteLine(sqlInclude);
            //sw.Restart();

            ////// 1 executed SQL statements
            ////// time 00:00:00.65
            //string sqlQuery =
            //    "SELECT e.FirstName + ' ' + e.LastName AS Employee, d.Name AS Department, t.Name AS Town " +
            //    "FROM TelerikAcademy.dbo.Employees e " +
            //    "JOIN TelerikAcademy.dbo.Departments d " +
            //    "ON e.DepartmentID = d.DepartmentID " +
            //    "JOIN TelerikAcademy.dbo.Addresses a " +
            //    "ON e.AddressID = a.AddressID " +
            //    "JOIN TelerikAcademy.dbo.Towns t " +
            //    "ON a.TownID = t.TownID";
            //foreach (var employee in db.Database.SqlQuery<EmployeeQueryExample>(sqlQuery))
            //{

            //    Console.WriteLine(employee.Employee + ' ' + employee.Department + ' ' + employee.Town);
            //}
            //string sqlOnly = sw.Elapsed.ToString();
            //Console.WriteLine(sqlOnly);
            //sw.Restart();


            //Console.WriteLine("============ Results Exercise 1 ===============");
            //Console.WriteLine("NO include: " + sqlNoInclude);
            //Console.WriteLine("Include: " + sqlInclude);
            //Console.WriteLine("SQL only: " + sqlOnly);

            ///* 
            // * 02.
            // * Using Entity Framework write a query that selects all employees from the Telerik Academy database, 
            // * then invokes ToList(), then selects their addresses, then invokes ToList(), 
            // * then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia".
            // * Rewrite the same in more optimized way and compare the performance.
            // */

            // 645 queries
            //var query =
            //    db.Employees.ToList()
            //    .Select(address => address.Address).ToList()
            //    .Select(town => town.Town).ToList()
            //    .Where(town => town.Name.Equals("Sofia"));

            //foreach (var t in query)
            //{
            //    Console.WriteLine("Name: " + t.Name);
            //}

            // 1 query
            var employeesFinal =
                db.Employees
                .Select(employee => new
                {
                    Name = employee.FirstName + " " + employee.LastName,
                    Address = employee.Address.AddressText,
                    Town = employee.Address.Town.Name
                })
                .Where(t => t.Town.Equals("Sofia"))
                .ToList();

            foreach (var employee in employeesFinal)
            {
                Console.WriteLine("Name: " + employee.Name + " Address: " + employee.Address + " Town: " + employee.Town);
            }

            //Console.WriteLine(sw.Elapsed);
        }
    }

    public class EmployeeQueryExample
    {

        public string Employee { get; set; }

        public string Department { get; set; }

        public string Town { get; set; }
    }
}

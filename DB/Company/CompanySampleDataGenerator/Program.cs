namespace CompanySampleDataGenerator
{
    using CompanyData;
    using RandomGenerator;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();

            var listOfGeneratedDepartments = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, db, 100)
            };

            foreach (var department in listOfGeneratedDepartments)
            {
                department.Generate();
                db.SaveChanges();
            }

            var listOfGeneratedEmployees = new List<IDataGenerator>
            {
                new EmployeesDataGenerator(random, db, 5000)
            };

            foreach (var employee in listOfGeneratedEmployees)
            {
                employee.Generate();
                db.SaveChanges();
            }

            var listOfProgects = new List<IDataGenerator>
            {
                new ProjectDataGenerator(random, db, 1000)
            };

            foreach (var project in listOfProgects)
            {
                project.Generate();
                db.SaveChanges();
            }

            var listOfReports = new List<IDataGenerator>
            {
                new ReportsDataGenerator(random, db, 250000)
            };

            foreach (var report in listOfReports)
            {
                report.Generate();
                db.SaveChanges();
            }
        }
    }
}

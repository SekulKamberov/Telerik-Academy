namespace CompanySampleDataGenerator
{
    using CompanyData;
    using RandomGenerator;
    using System;

    internal class EmployeesDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeesDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedEntities)
            :base(randomDataGenerator, companyEntities, countOfGeneratedEntities)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Employees with no managers...");
            for (int i = 0; i < this.Count * 0.05; i++)
            {
                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithrandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithrandomLength(5, 20),
                    ManagerId = null,
                    YearSalary = this.Random.GetRandomNumber(50000, 250000),
                    DepartmentId = this.Random.GetRandomNumber(1, 100)
                };

                this.Database.Employees.Add(employee);

                if (i % 100 == 0)
                {
                    this.Database.SaveChanges();
                    Console.WriteLine("...");
                }
            }
            Console.WriteLine("Employees-no managers added");

            Console.WriteLine("Adding Employees with managers...");
            for (int i = 0; i < this.Count * 0.95; i++)
            {
                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithrandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithrandomLength(5, 20),
                    ManagerId = this.Random.GetRandomNumber(1, (int)(this.Count * 0.05)),
                    YearSalary = this.Random.GetRandomNumber(50000, 200000),
                    DepartmentId = this.Random.GetRandomNumber(1, 100)
                };

                this.Database.Employees.Add(employee);

                if (i % 100 == 0)
                {
                    this.Database.SaveChanges();
                    Console.WriteLine("...");
                }
            }
            Console.WriteLine("Employees-with managers added");
        }
    }
}

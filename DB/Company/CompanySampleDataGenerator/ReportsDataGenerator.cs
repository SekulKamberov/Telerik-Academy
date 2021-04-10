namespace CompanySampleDataGenerator
{
    using CompanyData;
    using RandomGenerator;
    using System;
    using System.Data.SqlClient;

    class ReportsDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedEntities)
            : base(randomDataGenerator, companyEntities, countOfGeneratedEntities)
        {
        }
        public override void Generate()
        {

            Console.WriteLine("Adding Reports...");
            for (int i = 1; i < 5000; i++)
            {
                for (int j = 1; j <= 50; j++)
                {
                    var report = new Report
                            {
                                DayWorked = DateTime.Now.AddDays(this.Random.GetRandomNumber(-100, 100)),
                                EmployeeId = i,
                                TimeOfReporting = DateTime.Now
                            };
                    this.Database.Reports.Add(report);
                }
                this.Database.SaveChanges();
                Console.WriteLine("...");

            }
            Console.WriteLine("Reports added");
        }
    }
}

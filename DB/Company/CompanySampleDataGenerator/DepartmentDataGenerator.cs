namespace CompanySampleDataGenerator
{
    using CompanyData;
    using RandomGenerator;
    using System;
    
    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedEntities)
            :base(randomDataGenerator, companyEntities, countOfGeneratedEntities)
        {
        }
        public override void Generate()
        {
            Console.WriteLine("Adding Departments...");
            for (int i = 0; i < this.Count; i++)
            {
                var department = new Department
                {
                    DepartmentName = this.Random.GetRandomStringWithrandomLength(10, 50)
                };

                this.Database.Departments.Add(department);

                if(i % 50 == 0)
                {
                    this.Database.SaveChanges();
                    Console.WriteLine("...");
                }
            }
            Console.WriteLine("Departments added");
        }
    }
}

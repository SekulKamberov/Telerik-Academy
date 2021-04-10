namespace CompanySampleDataGenerator
{
    using CompanyData;
    using RandomGenerator;
    using System;
    using System.Collections.Generic;


    internal class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedEntities)
            :base(randomDataGenerator, companyEntities, countOfGeneratedEntities)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Projects ...");
            for (int i = 0; i < this.Count; i++)
            {
                var progect = new Project
                {
                    ProjectName = this.Random.GetRandomStringWithrandomLength(5, 50)
                };

                this.Database.Projects.Add(progect);

                var employeesIds = new HashSet<int>();

                var numberOfEmployeesInThisProject = this.Random.GetRandomNumber(2, 20);

                while (employeesIds.Count != numberOfEmployeesInThisProject)
                {
                    employeesIds.Add(this.Random.GetRandomNumber(1, 5000));
                }

                foreach (var emplID in employeesIds)
                {
                    Console.WriteLine("Adding Employees Projects too..");
                    var empProj = new EmployeesProject
                    {
                        EmployeeId = emplID,
                        ProjectId = progect.Id,
                        StartingDate = DateTime.Now.AddDays(this.Random.GetRandomNumber(-100, 0)),
                        EndingDate = DateTime.Now.AddDays(this.Random.GetRandomNumber(1, 100))
                    };

                    this.Database.EmployeesProjects.Add(empProj);
                }

                if (i % 10 == 0)
                {
                    this.Database.SaveChanges();
                    Console.WriteLine("...");
                }
            }
            Console.WriteLine("Projects added");
        }
    }
}

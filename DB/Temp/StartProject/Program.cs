namespace StartProject
{
    using EFData;
    using EFModels;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // var dbContext = new EFDbContext();
            var data = new EFData(new EFDbContext());

            foreach (var person in data.People.All())
            {
                Console.WriteLine(person.Name);
            }

            data.People.Add(new Person
            {
                Name = "Goshko",
                Age = 22,
            });

            data.People.SaveChanges();
        }
    }
}

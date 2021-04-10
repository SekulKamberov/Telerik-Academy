using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TelerikAcademyEntities();

            using (db)
            {
                //db.Database.ExecuteSqlCommand("SELECT * FROM Employees");

                ////// select all towns
                ////var allTowns = db.Towns.ToList();
                ////foreach (var town in allTowns)
                ////{
                ////    Console.WriteLine(town.Name);
                ////}

                //var addressess = db.Addresses.Where(a => a.AddressText.StartsWith("1"));
                //foreach (var address in addressess)
                //{
                //    Console.WriteLine(address.AddressText);
                //}

                //var addresses = db.Addresses
                //    .Where(a => a.AddressText.StartsWith("2"))
                //    .OrderBy(a => a.AddressText)
                //    .Select(a =>
                //        new
                //        {
                //            TownName = a.Town.Name,
                //            AddressText = a.AddressText
                //        });
                //foreach (var address in addresses)
                //{
                //    Console.WriteLine(address.AddressText + " : " + address.TownName);
                //}

                //var address = db.Addresses.Find(3);
                //Console.WriteLine(address.AddressText);
                //address = db.Addresses
                //    .Where(a => a.AddressID == 3)
                //    .FirstOrDefault();
                //Console.WriteLine(address.AddressText);
                //address = db.Addresses
                //    .FirstOrDefault(a => a.AddressID == 3);
                //Console.WriteLine(address.AddressText);

                //var address = db.Addresses
                //    .OrderBy(a => a.AddressText)
                //    .ThenBy(a => a.Employees.Count())
                //    .Select(a =>
                //        new
                //        {
                //            Employess = a.Employees
                //            .AsQueryable()
                //            .Where(e => e.DepartmentID == 15)
                //        });

                //Console.WriteLine(address);




                //var town = new Town
                //{
                //    Name = "PlovdiV"
                //};

                //db.Towns.Add(town);
                //db.SaveChanges();

                //var savedTown = db.Towns.FirstOrDefault(t => t.Name == "PlovdiV");

                //var address = new Address
                //{
                //    AddressText = "Bul Bulgaria",
                //    Town = savedTown
                //};

                //db.Addresses.Add(address);
                //db.SaveChanges();




                ////db.Addresses.Add(new Address
                ////    {
                ////        AddressText = "Ivan",
                ////        Town = new Town
                ////        {
                ////            Name = "Dimitrovgrad"
                ////        }
                ////    });
                ////db.SaveChanges();




                //var town = db.Towns.FirstOrDefault(t => t.Name == "PlovdiV");
                //town.Name = "PLOVDIV";
                //db.SaveChanges();



                //////var towns = db.Towns.Where(t => t.Name.StartsWith("N"));
                //////foreach (var currentTown in towns)
                //////{
                //////    currentTown.Name = "VARNA";
                //////}
                //////db.SaveChanges();

                //////// partial class Project in folder Partials 
                //////db.Projects.First().TimeSinceBeginning();



                //var result = db.Database.SqlQuery<Town>("SELECT * FROM Towns");
                //foreach (var town in result)
                //{
                //    Console.WriteLine(town.Name);
                //}

                //var result = db.Database.SqlQuery<int>("SELECT Count(*) FROM Towns");
                //Console.WriteLine(result.FirstOrDefault());

                //////var queryFormat = string.Format("SELECT * FROM {0}", "Towns");
                //////var result = db.Database.SqlQuery<Town>(queryFormat);
                //////foreach (var t in result)
                //////{
                //////    Console.WriteLine(t.Name);
                //////}


                //var addresses = db.Addresses.Join(
                //    db.Towns,
                //    a => a.TownID,
                //    t => t.TownID,
                //    (a, t) => new
                //    {
                //        Address = a.AddressText,
                //        Town = t.Name
                //    });

                //foreach (var ad in addresses)
                //{
                //    Console.WriteLine(ad.Address + " " + ad.Town);
                //}



                //////var groupedByDep = db.Employees.GroupBy(e => e.DepartmentID);
                //////foreach (var group in groupedByDep)
                //////{
                //////    Console.WriteLine("+" + group.First().Department.Name + "+");

                //////    foreach (var emp in group)
                //////    {
                //////        Console.WriteLine(emp.FirstName);
                //////    }
                //////}

                // DETACHE OR MODIFY
                //var someTown = db.Towns.FirstOrDefault(t => t.Name == "SOFIA");
                //var townEntry = db.Entry(someTown);
                //townEntry.State = EntityState.Detached;

                //someTown.Name = "PLOVDIV";

                //townEntry.State = EntityState.Modified;

                //db.SaveChanges();



                ////var townToAdd = new Town
                ////{
                ////    Name = "BURGAS"
                ////};

                ////db.Entry(townToAdd).State = EntityState.Added;

                ////db.SaveChanges();
            }
        }
    }
}

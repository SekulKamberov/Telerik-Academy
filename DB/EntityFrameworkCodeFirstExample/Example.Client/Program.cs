namespace Example.Client
{
    using System;
    using System.Linq;

    using Example.Data;
    using Example.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            
            var data = new ExampleData();
            var child = new Person()
            {
                Name = "Child " + (char)(new Random().Next(40, 100) - '1'),
            };
            data.People.Add(child);
            data.People.SaveChanges();
            var newPerson = new Person()
            {
                Name = "Parent " + (char)(new Random().Next(40, 100) - '1'),
            };

            
            data.People.Add(newPerson);
            data.People.SaveChanges();
            
            //data.Kids.Add(new Kid() { ChildId = child.Id, ParentId = newPerson.Id });
            //data.Kids.SaveChanges();

            var people = data.People.All().ToList();

            foreach (var person in people)
            {
                var fatherName = person.Father == null ? string.Empty : person.Father.Name;
                var motherName = person.Mother == null ? string.Empty : person.Mother.Name;
                Console.WriteLine("Name: {0} Id: {1}", person.Name, person.Id);
                Console.WriteLine("Father: {0} Mother: {1}", fatherName, motherName);
                var children = data.Kids.All().ToList();
                //Console.WriteLine(children);
                foreach (var kid in children)
                {
                    Console.WriteLine("Kid: {0}", kid.Child.Name);
                    Console.WriteLine("Parent: {0}", kid.Parent.Name);
                }

                data.People.Delete(person);
            }

            data.People.SaveChanges();

            //var newStore = new Store() 
            //{
            //    OwnerId = newPerson.Id,
            //};
            //data.Stores.Add(newStore);
            //data.Stores.SaveChanges();
            //var stores = data.Stores.All().ToList();
            //foreach (var store in stores)
            //{
            //    Console.WriteLine("StoreId: {0} Owner: {1}", store.Id, store.Owner.Name);
            //}

        }
    }
}

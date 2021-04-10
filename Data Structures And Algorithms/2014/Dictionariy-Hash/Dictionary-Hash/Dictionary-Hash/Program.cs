namespace Dictionary_Hash
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        class Person : IComparable<Person>
        {
            public Person(string name)
            {
                this.Name = name;
            }
            public string Name { get; set; }
            public int CompareTo(Person other)
            {
                int compare = this.Name.CompareTo(other.Name);
                
                // more properties
                //if (compare != 0)
                //{
                //    return this.LastName.CompareTo(other.LastName);
                //}

                Console.WriteLine(compare);
                return compare;
            }

            public override int GetHashCode()
            {
                return this.Name.GetHashCode() << 17 ^ 31;
            }

            public override bool Equals(object obj)
            {
                // if obj not Person, person == null, NEVER USE '(Person) obj' cause it throws exception 
                var person = obj as Person;
                if (person == null)
                {
                    return false;
                }
                return this.Name == person.Name;
            }
        }

        // USE IDictionary
        static void Main(string[] args)
        {
        //    string a = "abc";
        //    Console.WriteLine(a.GetHashCode());
        //    string b = "abc";
        //    Console.WriteLine(b.GetHashCode());
        //    var dateHashCode = new DateTime(2014, 8, 25).GetHashCode();
        //    Console.WriteLine(dateHashCode);
        //    Console.WriteLine(Math.Abs(dateHashCode % 90000000));
        //    Console.WriteLine(Math.Abs(1388884466 % 90000000));

            Person a = new Person("IVAN");
            Person b = new Person("IVAT");
            b.CompareTo(a);
        }
    }
}

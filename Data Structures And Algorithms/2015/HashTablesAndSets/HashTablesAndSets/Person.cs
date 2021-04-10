namespace HashTablesAndSets
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("=====FullName: {0} {1}\nAge: {2}\n=====\nHashCode: {3}\n", this.FirstName, this.LastName, this.Age, this.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            var otherPerson = obj as Person;
            if (otherPerson == null)
            {
                return false;
            }

            bool isFirstNameEqual = this.FirstName == otherPerson.FirstName;
            bool isLastNameEqual = this.LastName == otherPerson.LastName;
            bool isAgeEqual = this.Age == otherPerson.Age;
            if (isFirstNameEqual && isLastNameEqual && isAgeEqual)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ 
                this.LastName.GetHashCode() ^ 
                this.Age.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            var compareFirstName = this.FirstName.CompareTo(other.FirstName);
            if (compareFirstName == 0)
            { 
                var compareLastName = this.LastName.CompareTo(other.LastName);
                if (compareLastName == 0)
                {
                    var compareAge = this.Age.CompareTo(other.Age);
                    return compareAge;
                }
                else
                {
                    return compareLastName;
                }
            } 
            else
            {
                return compareFirstName;
            }
        }
    }
}

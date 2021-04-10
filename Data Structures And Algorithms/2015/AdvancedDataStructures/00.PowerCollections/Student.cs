namespace _00.PowerCollections
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Student otherStudent = obj as Student;
            if (otherStudent == null)
            {
                return false;
            }

            return this.Name.Equals(otherStudent.Name) && this.Age.Equals(otherStudent.Age);
        }

        public override int GetHashCode()
        {
            var hash = this.Name.GetHashCode() << 7 ^ this.Age >> 13 ^ 123456789;
            return hash;
        }

        public int CompareTo(Student otherStudent)
        {
            int compareName = this.Name.CompareTo(otherStudent.Name);
            if (compareName == 0)
            {
                return this.Age.CompareTo(otherStudent.Age);
            }
            else
            {
                return compareName;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} Age: {1}", this.Name, this.Age);
        }
    }
}

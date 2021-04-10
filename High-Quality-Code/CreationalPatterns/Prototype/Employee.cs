namespace Prototype
{
    public abstract class Employee : EmployeePrototype
    {
        public Employee(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override abstract Employee Clone();

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.Name, this.Age);
        }
    }
}

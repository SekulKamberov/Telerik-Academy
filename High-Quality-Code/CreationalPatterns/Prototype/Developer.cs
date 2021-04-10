namespace Prototype
{
    public class Developer : Employee
    {
        public Developer(string name, int age)
            : base(name, age)
        {
        }

        public override Employee Clone()
        {
            return this.MemberwiseClone() as Developer;
        }
    }
}

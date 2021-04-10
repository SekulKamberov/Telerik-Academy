namespace Prototype
{
    public class Designer : Employee
    {
        public Designer(string name, int age)
            : base(name, age)
        {
        }

        public override Employee Clone()
        {
            return this.MemberwiseClone() as Designer;
        }
    }
}

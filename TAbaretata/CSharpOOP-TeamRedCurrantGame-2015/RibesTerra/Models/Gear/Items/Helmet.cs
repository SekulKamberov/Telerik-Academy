namespace Models.Gear.Items
{
    using System;

    using Models.Interfaces;
    using Models.Extensions;

    public class Helmet : Item, IGear, IItem
    {
        public const int defensePower = 10;

        public Helmet(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int initialDefensePoints)
            : base(initialName, initialPrice, initialDescription, initialWeight, initialDefensePoints + RandomGenerator.Instance.Next(1, 10))
        {
            this.DefensePoints = initialDefensePoints + defensePower;
        }

        public Helmet(string initialName, decimal initialPrice, int initialDefensePoints)
            : base(initialName, initialPrice, initialDefensePoints)
        {
            this.DefensePoints = initialDefensePoints + defensePower;
        }
    }
}

namespace Models.Gear.Items
{
    using System;

    using Models.CustomExceptions;
    using Models.Extensions;
    using Models.Interfaces;

    public class Armour : Item, IGear, IItem
    {
        public Armour(string initialName, decimal initialPrice, int initialDefensePoints)
            : base(initialName, initialPrice, initialDefensePoints + RandomGenerator.Instance.Next(1, 10))
        {
        }

        public Armour(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int initialDefensePoints)
            : base(initialName, initialPrice, initialDescription, initialWeight, initialDefensePoints)
        {
        }
    }
}

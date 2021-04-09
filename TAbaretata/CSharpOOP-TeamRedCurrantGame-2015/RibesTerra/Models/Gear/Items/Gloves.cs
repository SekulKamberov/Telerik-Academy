namespace Models.Gear.Items
{
    using System;
    using Models.CustomExceptions;
    using Models.Interfaces;
    using Models.Extensions;

    public class Gloves : Item, IGear, IItem
    {
        private int agilityPoints;

        public Gloves(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int initialDefensePoints, int initialAgilityPoints)
            : base(initialName, initialPrice, initialDescription, initialWeight, initialDefensePoints + RandomGenerator.Instance.Next(1, 10))
        {
            this.AgilityPoints = initialAgilityPoints;
        }

        public Gloves(string initialName, decimal initialPrice, int initialDefensePoints)
            : base(initialName, initialPrice, initialDefensePoints)
        {
        }

        public int AgilityPoints
        {
            get
            {
                return this.agilityPoints;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidRangeException<int>("Agility poins cannot be less or equal to zero!", 0);
                }
                this.agilityPoints = value;
            }
        }
    }
}

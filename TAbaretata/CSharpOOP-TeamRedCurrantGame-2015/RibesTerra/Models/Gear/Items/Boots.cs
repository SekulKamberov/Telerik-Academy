namespace Models.Gear.Items
{
    using System;
    using Models.CustomExceptions;
    using Models.Interfaces;
    using Models.Extensions;

    public class Boots : Item, IGear, IItem
    {
        public const int InitialBootsSpeed = 10;

        private int speed;

        public Boots(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int initialDefencePoints, int initialSpeed)
            : base(initialName, initialPrice, initialDescription, initialWeight, initialDefencePoints + RandomGenerator.Instance.Next(1, 10))
        {
            this.Speed = Boots.InitialBootsSpeed + initialSpeed;
        }

        public Boots(string initialName, decimal initialPrice, int initialDefensePoints)
            : base(initialName, initialPrice, initialDefensePoints)
        {
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidRangeException<int>("Speed cannot be less or equal to zero!", 0);
                }
                this.speed = value;
            }
        }
    }
}

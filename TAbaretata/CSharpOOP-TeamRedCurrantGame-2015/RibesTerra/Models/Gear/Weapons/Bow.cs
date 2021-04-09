namespace Models.Gear.Weapons
{
    using System;
    using Models.CustomExceptions;
    using Models.Interfaces;
    using Models.Extensions;

    public class Bow : Weapon, IGear, IWeapon
    {
        public const int MaxArrowAmount = 10;
        public const decimal InitialPrice = 10; 
        public const int InitialAttack = 10;    

        private int arrowAmount;

        public Bow(string initialName, decimal initialPrice, int attackPoints)
            : base(initialName, Bow.InitialPrice, Bow.InitialAttack)
        {
        }

        public Bow(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int initialAttackPoints, int initialArrowAmount)
            : base(initialName, Bow.InitialPrice, initialDescription, Gear.InitialGearWeight, Bow.InitialAttack + RandomGenerator.Instance.Next(1, 10))
        {
            this.ArrowAmount = initialArrowAmount;
        }

        public int ArrowAmount
        {
            get
            {
                return this.arrowAmount;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidRangeException<int>("Arrow amount cannot be less or equal to zero!", 0);
                }
                if (value > MaxArrowAmount)
                {
                    throw new InvalidRangeException<int>("Arrow amount cannot be more than ten!", MaxArrowAmount);
                }

                this.arrowAmount = value;
            }
        }

    }
}

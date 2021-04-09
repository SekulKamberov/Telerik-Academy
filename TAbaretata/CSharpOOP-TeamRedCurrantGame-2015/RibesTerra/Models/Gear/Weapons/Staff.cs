namespace Models.Gear.Weapons
{
    using System;
    using Models.CustomExceptions;
    using Models.Interfaces;
    using Models.Extensions;

    public class Staff : Weapon, IGear, IWeapon
    {
        public const int MaxConstructPieces = 5;

        private int constructPieces;

        public Staff(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int initialAttackPoints, int initialConstructPieces)
            : base(initialName, initialPrice, initialDescription, initialWeight, initialAttackPoints + RandomGenerator.Instance.Next(1, 10))
        {
            this.ConstructPieces = initialConstructPieces;
        }

        public Staff(string initialName, decimal initialPrice, int attackPoints)
            : base(initialName, initialPrice, attackPoints + RandomGenerator.Instance.Next(1, 10))
        {
        }

        public int ConstructPieces
        {
            get
            {
                return this.constructPieces;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidRangeException<int>("Construct pieces cannot be less or equal to zero!", 0);
                }
                if (value > MaxConstructPieces)
                {
                    throw new InvalidRangeException<int>("Construct pieces cannot be more than 5", MaxConstructPieces);
                }

                this.constructPieces = value;
            }
        }
    }
}

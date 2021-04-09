namespace Models.Gear.Weapons
{
    using System;
    using Models.CustomExceptions;
    using Models.Interfaces;
    using System.Text;

    public abstract class Weapon : Gear, IGear, IWeapon
    {
        private int attackPoints;

        public Weapon(string initialName, decimal initialPrice, int attackPoints)
            : base(initialName, initialPrice)
        {
            this.AttackPoints = attackPoints;
        }

        public Weapon(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int attackPoints)
            : base(initialName, initialPrice, initialDescription, initialWeight)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidRangeException<int>("Attack points cannot be less or equal to zero!", 0);
                }
                this.attackPoints = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(string.Format(" AP: {0}", this.AttackPoints));

            return result.ToString();
        }
    }
}

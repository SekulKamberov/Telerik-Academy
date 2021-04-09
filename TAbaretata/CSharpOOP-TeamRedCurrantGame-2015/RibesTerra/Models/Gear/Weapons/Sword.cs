namespace Models.Gear.Weapons
{
    using System;

    using Models.Interfaces;
    using Models.Extensions;

    public class Sword : Weapon, IGear, IWeapon
    {
        public Sword(string initialName, decimal initialPrice, string initialDescription, double initialWeight, int initialAttackPoints)
            : base(initialName, initialPrice, initialDescription, initialWeight, initialAttackPoints + RandomGenerator.Instance.Next(1, 10))
        {
        }

        public Sword(string initialName, decimal initialPrice, int attackPoints)
            : base(initialName, initialPrice, attackPoints + RandomGenerator.Instance.Next(1, 10))
        {
        }
    }
}

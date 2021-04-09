namespace Models
{
    using System;
    using Models.Creatures;
    using Models.Extensions;
    using Models.Interfaces;

    public class Enemy : Creature, ICreature, ICloneable
    {
        public const int InitialEnemyAttack = 20;
        public const int InitialEnemyHealth = 200;

        public Enemy(string name, int power, int health, GenderType gender)
            : base(name, Enemy.InitialEnemyAttack + RandomGenerator.Instance.Next(20, 40), Enemy.InitialEnemyHealth + RandomGenerator.Instance.Next(20, 40), gender)
        {
        }

        public Enemy(string name, GenderType gender)
            : base(name, Enemy.InitialEnemyAttack + RandomGenerator.Instance.Next(20, 40), Enemy.InitialEnemyHealth + RandomGenerator.Instance.Next(20, 40), gender)
        {
        }

        public object Clone()
        {
            var enemy = new Enemy(this.Name, this.BasePower, base.BaseHealth, this.Gender);
            enemy.Items = this.Items;
            enemy.Weapons = this.Weapons;

            return enemy;
        }
    }
}

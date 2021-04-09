namespace GameEngine.Factories
{
    using System;
    using System.Collections.Generic;
    using GameEngine;
    using Models;
    using Models.Creatures;
    using Models.Extensions;
    using Models.Interfaces;

    public class CreatureFactory : ICreatureFactory
    {
        public ICharacter CreateCharacter(string name, GenderType gender)
        {
            return new Character(name, gender);
        }

        public ICreature CreateEnemy(string name, GenderType gender)
        {
            return new Enemy(
                name,
                Enemy.InitialEnemyAttack,
                Enemy.InitialEnemyHealth,
                gender);
        }
    }
}

namespace Models.Interfaces
{
    using System;

    using Models;
    using Models.Creatures;

    public interface ICreatureFactory
    {
        ICharacter CreateCharacter(string name, GenderType gender);

        ICreature CreateEnemy(string name, GenderType gender);
    }
}

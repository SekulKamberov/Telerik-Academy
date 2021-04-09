namespace Models.Interfaces
{
    using Models.Spells;

    public interface ISpell
    {
        string SpellName { get; }

        int SpellPoints { get; }

        SpellType SpellType { get; }
    }
}

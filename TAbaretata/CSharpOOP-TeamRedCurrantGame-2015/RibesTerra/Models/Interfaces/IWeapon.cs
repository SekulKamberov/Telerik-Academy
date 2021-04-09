namespace Models.Interfaces
{
    public interface IWeapon : IGear
    {
        int AttackPoints { get; set; }
    }
}
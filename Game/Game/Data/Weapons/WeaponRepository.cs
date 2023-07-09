namespace Game.Data.Weapons;

public interface IWeaponRepository
{
    List<Weapon> GetWeapons();
}
public class WeaponRepository : IWeaponRepository
{
    public List<Weapon> GetWeapons()
    {
        return new List<Weapon>();
    }
}

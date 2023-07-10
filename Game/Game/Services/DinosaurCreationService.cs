using Game.Data;
using Game.Data.Dinosaurs;

namespace Game.Services;

public interface IDinosaurCreationService
{
    Dinosaur GetNewDinosaur(DinosaurTypeEnum dinosaurType);
    Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur);
}
public class DinosaurCreationService : IDinosaurCreationService
{
    readonly Random rand = new();

    public Dinosaur GetNewDinosaur(DinosaurTypeEnum dinosaurType)
    {
        var health = GetDinosaurHealth();

        return new Dinosaur
        {
            Name = GetDinosaurName(dinosaurType),
            Attack = GetDinosaurAttack(),
            Defense= GetDinosaurDefense(),
            CurrentHealth = health,
            TotalHealth = health
        };
    }

    private string GetDinosaurName(DinosaurTypeEnum dinosaurType)
    {
        return dinosaurType.ToString();
    }

    public int GetDinosaurHealth()
    {        
        return rand.Next(80, 100);
    }

    public int GetDinosaurAttack()
    {
        return 0;
    }
    public int GetDinosaurDefense()
    {
        return 0;
    }

    public Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur)
    {
        dinosaur.Locked = dinosaur.Locked != true;
        return dinosaur;
    }
}

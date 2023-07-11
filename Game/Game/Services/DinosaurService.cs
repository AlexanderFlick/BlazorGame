using Game.Data;
using Game.Data.Dinosaurs;

namespace Game.Services;

public interface IDinosaurService
{
    Dinosaur GetNewDinosaur(DinosaurTypeEnum dinosaurType);
    Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur);
}
public class DinosaurService : IDinosaurService
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
            TotalHealth = health,
            DinosaurType = dinosaurType,
            DinosaurColor = GetDinosaurColor(),
            DinosaurEra= GetDinosaurEra()
        };
    }

    private DinosaurEraEnum GetDinosaurEra()
    {
        return DinosaurEraEnum.Triassic;
    }

    private DinosaurColorEnum GetDinosaurColor()
    {
        return DinosaurColorEnum.Green;
    }

    private string GetDinosaurName(DinosaurTypeEnum dinosaurType)
    {
        return dinosaurType.ToString();
    }

    public int GetDinosaurHealth()
    {        
        return rand.Next(80, 101);
    }

    public int GetDinosaurAttack()
    {
        return rand.Next(10, 21);
    }
    public int GetDinosaurDefense()
    {
        return rand.Next(5, 11);
    } 

    public Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur)
    {
        dinosaur.Locked = dinosaur.Locked != true;
        return dinosaur;
    }
}

using Game.Data;
using Game.Data.Dinosaurs;

namespace Game.Services;

public interface IDinosaurCreationService
{
    Dinosaur GetNewDinosaur();
    Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur);
}
public class DinosaurCreationService : IDinosaurCreationService
{
    readonly Random rand = new();

    public Dinosaur GetNewDinosaur()
    {
        var health = GetDinosaurHealth();

        return new Dinosaur
        {
            Name = GetDinosaurName(),
            Attack = GetDinosaurAttack(),
            Defense= GetDinosaurDefense(),
            CurrentHealth = health,
            TotalHealth = health
        };
    }

    private string GetDinosaurName()
    {
        var monsterName = "";
        var randomAdj = rand.NextSingle();
        var randomNoun = rand.NextSingle();
        var adjectives = new List<string>
        {
            "Good",
            "Evil"
        };

        if (randomAdj > 0.5)
        {
            monsterName = adjectives[0];
        }
        if (randomAdj < 0.5)
        {
            monsterName = adjectives[1];
        }

        var nouns = new List<string>
        {
            " Lizard",
            " Tiger",
            " Turtle"
        };

        if (randomNoun > 0 && randomNoun <= 0.33)
        {
            monsterName += nouns[0];
        }
        if (randomNoun > 0.33 && randomNoun <= 0.66)
        {
            monsterName += nouns[1];
        }
        if (randomNoun > 0.66)
        {
            monsterName += nouns[2];
        }

        return monsterName;
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

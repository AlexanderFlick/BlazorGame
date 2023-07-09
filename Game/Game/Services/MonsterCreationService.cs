using Game.Data;

namespace Game.Services;

public interface IMonsterCreationService
{
    Fossil GetNewMonster();
    Fossil LockOrUnlockMonster(Fossil monster);
}
public class MonsterCreationService : IMonsterCreationService
{
    readonly Random rand = new();

    public Fossil GetNewMonster()
    {
        var health = GetMonsterHealth();

        return new Fossil
        {
            Name = GetMonsterName(),
            Attack = GetMonsterAttack(),
            Defense= GetMonsterDefense(),
            CurrentHealth = health,
            TotalHealth = health
        };
    }

    private string GetMonsterName()
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

    public int GetMonsterHealth()
    {        
        return rand.Next(80, 100);
    }

    public int GetMonsterAttack()
    {
        return 0;
    }
    public int GetMonsterDefense()
    {
        return 0;
    }

    public Fossil LockOrUnlockMonster(Fossil monster)
    {
        monster.Locked = monster.Locked != true;
        return monster;
    }
}

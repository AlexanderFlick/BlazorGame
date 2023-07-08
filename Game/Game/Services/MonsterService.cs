using Game.Data;

namespace Game.Services;

public interface IMonsterService
{
    Player HuntForMonster(Player player);
    Monster LockOrUnlockMonster(Monster monster);
    Player RemoveMonster(Player player, Monster monster);
}
public class MonsterService : IMonsterService
{
    readonly Random rand = new();

    public Player HuntForMonster(Player player)
    {
        if (player.Monsters.Count >= player.MaxPartySize)
            return player;

        player.Monsters.Add(GetNewMonster());
        return player;
    }

    private Monster GetNewMonster()
    {
        return new Monster 
        { 
            Name = GetMonsterName(),
            Health = GetMonsterHealth(),
            Attack= GetMonsterAttack(),
            Defense = GetMonsterDefense()
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
        return 0;
    }

    public int GetMonsterAttack()
    {
        return 0;
    }
    public int GetMonsterDefense()
    {
        return 0;
    }

    public Monster LockOrUnlockMonster(Monster monster)
    {
        monster.Locked = monster.Locked != true;
        return monster;
    }

    public Player RemoveMonster(Player player, Monster monster)
    {
        if (monster.Locked)
            return player;

        player.Monsters.Remove(monster);

        return player;
    }
}

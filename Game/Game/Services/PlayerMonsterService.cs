using Game.Data;

namespace Game.Services;

public interface IPlayerMonsterService
{
    Player HuntForMonster(Player player);
    Player RemoveMonster(Player player, Monster monster);
}
public class PlayerMonsterService : IPlayerMonsterService
{
    private readonly IMonsterCreationService _monsterCreationService;
    private Random rand = new();

    public PlayerMonsterService(IMonsterCreationService monsterCreationService)
    {
        _monsterCreationService = monsterCreationService;
    }

    public Player HuntForMonster(Player player)
    {
        if (player.Monsters.Count >= player.MaxPartySize)
            return player;

        player.Monsters.Add(_monsterCreationService.GetNewMonster());
        return player;
    }

    

    public Player RemoveMonster(Player player, Monster monster)
    {
        if (monster.Locked)
            return player;

        player.Monsters.Remove(monster);

        return player;
    }
}

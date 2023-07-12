using Game.Data;
using Game.Data.Enemies;

namespace Game.Services;

public interface IBattleService
{

}
public class BattleService : IBattleService
{
    Random rand = new();
    public void Battle(Player player, Enemy enemy)
    {
        
    }
}

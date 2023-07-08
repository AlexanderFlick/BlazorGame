using Game.Data;
using Microsoft.AspNetCore.Components;

namespace Game.Services;

public interface IGoldService
{
    void GetGold(Player player);
    bool HasEnough(Player player, int cost);
    int Pay(int cost, int total);
}
public class GoldService : IGoldService
{
    public void GetGold(Player player)
    {
        player.Gold += player.GoldPerClick;
    }

    public bool HasEnough(Player player, int cost)
    {
        return (player.Gold >= cost);
    }

    public int Pay(int cost, int total)
    {
        return total -= cost;
    }
}

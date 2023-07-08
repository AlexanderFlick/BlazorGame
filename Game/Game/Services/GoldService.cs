using Game.Data;
using Microsoft.AspNetCore.Components;

namespace Game.Services;

public interface IGoldService
{
    void GetGold(Player player);
}
public class GoldService : IGoldService
{
    public void GetGold(Player player)
    {
        player.Gold += player.GoldPerClick;
    }
}

using Game.Data;
using System.Threading;

namespace Game.Services;

public interface IAmberService
{
    void GetAmber(Player player);
    bool HasEnough(Player player, int cost);
    int Pay(int cost, int total);
}
public class AmberService : IAmberService
{
    public void GetAmber(Player player) => player.Amber += player.AmberPerClick;

    public bool HasEnough(Player player, int cost) => (player.Amber >= cost);

    public int Pay(int cost, int total) => total -= cost;
}

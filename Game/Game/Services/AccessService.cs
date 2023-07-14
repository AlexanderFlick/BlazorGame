using Game.Data;

namespace Game.Services;

public interface IAccessService
{
    void SetFossilFusionAccess(Player player);
    void SetBattleAccess(Player player);
    void SetAccessIfFirstDinosaur(Player player);
}
public class AccessService : IAccessService
{
    public void SetFossilFusionAccess(Player player)
    {
        if (player.Fossils.Count > 4)
        {
            player.Access.FossilFusion = true;
        }
    }
    
    public void SetBattleAccess(Player player)
    {
        player.Access.Battle = true;
    }

    public void SetAccessIfFirstDinosaur(Player player)
    {
        player.Access.Party = true;
        player.Access.AmberHunting = true;
    }
}

using Game.Data;

namespace Game.Services;

public interface IAccessService
{
    void SetFossilFusionAccess(Player player);
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
    
}

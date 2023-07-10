using Game.Data;
using Game.Data.Dinosaurs;
using Game.Data.Fossils;

namespace Game.Services;

public interface IFusionService
{
    bool HasResourcesToMakeDinosaur(Player player, Dinosaur dinosaur);
}
public class FusionService : IFusionService
{
    public bool HasResourcesToMakeDinosaur(Player player, Dinosaur dinosaur)
    {
        var skull = false;
        var claw = false;
        var ribs = false;
        var foot = false;

        if(dinosaur.DinosaurCost.Skull <= player.Fossils.Where(x => x.FossilType == FossilType.Skull).Count())
        {
            skull = true;
        }
        if (dinosaur.DinosaurCost.Claw <= player.Fossils.Where(x => x.FossilType == FossilType.Claw).Count())
        {
            claw = true;
        }
        if (dinosaur.DinosaurCost.Rib <= player.Fossils.Where(x => x.FossilType == FossilType.Ribs).Count())
        {
            ribs = true;
        }
        if (dinosaur.DinosaurCost.Foot <= player.Fossils.Where(x => x.FossilType == FossilType.Foot).Count())
        {
            foot = true;
        }

        return (claw && skull && ribs && foot);
    }
}

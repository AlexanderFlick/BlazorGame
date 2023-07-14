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
        var spikes = false;

        if (dinosaur.DinosaurType == DinosaurTypeEnum.Carnivore)
        {
            if (dinosaur.Cost.Claw <= player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Claw).Count())
            {
                claw = true;
            }
        }
        if (dinosaur.DinosaurType == DinosaurTypeEnum.Herbivore)
        {
            if (dinosaur.Cost.TailSpike <= player.Fossils.Where(x => x.HerbivoreFossils == HerbivoreFossil.TailSpikes).Count())
            {
                spikes = true;
            }
        }

        if (dinosaur.Cost.Skull <= player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Skull || x.HerbivoreFossils == HerbivoreFossil.Skull).Count())
        {
            skull = true;
        }
        if (dinosaur.Cost.Rib <= player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Ribs || x.HerbivoreFossils == HerbivoreFossil.Ribs).Count())
        {
            ribs = true;
        }
        if (dinosaur.Cost.Foot <= player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Foot || x.HerbivoreFossils == HerbivoreFossil.Foot).Count())
        {
            foot = true;
        }
        if (dinosaur.DinosaurType == DinosaurTypeEnum.Carnivore)
        {
            return (claw && skull && ribs && foot);
        }

        return (spikes && skull && ribs && foot);
    }
}

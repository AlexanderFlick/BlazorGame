using Game.Data;
using Game.Data.Dinosaurs;
using Game.Data.Fossils;

namespace Game.Services;

public interface IPlayerFossilService
{
    Fossil? SpliceAmberForFossil(Player player);
    Player RemoveFossils(Player player, Dinosaur dinosaur);
}
public class PlayerFossilService : IPlayerFossilService
{
    Random rand = new();

    public Fossil? SpliceAmberForFossil(Player player)
    {
        var fossilChance = rand.Next(1, 1001);
        if(fossilChance < 666)
        {
            return null;
        }

        var fossil = new Fossil
        {
            DinosaurType = GetDinosaurType()
        };

        if (fossil.DinosaurType == DinosaurTypeEnum.Carnivore)
        {
            fossil.CarnivoreFossils = GetCarnivoreFossil();
        }

        if (fossil.DinosaurType == DinosaurTypeEnum.Herbivore)
        {
            fossil.HerbivoreFossils = GetHerbivoreFossil();
        }

        return fossil;
    }

    private CarnivoreFossil GetCarnivoreFossil()
    {
        var fossilType = rand.Next(0, 4);
        if (fossilType == 0)
            return CarnivoreFossil.Skull;
        if (fossilType == 1)
            return CarnivoreFossil.Claw;
        if (fossilType == 2)
            return CarnivoreFossil.Ribs;
        if (fossilType == 3)
            return CarnivoreFossil.Foot;

        return CarnivoreFossil.Foot;
    }

    private HerbivoreFossil GetHerbivoreFossil()
    {
        var fossilType = rand.Next(0, 4);
        if (fossilType == 0)
            return HerbivoreFossil.Skull;
        if (fossilType == 1)
            return HerbivoreFossil.TailSpikes;
        if (fossilType == 2)
            return HerbivoreFossil.Ribs;
        if (fossilType == 3)
            return HerbivoreFossil.Foot;

        return HerbivoreFossil.Foot;
    }

    private DinosaurTypeEnum GetDinosaurType()
    {
        var dinoType = rand.Next(0, 2);
        if (dinoType == 0)
        {
            return DinosaurTypeEnum.Carnivore;
        }

        return DinosaurTypeEnum.Herbivore;
    }

    public Player RemoveFossils(Player player, Dinosaur dinosaur)
    {
        if (dinosaur.DinosaurType == DinosaurTypeEnum.Carnivore)
        {
            
            for (int i = 0; i < dinosaur.Cost.Claw; i++)
            {
                var claw = player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Claw).First();
                player.Fossils.Remove(claw);
            }            
        }

        if (dinosaur.DinosaurType == DinosaurTypeEnum.Herbivore)
        {
            for (int i = 0; i < dinosaur.Cost.TailSpike; i++)
            {
                var claw = player.Fossils.Where(x => x.HerbivoreFossils == HerbivoreFossil.TailSpikes).First();
                player.Fossils.Remove(claw);
            }
        }

        for (int i = 0; i < dinosaur.Cost.Foot; i++)
        {
            var foot = player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Foot || x.HerbivoreFossils == HerbivoreFossil.Foot).First();
            player.Fossils.Remove(foot);
        }
        for (int i = 0; i < dinosaur.Cost.Rib; i++)
        {
            var rib = player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Ribs || x.HerbivoreFossils == HerbivoreFossil.Ribs).First();
            player.Fossils.Remove(rib);
        }
        for (int i = 0; i < dinosaur.Cost.Skull; i++)
        {
            var skull = player.Fossils.Where(x => x.CarnivoreFossils == CarnivoreFossil.Skull || x.HerbivoreFossils == HerbivoreFossil.Skull).First();
            player.Fossils.Remove(skull);
        }

        return player;
    }
}

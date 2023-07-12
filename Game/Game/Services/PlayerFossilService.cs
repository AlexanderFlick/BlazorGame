using Game.Data;
using Game.Data.Dinosaurs;
using Game.Data.Fossils;

namespace Game.Services;

public interface IPlayerFossilService
{
    Player SpliceAmberForFossil(Player player);
    Player RemoveFossils(Player player, Dinosaur dinosaur);
}
public class PlayerFossilService : IPlayerFossilService
{
    Random rand = new();
    public Player SpliceAmberForFossil(Player player)
    {
        var fossil = new Fossil
        {
            FossilType = GetFossilType(),
            DinosaurType = GetDinosaurType()
        };

        player.Fossils.Add(fossil);
        return player;
    }

    private FossilType GetFossilType()
    {
        var fossilType = rand.Next(0, 4);
        if (fossilType == 0)
            return FossilType.Skull;
        if (fossilType == 1)
            return FossilType.Claw;
        if (fossilType == 2)
            return FossilType.Ribs;
        if (fossilType == 3)
            return FossilType.Foot;

        return FossilType.Ribs;
    }

    private DinosaurTypeEnum GetDinosaurType()
    {
        var dinoType = rand.Next(0, 1);
        if (dinoType == 0)
            return DinosaurTypeEnum.Raptor;
        if (dinoType == 1)
            return DinosaurTypeEnum.TRex;

        return DinosaurTypeEnum.Raptor;
    }

    public Player RemoveFossils(Player player, Dinosaur dinosaur)
    {
        for (int i = 0; i < dinosaur.DinosaurCost.Skull; i++)
        {
            var skull = player.Fossils.Where(x => x.FossilType == FossilType.Skull).First();
            player.Fossils.Remove(skull);
        }
        for (int i = 0; i < dinosaur.DinosaurCost.Claw; i++)
        {
            var claw = player.Fossils.Where(x => x.FossilType == FossilType.Claw).First();
            player.Fossils.Remove(claw);
        }
        for (int i = 0; i < dinosaur.DinosaurCost.Foot; i++)
        {
            var foot = player.Fossils.Where(x => x.FossilType == FossilType.Foot).First();
            player.Fossils.Remove(foot);
        }
        for (int i = 0; i < dinosaur.DinosaurCost.Rib; i++)
        {
            var rib = player.Fossils.Where(x => x.FossilType == FossilType.Ribs).First();
            player.Fossils.Remove(rib);
        }
        return player;
    }
}

using Game.Data;
using Game.Data.Dinosaurs;
using Game.Data.Fossils;

namespace Game.Services;

public interface IPlayerFossilService
{
    Player HuntForFossil(Player player);
}
public class PlayerFossilService : IPlayerFossilService
{
    Random rand = new();
    public Player HuntForFossil(Player player)
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
        var fossilType = rand.Next(0, 3);
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
}

using Game.Data;
using Game.Data.Dinosaurs;

namespace Game.Services;

public interface IPlayerDinosaurService
{
    Player CreateDinosaur(Player player, DinosaurTypeEnum dinosaurType);
    Player RemoveDinosaur(Player player, Dinosaur dinosaur);
}
public class PlayerDinosaurService : IPlayerDinosaurService
{
    private readonly IDinosaurService _dinosaurCreationService;

    public PlayerDinosaurService(IDinosaurService dinosaurCreationService)
    {
        _dinosaurCreationService = dinosaurCreationService;
    }

    public Player CreateDinosaur(Player player, DinosaurTypeEnum dinosaurType)
    {
        if (player.Dinosaurs.Count >= player.MaxPartySize)
        {
            return player;
        }

        player.Dinosaurs.Add(_dinosaurCreationService.GetNewDinosaur(player, dinosaurType));
        return player;
    }

    public Player RemoveDinosaur(Player player, Dinosaur dinosaur)
    {
        if (dinosaur.Locked)
        {
            return player;
        }

        player.Dinosaurs.Remove(dinosaur);

        return player;
    }
}

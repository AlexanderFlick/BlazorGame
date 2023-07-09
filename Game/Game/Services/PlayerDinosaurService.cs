using Game.Data;
using Game.Data.Dinosaurs;

namespace Game.Services;

public interface IPlayerDinosaurService
{
    Player CreateDinosaur(Player player);
    Player RemoveDinosaur(Player player, Dinosaur dinosaur);
}
public class PlayerDinosaurService : IPlayerDinosaurService
{
    private readonly IDinosaurCreationService _dinosaurCreationService;
    private Random rand = new();

    public PlayerDinosaurService(IDinosaurCreationService dinosaurCreationService)
    {
        _dinosaurCreationService = dinosaurCreationService;
    }

    public Player CreateDinosaur(Player player)
    {
        if (player.Dinosaurs.Count >= player.MaxPartySize)
            return player;

        player.Dinosaurs.Add(_dinosaurCreationService.GetNewDinosaur());
        return player;
    }    

    public Player RemoveDinosaur(Player player, Dinosaur dinosaur)
    {
        if (dinosaur.Locked)
            return player;

        player.Dinosaurs.Remove(dinosaur);

        return player;
    }
}

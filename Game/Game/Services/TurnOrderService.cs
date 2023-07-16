using Game.Data.Dinosaurs.DinosaurMoves;
using Game.Data.Dinosaurs;
using Game.Data.Enemies;
using Game.Data;

namespace Game.Services;

public interface ITurnOrderService
{
    List<Dinosaur> GetTurnOrder(Player player, List<Enemy> enemies);
}
public class TurnOrderService : ITurnOrderService
{
    public List<Dinosaur> GetTurnOrder(Player player, List<Enemy> enemies)
    {
        var allDinosaursBattling = new List<Dinosaur>();
        var dinosToReturn = new List<Dinosaur>();
        var defendingDinos = new List<Dinosaur>();
        var attackingDinos = new List<Dinosaur>();
        var ultimateDinos = new List<Dinosaur>();

        allDinosaursBattling.AddRange(enemies);
        allDinosaursBattling.AddRange(player.Dinosaurs.Where(x => x.Battle.Selected));

        foreach (var dino in allDinosaursBattling)
        {
            foreach (var moveset in dino.Moves)
            {
                if (moveset.Selected && moveset.MoveType == MoveType.UltimateCharge)
                {
                    ultimateDinos.Add(dino);
                }
            }
        }
        ultimateDinos = ultimateDinos.OrderByDescending(x => x.Battle.Speed).ToList();
        dinosToReturn.AddRange(ultimateDinos);

        foreach (var dino in allDinosaursBattling)
        {
            foreach (var moveset in dino.Moves)
            {
                if (moveset.Selected && moveset.MoveType == MoveType.Defensive)
                {
                    defendingDinos.Add(dino);
                }
            }
        }
        defendingDinos = defendingDinos.OrderByDescending(x => x.Battle.Speed).ToList();
        dinosToReturn.AddRange(defendingDinos);

        foreach (var dino in allDinosaursBattling)
        {
            foreach (var moveset in dino.Moves)
            {
                if (moveset.Selected && moveset.MoveType == MoveType.Offensive)
                {
                    attackingDinos.Add(dino);
                }
            }
        }
        attackingDinos = attackingDinos.OrderByDescending(x => x.Battle.Speed).ToList();
        dinosToReturn.AddRange(attackingDinos);

        return dinosToReturn;
    }
}

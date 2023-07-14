using Game.Data;
using Game.Data.Dinosaurs;
using Game.Data.Dinosaurs.DinosaurMoves;

namespace Game.Services;

public interface IDinosaurService
{
    Dinosaur GetNewDinosaur(Player player, DinosaurTypeEnum dinosaurFossilType);
    Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur);
}
public class DinosaurService : IDinosaurService
{
    private readonly IDinosaurMoveRepository _dinoMoves;
    readonly Random rand = new();

    public DinosaurService(IDinosaurMoveRepository dinosaurMoveRepository)
    {
        _dinoMoves = dinosaurMoveRepository;
    }

    public Dinosaur GetNewDinosaur(Player player, DinosaurTypeEnum dinosaurFossilType)
    {
        var health = GetDinosaurHealth();

        var dinoToReturn = new Dinosaur
        {
            CurrentHealth = health,
            TotalHealth = health,
            DinosaurType = dinosaurFossilType,
            DinosaurColor = GetDinosaurColor(),
            DinosaurEra = GetDinosaurEra(player),
            PartyPosition = (player.Dinosaurs.Count + 1),
            BaseDefense = GetDinosaurBaseDefense()
        };

        dinoToReturn.Name = dinoToReturn.DinosaurType == DinosaurTypeEnum.Carnivore ? GetCarnivore().ToString() : GetHerbivore().ToString();
        dinoToReturn.Moves.AddRange(GetMoves(dinosaurFossilType));

        return dinoToReturn;
    }

    private int GetDinosaurBaseDefense() => rand.Next(10, 13);

    private static DinosaurEraEnum GetDinosaurEra(Player player) => player.Era;

    public int GetDinosaurHealth() => rand.Next(80, 101);

    private DinosaurColorEnum GetDinosaurColor()
    {
        var rarity = rand.Next(1, 1001);

        if (rarity < 680)
        {
            return DinosaurColorEnum.Green;
        }
        if (rarity < 950)
        {
            return DinosaurColorEnum.Blue;
        }
        if (rarity < 997)
        {
            return DinosaurColorEnum.Red;
        }

        return DinosaurColorEnum.Albino;
    }

    public Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur)
    {
        dinosaur.Locked = dinosaur.Locked != true;
        return dinosaur;
    }

    private Carnivores GetCarnivore()
    {
        var types = rand.Next(0, 101);
        if (types < 90)
        {
            return Carnivores.Raptor;
        }

        return Carnivores.Trex;
    }

    private Herbivores GetHerbivore()
    {
        var types = rand.Next(0, 101);
        if (types < 90)
        {
            return Herbivores.Stegasaurus;
        }

        return Herbivores.Triceratops;
    }

    private List<Move> GetMoves(DinosaurTypeEnum dinosaurType)
    {
        var newMoves = new List<Move>();

        if (dinosaurType == DinosaurTypeEnum.Carnivore)
        {
            newMoves.Add(_dinoMoves.GetOffensiveMoves().Last());
            newMoves.Add(_dinoMoves.GetDefensiveMoves().First());
        }
        if (dinosaurType == DinosaurTypeEnum.Herbivore)
        {
            newMoves.Add(_dinoMoves.GetOffensiveMoves().First());
            newMoves.Add(_dinoMoves.GetDefensiveMoves().Last());
        }

        return newMoves;
    }
}

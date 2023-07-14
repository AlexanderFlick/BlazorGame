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
        _dinoMoves= dinosaurMoveRepository;
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
            PartyPosition = (player.Dinosaurs.Count + 1)
        };

        dinoToReturn.Name = dinoToReturn.DinosaurType == DinosaurTypeEnum.Carnivore ? GetCarnivore().ToString() : GetHerbivore().ToString();
        dinoToReturn.Moves.AddRange(_dinoMoves.GetOffensiveMoves());
        dinoToReturn.Moves.AddRange(_dinoMoves.GetDefensiveMoves());
        return dinoToReturn;
    }

    private int GetDinosaurBaseDefense()
    {
        return rand.Next(10, 13);
    }

    private DinosaurEraEnum GetDinosaurEra(Player player)
    {
        return player.Era;
    }

    private DinosaurTypeEnum GetDinosaurType()
    {
        var types = rand.Next(0, 101);
        if(types < 50)
        {
            return DinosaurTypeEnum.Carnivore;
        }

        return DinosaurTypeEnum.Herbivore;
    }

    private DinosaurColorEnum GetDinosaurColor()
    {
        var rarity = rand.Next(1, 1001);

        if(rarity < 680)
        {
            return DinosaurColorEnum.Green;
        }
        if(rarity < 950)
        {
            return DinosaurColorEnum.Blue;
        }
        if(rarity < 997)
        {
            return DinosaurColorEnum.Red;
        }

        return DinosaurColorEnum.Albino;
    }

    private string GetDinosaurName(DinosaurTypeEnum dinosaurType)
    {
        return dinosaurType.ToString();
    }

    public int GetDinosaurHealth()
    {        
        return rand.Next(80, 101);
    }

    public Dinosaur LockOrUnlockDinosaur(Dinosaur dinosaur)
    {
        dinosaur.Locked = dinosaur.Locked != true;
        return dinosaur;
    }

    private Carnivores GetCarnivore()
    {
        var types = rand.Next(0, 101);
        if(types < 90)
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

        if(dinosaurType == DinosaurTypeEnum.Carnivore)
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

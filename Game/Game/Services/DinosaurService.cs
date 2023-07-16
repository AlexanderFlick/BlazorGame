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
            DinosaurColor = GetMutation(),
            DinosaurEra = GetEra(player),
            PartyPosition = (player.Dinosaurs.Count + 1),
            Battle = GetBattleStats(dinosaurFossilType)
        };

        dinoToReturn.Name = dinoToReturn.DinosaurType == DinosaurTypeEnum.Carnivore ? GetCarnivore().ToString() : GetHerbivore().ToString();
        dinoToReturn.Moves.AddRange(GetMoves(dinosaurFossilType));

        return dinoToReturn;
    }

    private BattleStat GetBattleStats(DinosaurTypeEnum dinosaurType)
    {
        var statsToReturn = new BattleStat();

        if (dinosaurType == DinosaurTypeEnum.Carnivore)
        {
            statsToReturn.AttackModifier = 7;
            statsToReturn.BaseDefense = 10;
            statsToReturn.Speed = rand.Next(50, 101);
        }
        if (dinosaurType == DinosaurTypeEnum.Herbivore)
        {
            statsToReturn.AttackModifier = 3;
            statsToReturn.BaseDefense = 14;
            statsToReturn.Speed = rand.Next(40, 101);
        }
        return statsToReturn;
    }

    private static DinosaurEraEnum GetEra(Player player) => player.Era;

    public int GetDinosaurHealth() => rand.Next(80, 101);

    private DinosaurMutationEnum GetMutation()
    {
        var rarity = rand.Next(1, 1001);

        if (rarity < 680)
        {
            return DinosaurMutationEnum.Green;
        }
        if (rarity < 950)
        {
            return DinosaurMutationEnum.Blue;
        }
        if (rarity < 997)
        {
            return DinosaurMutationEnum.Red;
        }

        return DinosaurMutationEnum.Albino;
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

        newMoves.AddRange(_dinoMoves.GetUltimateChargeMoves());

        return newMoves;
    }
}

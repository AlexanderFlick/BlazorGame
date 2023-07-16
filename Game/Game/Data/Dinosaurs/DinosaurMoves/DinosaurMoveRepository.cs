namespace Game.Data.Dinosaurs.DinosaurMoves;

public interface IDinosaurMoveRepository
{
    List<Move> GetOffensiveMoves();
    List<Move> GetDefensiveMoves();
    List<Move> GetEnemyMoves();
    List<Move> GetUltimateChargeMoves();
}
public class DinosaurMoveRepository : IDinosaurMoveRepository
{
    public List<Move> GetDefensiveMoves()
    {
        return new List<Move>
        {
            new Move
            {
                Name = "Swift Dodge",
                MoveType = MoveType.Defensive,
                Hit = HitScope.One,
                DiceCount = 2,
                DiceSize = 3,                
                ChargeIncrease = 10
            },
            new Move
            {
                Name = "Ten Foot Jump",
                MoveType = MoveType.Defensive,
                Hit = HitScope.One,
                DiceCount = 1,
                DiceSize = 4,                
                ChargeIncrease = 10
            }
        };
    }

    public List<Move> GetOffensiveMoves()
    {
        return new List<Move>
        {
            new Move
            {
                Name = "Vicious Bite",
                MoveType = MoveType.Offensive,
                Hit = HitScope.One,
                DiceCount = 1,
                DiceSize = 8,
                ChargeIncrease = 10
            },
            new Move
            {
                Name = "Swift Claws",
                MoveType = MoveType.Offensive,
                Hit = HitScope.One,
                DiceCount = 2,
                DiceSize = 4,
                ChargeIncrease = 10
            },
        };
    }

    public List<Move> GetUltimateChargeMoves()
    {
        return new List<Move>
        {
            new Move
            {
                Name = "Pass Turn",
                MoveType = MoveType.UltimateCharge,
                ChargeIncrease = 25
            }
        };
    }

    public List<Move> GetEnemyMoves()
    {
        return new List<Move>
        {
            new Move
            {
                Name = "Tail Swipe",
                MoveType = MoveType.Offensive,
                Hit = HitScope.All,
                DiceCount = 1,
                DiceSize = 10,
                ChargeIncrease = 0
            },
            new Move
            {
                Name = "Headbutt",
                MoveType = MoveType.Offensive,
                Hit = HitScope.One,
                DiceCount = 1,
                DiceSize = 5,
                ChargeIncrease = 0
            },
            new Move
            {
                Name = "Armor Plating",
                MoveType = MoveType.Defensive,
                Hit = HitScope.One,
                DiceCount = 1,
                DiceSize = 3,
                ChargeIncrease = 0
            },
            new Move
            {
                Name = "Running Start",
                MoveType = MoveType.Defensive,
                Hit = HitScope.One,
                DiceCount = 2,
                DiceSize = 8,
                ChargeIncrease = 0
            }
        };
    }
}

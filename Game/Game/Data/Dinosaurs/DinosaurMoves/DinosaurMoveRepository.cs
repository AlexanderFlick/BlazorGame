namespace Game.Data.Dinosaurs.DinosaurMoves;

public interface IDinosaurMoveRepository
{
    List<Move> GetOffensiveMoves();
    List<Move> GetDefensiveMoves();
}
public class DinosaurMoveRepository : IDinosaurMoveRepository
{
    public List<Move> GetDefensiveMoves()
    {
        return new List<Move>
        {
            new Move
            {
                Name = "Dodge",
                MoveType = MoveType.Defensive,
                DiceCount = 2,
                DiceSize = 3
            },
            new Move
            {
                Name = "Jump",
                MoveType = MoveType.Defensive,
                DiceCount = 1,
                DiceSize = 4
            }
        };
    }

    public List<Move> GetOffensiveMoves()
    {
        return new List<Move>
        {
            new Move
            {
                Name = "Bite",
                MoveType = MoveType.Offensive,
                DiceCount = 1,
                DiceSize = 8
            },
            new Move
            {
                Name = "Claw",
                MoveType = MoveType.Offensive,
                DiceCount = 2,
                DiceSize = 4
            },
        };
    }
}

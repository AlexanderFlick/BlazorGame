namespace Game.Data.Dinosaurs.DinosaurMoves;

public class Move
{
    public string Name { get; set; }
    public int DiceSize { get; set; } = 6;
    public MoveType MoveType { get; set; }
}

public enum MoveType
{
    Offensive,
    Defensive
}

namespace Game.Data.Dinosaurs.DinosaurMoves;

public class Move
{
    public string? Name { get; set; }
    public int DiceCount { get; set; } = 1;
    public int DiceSize { get; set; } = 6;
    public int ChargeIncrease { get; set; }
    public int DamageDone { get; set; }
    public int BaseDefenseIncrease { get; set; }
    public bool IncludeForBattle { get; set; }
    public bool Selected { get; set; }
    public List<bool> SuccessfulHits { get; set; } = new List<bool>();
    public MoveType MoveType { get; set; }
    public HitScope Hit { get; set; }
    
}

public enum MoveType
{
    Offensive,
    Defensive,
    UltimateCharge
}

public enum HitScope
{
    One,
    All
}

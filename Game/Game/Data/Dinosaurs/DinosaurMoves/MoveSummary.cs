namespace Game.Data.Dinosaurs.DinosaurMoves;

public class MoveSummary
{
    public string? Attacker { get; set; }
    public string? Defender { get; set; }
    public MoveType MoveType { get; set; }
    public HitScope Hit { get; set; }
    public string MoveName { get; set; }
    public List<bool> Successes { get; set; } = new List<bool>();
    public int DefensiveIncrease { get; set; }
    public int AttackDamage { get; set; }
    public int UltimateChargeIncrease { get; set; }
}

using Game.Data.Dinosaurs.DinosaurMoves;

namespace Game.Data;

public class MoveSummary
{
    public string Attacker { get; set; }
    public string Defender { get; set; }
    public MoveType MoveType { get; set; }
    public string MoveName { get; set; }
    public bool Successful { get; set; }
    public int DefensiveIncrease { get; set; }
    public int AttackDamage { get; set; }
    public int UltimateChargeIncrease { get; set; }
}

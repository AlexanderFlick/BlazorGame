namespace Game.Data;

public class Monster
{
    public string? Name { get; set; }
    public int Level { get; set; }
    public int TotalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool Locked { get; set; }
}

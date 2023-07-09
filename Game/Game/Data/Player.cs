namespace Game.Data;

public class Player
{
    public string? Name { get; set; }
    public int Amber { get; set; }
    public int AmberPerClick { get; set; } = 1;
    public List<Monster> Monsters { get; set; } = new List<Monster>();
    public int MaxPartySize { get; set; } = 5;
    public int AmberPerMonster { get; set; } = 3;
}

namespace Game.Data;

public class Player
{
    public string? Name { get; set; }
    public int Gold { get; set; }
    public int GoldPerClick { get; set; } = 1;
    public List<Monster> Monsters { get; set; } = new List<Monster>();
    public int MaxPartySize { get; set; } = 5;
    public int GoldPerMonster { get; set; } = 3;
}

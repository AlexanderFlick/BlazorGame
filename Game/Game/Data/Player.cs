namespace Game.Data;

public class Player
{
    public string? Name { get; set; }
    public int Gold { get; set; }
    public int GoldPerClick { get; set; }
    public List<Monster> Monsters { get; set; } = new List<Monster>();
    public int MaxPartySize { get; set; } = 5;    
}

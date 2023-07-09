namespace Game.Data;

public class Player
{
    public string? Name { get; set; }
    public int Amber { get; set; }
    public int AmberPerClick { get; set; } = 1;
    public List<Fossil> Fossils { get; set; } = new List<Fossil>();
    public int MaxPartySize { get; set; } = 5;
    public int AmberPerMonster { get; set; } = 3;
}

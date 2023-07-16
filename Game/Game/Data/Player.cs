using Game.Data.Amber;
using Game.Data.Dinosaurs;
using Game.Data.Fossils;
using Game.Data.Items;

namespace Game.Data;

[Serializable]
public class Player
{
    public string? Name { get; set; }
    public int Amber { get; set; }
    public int AmberPerClick { get; set; } = 1;
    public int MaxPartySize { get; set; } = 2;
    public Battle Battle { get; set; } = new Battle();
    public Access Access { get; set; } = new Access();
    public List<Fossil> Fossils { get; set; } = new List<Fossil>();
    public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();
    public List<Equipment> UnassignedItems { get; set; } = new List<Equipment>();
    
    public DinosaurEraEnum Era { get; set; } = DinosaurEraEnum.Triassic;
    public AmberType AmberType { get; set; } = AmberType.Yellow;
    public Ultimate Ultimate { get; set; } = new Ultimate();
}

public class Access
{
    public bool Party { get; set; }
    public bool Labratory { get; set; }
    public bool AmberHunting { get; set; }
    public bool Items { get; set; }
    public bool Battle { get; set; }
    public bool FossilFusion { get; set; }
}

public class Ultimate
{
    public string Name { get; set; } = "Unrelenting Frenzy";
    public int CurrentCharge { get; set; }
    public int MaxCharge { get; set; } = 100;
    public int Damage { get; set; } = 75;
}

public class Battle
{
    public bool Won { get; set; }
    public bool FirstRound { get; set; } = true;
}
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
    public int AmberPerClick { get; set; } = 20;
    public List<Fossil> Fossils { get; set; } = new List<Fossil>();
    public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();
    public int MaxPartySize { get; set; } = 2;
    public int AmberPerFossil { get; set; } = 3;
    public DinosaurEraEnum Era { get; set; } = DinosaurEraEnum.Triassic;
    public AmberType AmberType { get; set; } = AmberType.Yellow;
    public List<Equipment> UnassignedItems { get; set; } = new List<Equipment>();
    public Access Access { get; set; } = new Access();
    public int MaxDinosaursHuntingForAmber { get; set; } = 1;
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
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
    public Access Access { get; set; } = new Access();
    public List<Fossil> Fossils { get; set; } = new List<Fossil>();
    public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();
    public List<Equipment> UnassignedItems { get; set; } = new List<Equipment>();
    
    public DinosaurEraEnum Era { get; set; } = DinosaurEraEnum.Triassic;
    public AmberType AmberType { get; set; } = AmberType.Yellow;
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
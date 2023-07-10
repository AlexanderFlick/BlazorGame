using Game.Data.Amber;
using Game.Data.Dinosaurs;
using Game.Data.Fossils;
using Game.Data.Items;

namespace Game.Data;

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
    public List<Item> UnassignedItems { get; set; } = new List<Item>();
}

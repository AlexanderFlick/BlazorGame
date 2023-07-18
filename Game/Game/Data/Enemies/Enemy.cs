using Game.Data.Dinosaurs;

namespace Game.Data.Enemies;

public class Enemy : Dinosaur
{
    public int Experience { get; set; }
    public string Description { get; set; }
}

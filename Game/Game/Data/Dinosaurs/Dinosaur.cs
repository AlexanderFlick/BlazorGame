using Game.Data.Items;

namespace Game.Data.Dinosaurs;

public class Dinosaur
{
    public string? Name { get; set; }
    public string? PetName { get; set; }
    public int Level { get; set; } = 1;
    public int ExperienceToLevelUp { get; set; }
    public int CurrentExperience { get; set; }
    public int TotalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool Locked { get; set; }
    public DinosaurTypeEnum DinosaurType { get; set; }
    public DinosaurEraEnum DinosaurEra { get; set; }
    public DinosaurColorEnum DinosaurColor { get; set; }
    public DinosaurCost DinosaurCost { get; set; } = new DinosaurCost();
    public List<Equipment> Items { get; set; } = new List<Equipment>();
    public bool BattleSelected { get; set; }
    public bool AmberHunting { get; set; }
}

public class DinosaurCost
{
    public int Rib { get; set; } = 3;
    public int Foot { get; set; } = 2;
    public int Skull { get; set; } = 1;
    public int Claw { get; set; } = 5;
}

using Game.Data.Dinosaurs.DinosaurMoves;
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
    public int PartyPosition { get; set; }
    public int CurrentHealth { get; set; }

    public bool Locked { get; set; }
    public bool Hostile { get; set; }
    public bool Dead { get; set; }

    public BattleStat Battle { get; set; } = new BattleStat();

    public DinosaurAmberHunting AmberHunting { get; set; } = new DinosaurAmberHunting();
    public DinosaurCost Cost { get; set; } = new DinosaurCost();
    public List<Equipment> Items { get; set; } = new List<Equipment>();
    public List<Move> Moves { get; set; } = new List<Move>();
    public DinosaurTypeEnum DinosaurType { get; set; }
    public DinosaurEraEnum DinosaurEra { get; set; }
    public DinosaurMutationEnum DinosaurColor { get; set; }
}

public class DinosaurCost
{
    public int Rib { get; set; } = 3;
    public int Foot { get; set; } = 2;
    public int Skull { get; set; } = 1;
    public int Claw { get; set; } = 5;
    public int TailSpike { get; set; } = 4;
    public int Neck { get; set; }
}

public class DinosaurAmberHunting
{
    public bool Hunting { get; set; }
    public int PerSecond { get; set; } = 1;
    public int MaxCollected { get; set; } = 100;
    public int Total { get; set; }
}

public class BattleStat
{
    public int CurrentDefense { get; set; }
    public int BaseDefense { get; set; }
    public bool Selected { get; set; }

    public int AttackModifier { get; set; }
    public int Speed { get; set; }
    
}

namespace Game.Data.Dinosaurs;

public class Dinosaur
{
    public string? Name { get; set; }
    public int FossilsToCreate { get; set; }
    public int Level { get; set; } = 1;
    public int ExperienceToLevelUp { get; set; }
    public int CurrentExperience { get; set; }
    public int TotalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool Locked { get; set; }
}

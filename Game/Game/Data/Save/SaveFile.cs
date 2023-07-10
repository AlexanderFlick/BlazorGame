namespace Game.Data.Save;

public class SaveFile
{
    public string Path { get; set; } = "C://ProgramFiles/Game/save.txt";
    public bool Saving { get; set; }
    public bool Loading { get; set; }
}

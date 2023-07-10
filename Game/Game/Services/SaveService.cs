using Game.Data;
using System.Text.Json;

namespace Game.Services;

public interface ISaveService
{
    Player Load(string path);
    void Save(Player player, string path);
}
public class SaveService : ISaveService
{
    public Player Load(string path)
    {
        if (!Directory.Exists("C://ProgramFiles/Game"))
        {
            Directory.CreateDirectory("C://ProgramFiles/Game");
        }
        var saveText = File.ReadAllText(path);
        var player = JsonSerializer.Deserialize<Player>(saveText);
        return player;
    }

    public void Save(Player player, string path)
    {
        Directory.CreateDirectory("C://ProgramFiles/Game");
        using StreamWriter file = File.CreateText(path);
        var playerString = JsonSerializer.Serialize<Player>(player);
        file.Write(playerString);
    }
}

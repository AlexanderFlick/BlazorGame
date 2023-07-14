using Game.Data.Dinosaurs;

namespace Game.Data.Fossils;

public class Fossil
{
    public DinosaurTypeEnum DinosaurType { get; set; }
    public CarnivoreFossil? CarnivoreFossils { get; set; }
    public HerbivoreFossil? HerbivoreFossils { get; set; }
}

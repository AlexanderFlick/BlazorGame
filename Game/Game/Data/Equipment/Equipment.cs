using Game.Data.Dinosaurs;
using Game.Data.Fossils;

namespace Game.Data.Items;

public class Equipment
{
    public EquipmentType Type { get; set; }
    public EquipmentQuality Quality { get; set; }
    public string Name { get; set; }
    public int Buff { get; set; }
    public FossilType DinosaurBodyPart { get; set; }
}

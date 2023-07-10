using Game.Data.Items;

namespace Game.Services;

public interface IItemService
{
    Equipment GetNewItem();
}

public class ItemService : IItemService
{
    Random rand = new();
    public Equipment GetNewItem() 
    {
        return new Equipment
        {
            Quality = GetQuality(),
            Type= GetEquipmentType(),
        };
    }

    private EquipmentQuality GetQuality()
    {
        return EquipmentQuality.Average;
    }

    private EquipmentType GetEquipmentType()
    {
        return EquipmentType.Gun;
    }
}

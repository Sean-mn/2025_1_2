public class GetableAirFuel : GetableItem
{
    protected override void InitItem()
    {
        _item.ItemType = ItemType.UsableItem;
    }
}

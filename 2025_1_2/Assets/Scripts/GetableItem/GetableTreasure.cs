public class GetableTreasure : GetableItem
{
    protected override void InitItem()
    {
        _item.ItemType = ItemType.Treasure;
    }
}

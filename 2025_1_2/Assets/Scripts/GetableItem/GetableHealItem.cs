public class GetableHealItem : GetableItem, IGetableItem
{
    protected override void InitItem()
    {
        _item.ItemType = ItemType.UsableItem;
    }
}

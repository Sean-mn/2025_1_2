public class GetableHealItem : GetableItem, IGetableItem
{
    protected override void InitItem()
    {
        _type = ItemType.UsableItem;
    }
}

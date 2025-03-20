using UnityEngine;

public class HealItem : GetableItem, IGetableItem
{
    [SerializeField] private PlayerHealth _playerHealth;

    protected override void InitItem()
    {
        _type = ItemType.UsableItem;
    }

    public override void UseItem()
    {
        base.UseItem();
        _playerHealth.Heal(_item.ItemValue);
    }
}

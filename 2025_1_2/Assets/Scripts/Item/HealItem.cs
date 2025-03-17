using UnityEngine;

public class HealItem : GetableItem
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

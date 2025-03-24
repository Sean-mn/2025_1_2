using UnityEngine;

public class GetableHealItem : GetableItem, IGetableItem
{
    [SerializeField] private PlayerHealth _playerHealth;

    protected override void InitItem()
    {
        _type = ItemType.UsableItem;
    }
}

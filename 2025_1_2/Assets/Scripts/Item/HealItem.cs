using UnityEngine;

public class HealItem : GetableItem
{
    [SerializeField] private PlayerHealth _playerHealth;

    public override void UseItem()
    {
        _playerHealth.Heal(_item.ItemValue);
    }
}

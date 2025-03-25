using UnityEngine;

[CreateAssetMenu]
public class Treasure : Item
{
    public override void UseItem()
    {
        PlayerMoney playerMoney = FindObjectOfType<PlayerMoney>();
        playerMoney.AddMoney(ItemMoney);
    }
}

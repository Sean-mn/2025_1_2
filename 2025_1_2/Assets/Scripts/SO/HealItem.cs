using UnityEngine;

[CreateAssetMenu]
public class HealItem : Item
{
    public override void UseItem()
    {
        Debug.Log("체력 회복!");

        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
            playerHealth.Heal(ItemValue);
    }
}

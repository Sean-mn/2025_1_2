using UnityEngine;

[CreateAssetMenu]
public class HealItem : Item
{
    public override void UseItem()
    {
        Debug.Log("ü�� ȸ��!");

        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
            playerHealth.Heal(ItemValue);
    }
}

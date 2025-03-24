using UnityEngine;

[CreateAssetMenu]
public class AirFuel : Item
{
    public override void UseItem()
    {
        Debug.Log("산소 회복");

        PlayerBreath playerBreath = FindAnyObjectByType<PlayerBreath>();
        if (playerBreath != null)
        {
            playerBreath.HealBreath(ItemValue);
        }
    }
}

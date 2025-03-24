using UnityEngine;

[CreateAssetMenu]
public class AirFuel : Item
{
    public override void UseItem()
    {
        Debug.Log("��� ȸ��");

        PlayerBreath playerBreath = FindAnyObjectByType<PlayerBreath>();
        if (playerBreath != null)
        {
            playerBreath.HealBreath(ItemValue);
        }
    }
}

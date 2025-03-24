using UnityEngine;

[CreateAssetMenu]
public class SpeedUpItem : Item
{
    public override void UseItem()
    {
        Debug.Log("���ǵ� ��");
        PlayerMovement _playerMove = FindAnyObjectByType<PlayerMovement>();
        if (_playerMove != null)
        {
            _playerMove.StartSpeedUp(ItemValue);
        }
    }
}

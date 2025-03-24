using UnityEngine;

[CreateAssetMenu]
public class SpeedUpItem : Item
{
    public override void UseItem()
    {
        Debug.Log("스피드 업");
        PlayerMovement _playerMove = FindAnyObjectByType<PlayerMovement>();
        if (_playerMove != null)
        {
            _playerMove.StartSpeedUp(ItemValue);
        }
    }
}
